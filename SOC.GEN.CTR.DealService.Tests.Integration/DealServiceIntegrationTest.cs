using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using SOC.GEN.DealService;
using SOC.GEN.DealService.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xunit;

namespace SOC.GEN.CTR.DealService.Tests.Integration
{
    public class DealServiceIntegrationTest
    {
        private readonly TestServer testServer;
        private readonly HttpClient httpClient;

        public DealServiceIntegrationTest()
        {
            testServer = new TestServer(new WebHostBuilder()
                                        .UseStartup<Startup>());
            httpClient = testServer.CreateClient();
        }
        [Fact]
        public async void DealService_GetAllTestCase()
        {
            var getResponse = await httpClient.GetAsync("/api/deal");
            getResponse.EnsureSuccessStatusCode();

            string raw = await getResponse.Content.ReadAsStringAsync();
            List<Deal> lstDeal =
                JsonConvert.DeserializeObject<List<Deal>>(raw);

            Assert.Equal(2, lstDeal.Count);
        }
    }
}
