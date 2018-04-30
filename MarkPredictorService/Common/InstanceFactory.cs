using Autofac;
using MarkPredictor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarkPredictorService.Common
{
    public static class InstanceFactory
    {
        public static IContainer Container { get; set; }

        public static ModuleModel GetModuleModelInstance()
        {
            return Container.Resolve<ModuleModel>();
        }

        public static LevelModel GetLevelModelInstance()
        {
            return Container.Resolve<LevelModel>();
        }

        public static AssessmentModel GetAssessmentModelInstance()
        {
            return Container.Resolve<AssessmentModel>();
        }

        public static StudentModel GetStudentModel()
        {
            return Container.Resolve<StudentModel>();
        }
    }
}