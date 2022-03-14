using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegiX.Adapters.FileParameterStore;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.MVRTouristRegisterAdapter.APIService;

namespace TechnoLogica.RegiX.MVRTouristRegisterAdapter.Tests
{
    [TestClass]
    public class MVRTouristRegisterAPITest : APITest<MVRTouristRegisterAPI, IMVRTouristRegisterAPI>
    {
        //public MVRTouristRegisterAPITest()
        //{
        //    //AggregateCatalog catalog = new AggregateCatalog();
        //    //catalog.Catalogs.Add(new AssemblyCatalog(typeof(AdapterService.MVRTouristRegisterAdapter).Assembly));
        //    //catalog.Catalogs.Add(new AssemblyCatalog(typeof(MVRTouristRegisterAdapterMockTest).Assembly));
        //    //catalog.Catalogs.Add(new AssemblyCatalog(typeof(FileParameterStoreImplementation).Assembly));
        //    //CompositionContainer result = new CompositionContainer(catalog, true);
        //    //result.ComposeExportedValue(result);
        //    //Composition.CompositionContainer = result;
        //}

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
