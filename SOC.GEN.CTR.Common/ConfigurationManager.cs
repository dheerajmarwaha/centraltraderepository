using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace SOC.GEN.CTR.Common
{
    public class ConfigurationManager
    {
        private static IConfiguration _configuration;
        private static ConfigurationManager _configurationManager = new ConfigurationManager();

        private ConfigurationManager()
        {
            var builder = new ConfigurationBuilder()
                               .SetBasePath(Directory.GetCurrentDirectory())
                               .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
        }

        public static IConfiguration Configuration
        {
            get
            {
                return _configuration;
            }
        }
    }
}
