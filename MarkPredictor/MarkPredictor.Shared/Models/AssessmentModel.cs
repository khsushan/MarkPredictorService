﻿using MarkPredictor.Shared.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkPredictor.Shared.Models
{
    public class AssessmentModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public double Precentage { get; set; }
    }
}
