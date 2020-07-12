using IAS.Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IAS.Frontend.Interfaces
{
    public interface ICheckCardStatusService
    {
        Task<CardInfoResponseModel> ByCID(SmartCardInfo cardInfo);
        Task<CardInfoResponseModel> ByLaser(SmartCardInfo cardInfo);
    }
}
