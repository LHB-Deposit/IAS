using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IAS.Frontend.Models
{
    public class Address
    {
        public string HouseNo { get; set; }
        public string VillageNo { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string Room { get; set; }
        public string Lane { get; set; }
        public string Alley { get; set; }
        public string Road { get; set; }
        public string SubDistrict { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
    }
}
