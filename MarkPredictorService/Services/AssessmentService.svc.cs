using MarkPredictorService.ApiModels;
using MarkPredictor.Shared.Models;
using AutoMapper;
using MarkPredictor.Shared.Entites;
using MarkPredictorService.Common;

namespace MarkPredictorService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AssessmentService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AssessmentService.svc or AssessmentService.svc.cs at the Solution Explorer and start debugging.
    public class AssessmentService : IAssessmentService
    {
        public AssessmentApiModel AddAssessment(AssessmentApiModel assessment)
        {
            var assessmentModel = InstanceFactory.GetAssessmentModelInstance();
            var assessmentEntity = assessmentModel.AddAssessment(Mapper.Map<Assessment>(assessment));
            assessment.Id = assessmentEntity.Id;
            return assessment;
        }
    }
}
