using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOC.GEN.CTR.Logging.Logger.Contracts;
using SOC.GEN.DealService.Models;
using SOC.GEN.DealService.Repository;

namespace SOC.GEN.DealService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealController : ControllerBase
    {
        private readonly IDealRepository dealRepository;
        private readonly IStructuredLog structuredLog;

        public DealController(IDealRepository dealRepository, IStructuredLog structuredLog)
        {
            this.dealRepository = dealRepository;
            this.structuredLog = structuredLog;

            structuredLog.Information("DealController initialized");
        }
        // GET: api/Deal
        [HttpGet]
        public IActionResult Get()
        {
            var deals = dealRepository.GetDeals();
            return new OkObjectResult(deals);
        }

        // GET: api/Deal/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var deal = dealRepository.GetDealById(id);
            return new OkObjectResult(deal);

        }

        // PUT: api/Deal/5
        [HttpPut]
        public IActionResult Put([FromBody] Deal deal)
        {
            if (deal != null)
            {
                using (var scope = new TransactionScope())
                {
                    dealRepository.UpdateDeal(deal);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            dealRepository.DeleteDeal(id);
            return new OkResult();
        }
    }
}
