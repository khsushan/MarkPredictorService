using MarkPredictor.Shared.Enum;
using System.Runtime.Serialization;

namespace MarkPredictorService.ApiModels
{
    [DataContract]
    public class AssessmentApiModel : BaseApiModel
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public double Weight { get; set; }

        [DataMember]
        public long ModuleId { get; set; }

        [DataMember]
        public double Mark { get; set; }

        [DataMember]
        public AssessmentType AssessmentType { get; set; }
    }
}
