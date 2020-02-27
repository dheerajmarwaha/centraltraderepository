using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SOC.GEN.CTR.Common;
using SOC.GEN.CTR.Logging.Logger.Contracts;
using SOC.GEN.CTR.Logging.Logger.FlatFileLogger;
using SOC.GEN.DealService.Controllers;
using SOC.GEN.DealService.DBContexts;
using SOC.GEN.DealService.Models;
using SOC.GEN.DealService.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using Xunit;

namespace SOC.GEN.CTR.DealServiceTest
{
    public class DealController_TestCases
    {
        private static IServiceCollection _service;
        private static IFlatFileLogger structuredLogger;
        private static IServiceCollection Service
        {
            get
            {
                if (_service == null)
                {
                    _service = new ServiceCollection();
                    _service.AddSingleton<IFlatFileLogger, FlatFileLogger>();
                    _service.AddDbContext<DealContext>(o => o.UseSqlServer(
                                                        ConfigurationManager.Configuration["CentralRepositoryDB"]));
                }
                return _service;
            }
        }

        private static T LoadDependencies<T>()
        {
            Utilities.services = Service;
            return Utilities.GetInstance<T>();
        }

        [Fact]
        public void DealController_GetAllTestCase()
        {
            DealContext dbContext = LoadDependencies<DealContext>();
            var mockRepo = new DealRepository(dbContext);
            var logger = new FlatFileLogger();
            var controller = new DealController(mockRepo, logger);
            var result = controller.Get();

            Assert.NotNull(result);
            var lstDeal = Assert.IsAssignableFrom<IList<Deal>>((result as OkObjectResult).Value as IList<Deal>);
            Assert.Equal(2, lstDeal.Count);
        }

        [Fact]
        public void DealController_GetDealTestCase()
        {
            DealContext dbContext = LoadDependencies<DealContext>();
            var mockRepo = new DealRepository(dbContext);
            var logger = new FlatFileLogger();
            var controller = new DealController(mockRepo, logger);
            var result = controller.GetDealsByCountryId(1);

            Assert.NotNull(result);
            var deal = Assert.IsAssignableFrom<Deal>((result as OkObjectResult).Value as Deal);
            Assert.Equal(1, deal.country_id);
        }
    }
}
