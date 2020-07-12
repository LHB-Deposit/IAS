using IAS.Frontend.Interfaces;
using IAS.Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IAS.Frontend.Services
{
    public class CheckCardStatusService : ICheckCardStatusService
    {
        private readonly IHttpClientFactory clientFactory;

        public CheckCardStatusService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<CardInfoResponseModel> ByCID(SmartCardInfo smartCardInfo)
        {
            CheckCardModel cardModel = new CheckCardModel
            {
                ReferenceNo = "DO100120200707161630123", // Todo Fix Ref between system 
                BranchNumber = "889",
                TerminalId = "T15000015",
                PID = smartCardInfo.PID,
                CID = smartCardInfo.CID,
                Bp1No = smartCardInfo.Bp1No,
                NameTh = smartCardInfo.NameTh,
                SurenameTh = smartCardInfo.SurenameTh,
                DateOfBirth = smartCardInfo.DateOfBirth,
                LaserNo = smartCardInfo.LaserNo
            };
            CardInfoResponseModel resTxKey = new CardInfoResponseModel();
            try
            {
                var client = clientFactory.CreateClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(cardModel), Encoding.UTF8, "application/json");
                using var response = await client.PostAsync("http://w2wasdho126:9090/api/checkcardstatus/bycid", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                resTxKey = JsonConvert.DeserializeObject<CardInfoResponseModel>(apiResponse);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return resTxKey;
        }

        public async Task<CardInfoResponseModel> ByLaser(SmartCardInfo smartCardInfo)
        {
            CardInfoResponseModel resModel = new CardInfoResponseModel();
            try
            {
                var client = clientFactory.CreateClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(smartCardInfo), Encoding.UTF8, "application/json");
                using var response = await client.PostAsync("http://172.20.6.226:8080/ekyc-app/api/ekyc-result", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                resModel = JsonConvert.DeserializeObject<CardInfoResponseModel>(apiResponse);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return resModel;
        }
    }
}
