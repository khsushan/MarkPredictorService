﻿using MarkPredictor.Shared.Entites;
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

        public long Id { get; set; }

        public string ModuleName { get; set; }

        public long LevelId { get; set; }

        public long CourseId { get; set; }

        public int Save()
        {
            Module module = new Module
            {
                ModuleName = ModuleName,
                CourseId = CourseId,
                LevelId = LevelId
            };
            _markPredictorDbContext.Module.Add(module);
            return _markPredictorDbContext.SaveChanges();
        }
    }
}