using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC.GEN.DealService.Models
{
    public class Deal
    {
        public int Id { get; set; }
        public DateTime deal_date { get; set; }
        public int country_id { get; set; }
        public int currency_Id { get; set; }
        public decimal amount { get; set; }
        public string trader { get; set; }
        public int asset_Id { get; set; }
    }
}
