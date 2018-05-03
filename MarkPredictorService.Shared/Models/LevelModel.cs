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

        /// <summary>
        /// Get level details according to given level and course Id
        /// </summary>
        /// <param name="levelId"> Level id</param>
        /// <param name="courseId"> Course Id</param>
        /// <returns></returns>
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

        /// <summary>
        ///  Update the given level object
        /// </summary>
        /// <param name="level">The level object which is need to be updated</param>
        /// <returns></returns>
        public Level UpdateLevel(Level level)
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
