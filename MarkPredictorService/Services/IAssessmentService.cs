using MarkPredictorService.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MarkPredictorService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAssessmentService" in both code and config file together.
    [ServiceContract]
    public interface IAssessmentService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "add", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        AssessmentApiModel AddAssessment(AssessmentApiModel assessment);
    }
}
