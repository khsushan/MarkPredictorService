using MarkPredictor.Shared.Entites;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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

        public Level GetLevel(long levelId, long courseId)
        {
            return _markPredictorDbContext.Level.Include(l => l.Modules).Include(l => l.Modules.Select(a => a.Assessments)).Where(l => l.Id == levelId).AsNoTracking().ToList().Select(
                l => new Level
                {
                    Id = l.Id,
                    LevelName = l.LevelName,
                    Modules = new Collection<Module>(l.Modules.Where(m => m.CourseId == courseId).ToList())
                }).FirstOrDefault();
        }

        public Level SaveLevel(Level level)
        {
            foreach (var module in level.Modules)
            {
                foreach (var assessment in module.Assessments)
                {
                    _markPredictorDbContext.Entry(assessment).State = EntityState.Modified;
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
