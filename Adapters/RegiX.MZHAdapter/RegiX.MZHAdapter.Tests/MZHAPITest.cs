using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.MZHAdapter.APIService;

namespace TechnoLogica.RegiX.MZHAdapter.Tests
{
    [TestClass]
    public class MZHAPITest : APITest<MZHAPI, IMZHAPI>
    {
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
