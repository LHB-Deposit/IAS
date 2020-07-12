using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IAS.Frontend.Models
{
    public class CardInfo
    {
        public string StatusCode { get; set; }
        public string Desc { get; set; }
        public string ErrorMessage { get; set; }
        public string IsError { get; set; }
        public string RefNo { get; set; }
        public string Mode { get; set; }
    }
}
