using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IAS.Frontend.Models
{
    public class EkycTxModel
    {
        public string AccessToken { get; set; } = string.Empty;
        public string TransactionKey { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
