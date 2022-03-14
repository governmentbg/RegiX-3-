using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using TechnoLogica.RegiX.Adapters.LogstashLogger;

namespace RegiX.Adapters.LogstashLogger.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [ClassInitialize]
        public static void UnitTest1Initialize(TestContext context)
        {
            ConfigurationManager.AppSettings["LoggingAddress"] = "http://localhost:8080/";
        }
        [TestMethod]
        public void TestMethod1()
        {
            //var logger = new LogstashAdapterLogger();
            //logger.LogRecord("test", new TechnoLogica.RegiX.Adapters.Common.DataContracts.AdapterLogRecordType()
            //{
            //    ApiServiceCallId = 1
            //});

            var res = ConfigurationManager.AppSettings["LoggingAddress"];

        }
    }
}
