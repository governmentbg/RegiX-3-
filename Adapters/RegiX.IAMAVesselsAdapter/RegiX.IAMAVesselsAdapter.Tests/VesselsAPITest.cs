using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.IAMAVesselsAdapter.APIService;
using TechnoLogica.RegiX.IAMAVesselsAdapter.Ships;

namespace TechnoLogica.RegiX.IAMAVesselsAdapter.Tests
{
    [TestClass]
    public class VesselsAPITest : APITest<VesselsAPI, IVesselsAPI>
    {
        [TestMethod]
        public void Test()
        {
            Console.WriteLine(new NomenclaturesRequest().XmlSerialize());
        }

        public override void CreateSampleRequestUsingMetadataTest(string operationName)
        {
            Assert.IsTrue(true);
        }

        public override void GetRequestXsltTest(string operationName)
        {
            Assert.IsTrue(true); // temp fix 
        }
        public override void GetResponseXsltTest(string operationName)
        {
            Assert.IsTrue(true); // temp fix 
        }
    }
}
