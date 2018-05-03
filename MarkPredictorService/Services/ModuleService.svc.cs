using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MarkPredictorService.ApiModels;
using MarkPredictor.Shared.Models;
using AutoMapper;
using MarkPredictor.Shared.Entites;
using MarkPredictorService.Common;

namespace MarkPredictorService.Services
{
    public class ModuleService : IModuleService
    {
        private ModuleModel _moduleModuel;

        public ModuleService()
        {
            _moduleModuel = InstanceFactory.GetModuleModelInstance();
        }

        /// <summary>
        /// Add module service
        /// </summary>
        /// <param name="moduleDto">Module Dto request</param>
        /// <returns></returns>
        public BaseApiModel AddModule(ModuleApiModel moduleDto)
        {
            var module = _moduleModuel.Save(Mapper.Map<Module>(moduleDto));
            moduleDto.Id = module.Id;
            return moduleDto;
        }

    }
}
