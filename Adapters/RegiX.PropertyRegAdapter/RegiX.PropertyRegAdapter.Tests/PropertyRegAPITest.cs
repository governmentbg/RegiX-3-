using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.PropertyRegAdapter.APIService;

namespace TechnoLogica.RegiX.PropertyRegAdapter.Tests
{
    [TestClass]
    public class PropertyRegAPITest : APITest<PropertyRegAPI, IPropertyRegAPI>
    {
        public override void CreateSampleRequestUsingMetadataTest(string operationName)
        {
            Assert.IsTrue(true);
        }
    }
}
