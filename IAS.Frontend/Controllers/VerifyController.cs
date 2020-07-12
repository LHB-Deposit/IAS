using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using IAS.Frontend.Interfaces;
using IAS.Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IAS.Frontend.Controllers
{
    public class VerifyController : BaseController
    {
        private readonly IEkycService ekycService;
        private readonly ICheckCardStatusService checkCardStatusService;

        public VerifyController(IEkycService ekycService, ICheckCardStatusService checkCardStatusService)
        {
            this.ekycService = ekycService;
            this.checkCardStatusService = checkCardStatusService;
        }
        public IActionResult Index()
        {
            return View(new PersonalViewModel());
        }

        [HttpPost]
        public async Task<EkycTxKeyModel> CheckCardStatus(SmartCardInfo smartCardInfo)
        {

            CardInfoResponseModel cardInfoResponse = new CardInfoResponseModel();
            // Call Dopa WsService
            // Select mode: 3 => Dipship, 5=> Non-Dipship
            switch (smartCardInfo.Mode)
            {
                case "3":
                    // Call ByCID 
                    cardInfoResponse = await checkCardStatusService.ByCID(smartCardInfo);
                    break;
                case "5":
                    // Call ByLaser
                    cardInfoResponse = await checkCardStatusService.ByLaser(smartCardInfo);
                    break;
            }

            EkycTxKeyModel txKeyModel = new EkycTxKeyModel
            {
                applicationNo = "2020051900010001",
                serviceType = "Account Opening",
                mode = cardInfoResponse.Data.Mode,
                subMode = "Y",
                idCard = smartCardInfo.PID,
                titleNameTh = smartCardInfo.PrefixNameTh,
                firstNameTh = smartCardInfo.NameTh,
                middleNameTh = smartCardInfo.MiddlenameTh,
                lastNameTh = smartCardInfo.SurenameTh,
                titleNameEn = smartCardInfo.PrefixNameEn,
                firstNameEn = smartCardInfo.NameEn,
                middleNameEn = smartCardInfo.MiddlenameEn,
                lastNameEn = smartCardInfo.SurenameEn,
                chipImage = Convert.ToBase64String(smartCardInfo.Image),
                staffId = "P5170",
                staffName = "Pornchai",
                overrideStaffId = "",
                overrideStaffName = "",
                branchCode = "889",
                branceName = "สาทร",
                remark = "",
                dopaResultCode = cardInfoResponse.Data.StatusCode,
                dopaResultDesc = cardInfoResponse.Data.Desc
            };

            return txKeyModel;
        }

        [HttpPost]
        public async Task<EkycTxModel> CameraLink(EkycTxKeyModel ekycTxKeyModel)
        {
            var eKycTxModel = await ekycService.GetAccessToken(); // Todo Fix
            eKycTxModel = await ekycService.GetTranKey(eKycTxModel, ekycTxKeyModel);
            return await ekycService.GeteKycLink(eKycTxModel);
        }

        [HttpPost]
        public async Task<EkycResResultModel> FaceMathingResult(EkycTxModel ekycTxModel)
        {
            var faceResponse = await ekycService.GetFaceMatchingResult(ekycTxModel);
            return faceResponse;
        }
    }
}
