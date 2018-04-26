using MarkPredictor.Shared.Enum;
using System.Runtime.Serialization;

namespace MarkPredictorService.Dto
{
    [DataContract]
    public class AssessmentDto
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
