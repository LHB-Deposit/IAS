using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Models
{
    public class TransactionLog : BaseEntity
    {
        public DateTime CreateDate { get; set; }
        public string Detail { get; set; }
    }
}
