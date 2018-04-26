using AutoMapper;
using MarkPredictor.Shared.Entites;
using MarkPredictorService.Dto;
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
                    cfg.CreateMap<Module, ModuleDto>();
                    cfg.CreateMap<ModuleDto, Module>();
                    cfg.CreateMap<Assessment, AssessmentDto>();
                    cfg.CreateMap<AssessmentDto, Assessment>();
                    cfg.CreateMap<Level, LevelDto>();
                    cfg.CreateMap<LevelDto, Level>();
                });
                _isInitialized = true;
            }
        }
    }
}