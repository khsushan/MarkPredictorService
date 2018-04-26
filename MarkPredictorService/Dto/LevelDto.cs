using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MarkPredictorService.Dto
{
    [DataContract]
    public class LevelDto
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string LevelName { get; set; }

        [DataMember]
        public double Average { get; set; }

        [DataMember]
        public IList<ModuleDto> Modules { get; set; }
    }
}
