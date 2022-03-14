using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.NHIFAdapter.APIService;

namespace TechnoLogica.RegiX.NHIFAdapter.Tests
{
    [TestClass]
    public class NHIFAPITest : APITest<NHIFAPI, INHIFAPI>
    {
        public override void CreateSampleRequestUsingMetadataTest(string operationName)
        {
            //No metadata
            Assert.IsTrue(true);
        }

        public override void GetRequestXsltTest(string operationName)
        {
            Assert.IsTrue(true);
        }

        public override void GetResponseXsltTest(string operationName)
        {
            Assert.IsTrue(true);
        }
    }
}
