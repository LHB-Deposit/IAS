using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IAS.Frontend.Models
{
    public class BaseResponseModel
    {
        [JsonProperty("status")]
        public StatusResponseModel Status { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }
    }
}
