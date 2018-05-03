using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarkPredictorService.ApiModels
{
    public class ErrorResponseAPIModel : BaseApiModel
    {

        public bool IsError { get; set; }

        public string ErrorMessage{ get; set; }
    }
}