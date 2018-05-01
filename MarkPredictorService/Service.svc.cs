﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MarkPredictorService.ApiModels;
using MarkPredictorService.Common;
using AutoMapper;
using MarkPredictor.Shared.Entites;
using System.Threading.Tasks;

namespace MarkPredictorService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        public LevelApiModel GetLevelDetails(string levelId, string courseId)
        {
          var levelModel = InstanceFactory.GetLevelModelInstance();
            try
            {
                var levelEntity = levelModel.GetLevel(long.Parse(levelId), long.Parse(courseId));
                return Mapper.Map<LevelApiModel>(levelEntity);
            }
            catch (Exception ex)
            {
                return null;
            }
         
        }

        public LevelApiModel Update(LevelApiModel level)
        {
            var levelModel = InstanceFactory.GetLevelModelInstance();
            try
            {
                var updatedLevel = levelModel.SaveLevel(Mapper.Map<Level>(level));
                return Mapper.Map<LevelApiModel>(updatedLevel);
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
    }
}
