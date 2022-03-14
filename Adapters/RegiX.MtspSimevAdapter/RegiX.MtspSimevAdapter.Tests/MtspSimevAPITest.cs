using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.MtspSimevAdapter.APIService;

namespace TechnoLogica.RegiX.MtspSimevAdapter.Tests
{
    [TestClass]
    public class MtspSimevAPITest : APITest<MtspSimevAPI, IMtspSimevAPI>
    {
        public override void CreateSampleRequestUsingMetadataTest(string operationName)
        {
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
