using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IAS.Frontend.Models
{
    public class TransactionKeyRequestModel
    {
        [JsonProperty("transactionKey")]
        public string TransactionKey { get; set; }
    }
}
