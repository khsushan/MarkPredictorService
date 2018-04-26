using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace MarkPredictorService.Dto
{
    [DataContract]
    public class ModuleDto
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string ModuleName { get; set; }

        [DataMember]
        public long LevelId { get; set; }

        [DataMember]
        public long CourseId { get; set; }

        [DataMember]
        public double Credit { get; set; }

        [DataMember]
        public ObservableCollection<AssessmentDto> Assessments { get; set; }

        [DataMember]
        public double ModuleAverage { get; set; }
    }
}
