using SOC.GEN.DealService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC.GEN.DealService.Repository
{
    public interface IDealRepository
    {
        IEnumerable<Deal> GetDeals();
        Deal GetDealById(int dealId);
        void DeleteDeal(int dealId);
        void UpdateDeal(Deal deal);
        void Save();
    }
}
