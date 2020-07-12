using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Models
{
    public class BankServiceCatalogue : BaseEntity
    {
        public string Name { get; set; }
        public List<BankService> BankServices { get; set; }

    }
}
