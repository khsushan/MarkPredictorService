using MarkPredictor.Shared.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace MarkPredictor.Shared.Models
{
    public class LevelModel
    {
        public MarkPredictorDbContext _markPredictorDbContext;

        public LevelModel(MarkPredictorDbContext markPredictorDbContext)
        {
            _markPredictorDbContext = markPredictorDbContext;
        }

        public Level GetLevel(long levelId)
        {
           return  _markPredictorDbContext.Level.Where(l => l.Id == levelId).Include(l => l.Modules).Include(x => x.Modules.Select(y => y.Assessments)).AsNoTracking().FirstOrDefault();
        }

        public Level SaveLevel(Level level)
        {
            foreach (var module in level.Modules)
            {
                foreach (var assessment in module.Assessments)
                {
                    if (_markPredictorDbContext.Entry(assessment).State != EntityState.Modified)
                    {
                        _markPredictorDbContext.Entry(assessment).State = EntityState.Modified;
                    }
                    _markPredictorDbContext.Entry(assessment).CurrentValues.SetValues(assessment);
                }
            }
            _markPredictorDbContext.SaveChanges();
            DetachedEntites(level);
            return level;
        }

        private void DetachedEntites(Level level)
        {
            foreach (var module in level.Modules)
            {
                foreach (var assessment in module.Assessments)
                {
                    _markPredictorDbContext.Entry(assessment).State = EntityState.Detached;
                }
            }
        }
    }
}
