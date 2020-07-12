using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IAS.Frontend.Models
{
    public class StatusResponseModel
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
