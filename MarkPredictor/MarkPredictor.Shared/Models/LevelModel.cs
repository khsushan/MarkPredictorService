﻿using MarkPredictor.Shared.Entites;
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
        public long Id { get; set; }

        public LevelModel(MarkPredictorDbContext markPredictorDbContext)
        {
            _markPredictorDbContext = markPredictorDbContext;
        }

        public Level GetLevel()
        {
           return  _markPredictorDbContext.Level.Where(l => l.Id == Id).Include(l => l.Modules).Include(x => x.Modules.Select(y => y.Assessments)).FirstOrDefault();
        }
    }
}