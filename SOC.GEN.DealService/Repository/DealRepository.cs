using Microsoft.EntityFrameworkCore;
using SOC.GEN.DealService.DBContexts;
using SOC.GEN.DealService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC.GEN.DealService.Repository
{
    public class DealRepository : IDealRepository
    {
        private readonly DealContext dealContext;

        public DealRepository(DealContext dealContext)
        {
            this.dealContext = dealContext;
        }

        public void DeleteDeal(int dealId)
        {
            var deal = dealContext.Deals.Find(dealId);
            dealContext.Deals.Remove(deal);
            Save();
        }

        public Deal GetDealById(int dealId)
        {
            return dealContext.Deals.Find(dealId);
        }

        public IEnumerable<Deal> GetDeals()
        {
            return dealContext.Deals.ToList();
        }

        public void Save()
        {
            dealContext.SaveChanges();
        }

        public void UpdateDeal(Deal deal)
        {
            dealContext.Entry(deal).State = EntityState.Modified;
            Save();
        }
    }
}
