using MarkPredictorService.ApiModels;
using MarkPredictor.Shared.Models;
using AutoMapper;
using MarkPredictor.Shared.Entites;
using MarkPredictorService.Common;

namespace MarkPredictorService.Services
{
    public class AssessmentService : IAssessmentService
    {
        /// <summary>
        /// Add assessment service
        /// </summary>
        /// <param name="assessment">Assessment request </param>
        /// <returns></returns>
        public BaseApiModel AddAssessment(AssessmentApiModel assessment)
        {
            var assessmentModel = InstanceFactory.GetAssessmentModelInstance();
            var assessmentEntity = assessmentModel.AddAssessment(Mapper.Map<Assessment>(assessment));
            assessment.Id = assessmentEntity.Id;
            return assessment;
        }
    }
}
