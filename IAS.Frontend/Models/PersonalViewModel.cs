using System;
using System.ComponentModel.DataAnnotations;

namespace IAS.Frontend.Models
{
    public class PersonalViewModel
    {
        public string IdNo { get; set; }
        public string NameTh { get; set; }
        public string MiddleNameTh { get; set; }
        public string SurenameTh { get; set; }
        public string NameEn { get; set; }
        public string MiddleNameEn { get; set; }
        public string SurenameEn { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateOfBirth { get; set; }
        public string LaserNo { get; set; }
        public string Address { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateOfIssue { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateOfExpiry { get; set; }
    }
}
