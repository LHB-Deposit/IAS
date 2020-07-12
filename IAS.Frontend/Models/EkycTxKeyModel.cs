using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IAS.Frontend.Models
{
    public class EkycTxKeyModel
    {
        public string applicationNo { get; set; }
        public string serviceType { get; set; }
        public string mode { get; set; }
        public string subMode { get; set; }
        public string idCard { get; set; }
        public string titleNameTh { get; set; }
        public string firstNameTh { get; set; }
        public string middleNameTh { get; set; }
        public string lastNameTh { get; set; }
        public string titleNameEn { get; set; }
        public string firstNameEn { get; set; }
        public string middleNameEn { get; set; }
        public string lastNameEn { get; set; }
        public string chipImage { get; set; }
        public string staffId { get; set; }
        public string staffName { get; set; }
        public string overrideStaffId { get; set; }
        public string overrideStaffName { get; set; }
        public string branchCode { get; set; }
        public string branceName { get; set; }
        public string remark { get; set; }
        public string dopaResultCode { get; set; }
        public string dopaResultDesc { get; set; }
    }
}
