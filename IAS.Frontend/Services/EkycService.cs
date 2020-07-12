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
    public class EkycService : IEkycService
    {
        private readonly IHttpClientFactory clientFactory;

        public EkycService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }
        // Todo Fix
        public async Task<EkycTxModel> GetAccessToken()
        {
            EkycTxModel ekycTxModel = new EkycTxModel();
            var authen = new AuthenticateRequestModel() { Username = "P5170", Password = "123456789" }; // Todo Fix
            try
            {
                var client = clientFactory.CreateClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(authen), Encoding.UTF8, "application/json");
                using var response = await client.PostAsync("http://w2wasdho126:8094/api/user/authen", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                ekycTxModel = JsonConvert.DeserializeObject<EkycTxModel>(apiResponse);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return ekycTxModel;
        }
        public async Task<EkycTxModel> GetTranKey(EkycTxModel ekycTxModel, EkycTxKeyModel ekycTxKey)
        {
            try
            {
                var client = clientFactory.CreateClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(ekycTxKey), Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Token", ekycTxModel.AccessToken);
                using var response = await client.PostAsync("http://172.20.6.226:8080/ekyc-app/api/get-tx-key", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                var resModel = JsonConvert.DeserializeObject<BaseResponseModel>(apiResponse);
                ekycTxModel.TransactionKey = resModel.Data;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return ekycTxModel;
        }
        public async Task<EkycTxModel> GeteKycLink(EkycTxModel ekycTxModel)
        {
            TransactionKeyRequestModel txKeyReq = new TransactionKeyRequestModel() { TransactionKey = ekycTxModel.TransactionKey };
            try
            {
                var client = clientFactory.CreateClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(txKeyReq), Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Token", ekycTxModel.AccessToken);
                using var response = await client.PostAsync("http://172.20.6.226:8080/ekyc-app/api/open-camera", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                var resModel = JsonConvert.DeserializeObject<BaseResponseModel>(apiResponse);
                ekycTxModel.Url = resModel.Data;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return ekycTxModel;
        }

        public async Task<EkycResResultModel> GetFaceMatchingResult(EkycTxModel ekycTxModel)
        {
            var tranReqCamera = new TransactionKeyRequestModel();
            tranReqCamera.TransactionKey = ekycTxModel.TransactionKey;
            EkycResResultModel responseModel = new EkycResResultModel();
            try
            {
                var client = clientFactory.CreateClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(tranReqCamera), Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Token", ekycTxModel.AccessToken);
                using var response = await client.PostAsync("http://172.20.6.226:8080/ekyc-app/api/ekyc-result", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                var resModel = JsonConvert.DeserializeObject<EkycResResultModel>(apiResponse);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return responseModel;
        }
    }
}
