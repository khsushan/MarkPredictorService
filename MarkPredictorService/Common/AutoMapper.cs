using AutoMapper;
using MarkPredictor.Shared.Entites;
using MarkPredictorService.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarkPredictorService.Common
{
    public static class AutoMapper
    {
        private static bool _isInitialized;
        public static void Initialize()
        {
            if (!_isInitialized)
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Module, ModuleApiModel>();
                    cfg.CreateMap<ModuleApiModel, Module>();
                    cfg.CreateMap<Assessment, AssessmentApiModel>();
                    cfg.CreateMap<AssessmentApiModel, Assessment>();
                    cfg.CreateMap<Level, LevelApiModel>();
                    cfg.CreateMap<LevelApiModel, Level>();
                    cfg.CreateMap<StudentApiModel, Student>();
                    cfg.CreateMap<Student, StudentApiModel>();
                });
                _isInitialized = true;
            }
        }
    }
}