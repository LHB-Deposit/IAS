using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IAS.Frontend.Models
{
    public class EkycResResultModel
    {
        [JsonProperty("status")]
        public StatusResponseModel Status { get; set; }
        [JsonProperty("finalResult")]
        public string FinalResult { get; set; }
        [JsonProperty("remark")]
        public string Remark { get; set; }
        [JsonProperty("ialLevel")]
        public string IalLevel { get; set; }
        [JsonProperty("faceScore")]
        public string FaceScore { get; set; }
        [JsonProperty("cameraImage")]
        public string CameraImage { get; set; }
    }
}
