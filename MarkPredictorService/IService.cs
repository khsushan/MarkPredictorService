using MarkPredictorService.Dto;
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
        AssessmentDto AddAssesment(AssessmentDto assementDto);

        [OperationContract]
        [WebGet( ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "level/{levelId}")]
        LevelDto GetLevelDetails(string levelId);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "test")]
        string Test();

        // TODO: Add your service operations here
    }
}
