using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.MPCriminalRecordsAdapter.APIService;

namespace TechnoLogica.RegiX.MPCriminalRecordsAdapter.Tests
{
    [TestClass]
    public class CriminalRecordsAPITest : APITest<CriminalRecordsAPI, ICriminalRecordsAPI>
    {
        public override void CreateSampleRequestUsingMetadataTest(string operationName)
        {
            //No metadata
            Assert.IsTrue(true);
        }

        public override void GetRequestXsltTest(string operationName)
        {
            //No xslt's
            Assert.IsTrue(true);
        }

        public override void GetResponseXsltTest(string operationName)
        {
            //No xslt's
            Assert.IsTrue(true);
        }
    }
}
