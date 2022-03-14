using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.Utils;

namespace RegiX.Adapters.Common.Tests
{
    [TestClass]
    public class ConfigurationUtilsTests
    {
        [TestMethod]
        public void GetSignResponse()
        {
            var location = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Assert.IsFalse(ConfigurationUtils.GetSignResponse());
        }
    }
}
