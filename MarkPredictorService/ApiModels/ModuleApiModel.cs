using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace MarkPredictorService.ApiModels
{
    [DataContract]
    public class ModuleApiModel
    {
        public ModuleApiModel()
        {

        }

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
        public ObservableCollection<AssessmentApiModel> Assessments { get; set; }

        [DataMember]
        public double ModuleAverage { get; set; }
    }
}
