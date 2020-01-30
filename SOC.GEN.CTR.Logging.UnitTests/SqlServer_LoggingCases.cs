using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SOC.GEN.CTR.Common;
using SOC.GEN.CTR.Logging.Logger.Contracts;
using SOC.GEN.CTR.Logging.Logger.FlatFileLogger;
using SOC.GEN.CTR.Logging.Logger.SqlServerLogger;
using System;

namespace SOC.GEN.CTR.Logging.UnitTests
{
    [TestClass]
    public class SqlServer_LoggingCases
    {
        private static IServiceCollection _service;
        private static IDatabaseLogger structuredLogger;

        private static IServiceCollection Service
        {
            get
            {
                if (_service == null)
                {
                    _service = new ServiceCollection();
                    _service.AddSingleton<IDatabaseLogger, SqlServerLogger>();
                }
                return _service;
            }
        }
        private static T LoadDependencies<T>()
        {
            Utilities.services = Service;
            return Utilities.GetInstance<T>();
        }

        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            if (structuredLogger == null)
            {
                structuredLogger = LoadDependencies<IDatabaseLogger>();
            }
        }

        [TestMethod]
        public void SqlServerLogging_Test_DebugLog()
        {
            structuredLogger.Debug(null, "Debug - This is test message from LoggerCases Test class- function: SqlServerLogging_Test_DebugLog");
        }

        [TestMethod]
        public void SqlServerLogging_Test_InformationLog()
        {
            structuredLogger.Information("Informaation - This is test message from LoggerCases Test class- function: SqlServerLogging_Test_InformationLog");
        }

        [TestMethod]
        public void SqlServerLogging_Test_WarningLog()
        {
            structuredLogger.Warning("Warning - This is test message from LoggerCases Test class- function: SqlServerLogging_Test_WarningLog");
        }

        [TestMethod]
        public void SqlServerLogging_Test_FatalLog()
        {
            structuredLogger.Fatal("Fatal - This is test message from LoggerCases Test class- function: SqlServerLogging_Test_FatalLog");
        }

        [TestMethod]
        public void SqlServerLogging_Test_ErrorLog()
        {
            structuredLogger.Error("Error - This is test message from LoggerCases Test class- function: SqlServerLogging_Test_ErrorLog");
        }

        [TestMethod]
        public void SqlServerLogging_Test_ErrorLog_CustomProperty()
        {
            var prop = new { ErrorMessage = "This is test message from LoggerCases Test class", FuntionName = "SqlServerLogging_Test_ErrorLog_CustomProperty" };
            structuredLogger.Error("Error - {ErrorMessage}- function: {FunctionName} ", prop.ErrorMessage, prop.FuntionName);
        }
    }
}
