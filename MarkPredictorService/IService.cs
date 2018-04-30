using MarkPredictorService.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MarkPredictorService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebGet( ResponseFormat = WebMessageFormat.Json, UriTemplate = "{levelId}/course/{courseId}")]
        LevelApiModel GetLevelDetails(string levelId, string courseId);

        [OperationContract]
        [WebInvoke(UriTemplate = "update", Method = "PUT", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        LevelApiModel Update(LevelApiModel level);

        // TODO: Add your service operations here
    }
}
