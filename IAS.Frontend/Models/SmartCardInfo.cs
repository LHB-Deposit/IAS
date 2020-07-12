using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IAS.Frontend.Models
{
    public class SmartCardInfo
    {
        public string Version { get; set; }
        public string PID { get; set; }
        public string CID { get; set; }
        public string Bp1No { get; set; }
        public string PrefixNameTh { get; set; }
        public string NameTh { get; set; }
        public string MiddlenameTh { get; set; }
        public string SurenameTh { get; set; }
        public string PrefixNameEn { get; set; }
        public string NameEn { get; set; }
        public string MiddlenameEn { get; set; }
        public string SurenameEn { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string CardTypeCode { get; set; }
        public string DateOfIssue { get; set; }
        public string DateOfExpiry { get; set; }
        public string LaserNo { get; set; }
        public byte[] Image { get; set; }
        public List<Address> Address { get; set; }
        public string ErrorMessage { get; set; }
        public string Mode { get; set; }

    }
}
