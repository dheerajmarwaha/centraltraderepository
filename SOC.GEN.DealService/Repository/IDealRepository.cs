using SOC.GEN.DealService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC.GEN.DealService.Repository
{
    public interface IDealRepository
    {
        Task<IEnumerable<Deal>> GetDeals();
        Deal GetDealById(int dealId);
        List<Deal> GetDealByLastRefreshDate(DateTime lastRefreshDate);
        List<Deal> GetDealsByCountryId(int id);
        void DeleteDeal(int dealId);
        void UpdateDeal(Deal deal);
        void Save();
    }
}
