using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarkPredictorService.ApiModels
{
    public class StudentApiModel
    {
        public long Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public long CourseId { get; set; }
    }
}