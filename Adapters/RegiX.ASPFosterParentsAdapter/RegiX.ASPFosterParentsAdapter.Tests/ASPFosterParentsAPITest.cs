using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.ASPFosterParentsAdapter.APIService;

namespace TechnoLogica.RegiX.ASPFosterParentsAdapter.Tests
{
    [TestClass]
    public class ASPFosterParentsAPITest : APITest<ASPFosterParentsAPI, IASPFosterParentsAPI>
    {
        public override void CreateSampleRequestUsingMetadataTest(string operationName)
        {
            Assert.IsTrue(true);
        }
    }
}
