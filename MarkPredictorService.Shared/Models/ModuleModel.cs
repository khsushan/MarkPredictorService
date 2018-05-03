using MarkPredictor.Shared.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkPredictor.Shared.Models
{
    public class ModuleModel : IModuleModel
    {
        private MarkPredictorDbContext _markPredictorDbContext;
        public ModuleModel(MarkPredictorDbContext markPredictorDbContext)
        {
            _markPredictorDbContext = markPredictorDbContext;
        }

        /// <summary>
        /// Save module method
        /// </summary>
        /// <param name="module">Module entity</param>
        /// <returns></returns>    
        public Module Save(Module module)
        {
            _markPredictorDbContext.Module.Add(module);
           _markPredictorDbContext.SaveChanges();
            _markPredictorDbContext.Entry(module).State = System.Data.Entity.EntityState.Detached;
            return module;
        }
    }
}
