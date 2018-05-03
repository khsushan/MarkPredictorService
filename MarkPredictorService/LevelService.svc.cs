using System;
using MarkPredictorService.ApiModels;
using MarkPredictorService.Common;
using AutoMapper;
using MarkPredictor.Shared.Entites;

namespace MarkPredictorService
{
    public class Service : ILevelService
    {
        /// <summary>
        /// Gee level details according to the given level and the course Id
        /// </summary>
        /// <param name="levelId">Level Id</param>
        /// <param name="courseId">Course Id</param>
        /// <returns>level response</returns>
        public LevelApiModel GetLevelDetails(string levelId, string courseId)
        {
            var levelModel = InstanceFactory.GetLevelModelInstance();
            var levelEntity = levelModel.GetLevel(long.Parse(levelId), long.Parse(courseId));
            return Mapper.Map<LevelApiModel>(levelEntity);
        }

        /// <summary>
        /// Update the given klevel 
        /// </summary>
        /// <param name="level"> lever object</param>
        /// <returns>updated response</returns>
        public LevelApiModel Update(LevelApiModel level)
        {
            var levelModel = InstanceFactory.GetLevelModelInstance();
            var updatedLevel = levelModel.UpdateLevel(Mapper.Map<Level>(level));
            return Mapper.Map<LevelApiModel>(updatedLevel);
        }

    }

}
