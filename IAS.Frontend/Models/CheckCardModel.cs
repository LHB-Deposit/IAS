using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IAS.Frontend.Models
{
    public class CheckCardModel : BaseRequestModel
    {
        public string PID { get; set; }
        public string CID { get; set; }
        public string Bp1No { get; set; }
        public string NameTh { get; set; }
        public string SurenameTh { get; set; }
        public string DateOfBirth { get; set; }
        public string LaserNo { get; set; }
    }
}
