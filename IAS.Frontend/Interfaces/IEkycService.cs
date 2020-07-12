using IAS.Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IAS.Frontend.Interfaces
{
    public interface IEkycService
    {
        Task<EkycTxModel> GetAccessToken();
        Task<EkycTxModel> GetTranKey(EkycTxModel ekycTxModel, EkycTxKeyModel ekycTxKey);
        Task<EkycTxModel> GeteKycLink(EkycTxModel ekycTxModel);
        Task<EkycResResultModel> GetFaceMatchingResult(EkycTxModel ekycTxModel);
    }
}
