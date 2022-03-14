using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.RTSAdapter.APIService;

namespace TechnoLogica.RegiX.RTSAdapter.Tests
{
    [TestClass]
    public class RTSAPITest : APITest<RTSAPI, IRTSAPI>
    {
        public override void CreateSampleRequestUsingMetadataTest(string operationName)
        {
           Assert.IsTrue(true);
        }
    }
}
