using MarkPredictorService.ApiModels;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace MarkPredictorService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAssessmentService" in both code and config file together.
    [ServiceContract]
    public interface IAssessmentService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "add", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        BaseApiModel AddAssessment(AssessmentApiModel assessment);
    }
}
