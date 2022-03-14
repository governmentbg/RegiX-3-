using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Common;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace RegiX.Adapters.Common.Tests
{
    [TestClass]
    public class BaseAPIServiceTests
    {
        private static readonly ILog log = 
            log4net.LogManager.GetLogger(typeof(BaseAPIServiceTests));

        public BaseAPIServiceTests()
        {
        }

        [TestMethod]
        public void logtest()
        {
            string val = SystemInfo.EntryAssemblyLocation;
            //string val2 = System.AppDomain.CurrentDomain.SetupInformation.ConfigurationFile
            Console.WriteLine(val);

            log.Debug("blah");
        }

        [TestMethod]
        public void GetRequestTest()
        {
            var res = 
                new ImplementationAPI()
                {
                    BinDirectoryLocator = new BinDirectoryLocator()
                }.GetRequestXSD(nameof(IImplementAPI.Operation));
        }

    }

    public class BinDirectoryLocator : IBinDirectoryLocator
    {
        public string GetBinDirectory()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }

    public interface IImplementAPI : IAPIService
    {
        [Info(requestXSD:"Request.xsd")]
        void Operation();
    }

    public class ImplementationAPI : BaseAPIService<IImplementAPI>, IImplementAPI
    {
        public void Operation()
        {
            throw new NotImplementedException();
        }
    }
}
