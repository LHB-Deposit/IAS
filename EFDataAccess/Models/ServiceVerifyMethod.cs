using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Models
{
    public class ServiceVerifyMethod : BaseEntity
    {
        public List<BankService> BankServices { get; set; }
        public List<ServiceVerify> ServiceVerifies { get; set; }
    }
}
