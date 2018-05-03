using MarkPredictorService.ApiModels;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace MarkPredictorService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IModuleService" in both code and config file together.
    [ServiceContract]
    public interface IModuleService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "add", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        [OnDeserialized]
        ModuleApiModel AddModule(ModuleApiModel moduleDto);
    }
}
