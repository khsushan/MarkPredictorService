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

        public async System.Threading.Tasks.Task<Level> SaveLevel(Level level)
        {
            _markPredictorDbContext.Entry(level).State = EntityState.Modified;
            foreach (var module in level.Modules)
            {
                _markPredictorDbContext.Entry(module).State = EntityState.Modified;
                foreach (var assessment in module.Assessments)
                {
                    _markPredictorDbContext.Entry(assessment).State = EntityState.Modified;
                }
            }

            await _markPredictorDbContext.SaveChangesAsync();
            return level;
        }
    }
}
