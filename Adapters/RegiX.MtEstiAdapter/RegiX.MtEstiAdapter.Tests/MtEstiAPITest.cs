using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegiX.Adapters.FileParameterStore;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.MtEstiAdapter.APIService;

namespace TechnoLogica.RegiX.MtEstiAdapter.Tests
{
    [TestClass]
    public class MtEstiAPITest : APITest<MtEstiAPI, IMtEstiAPI>
    {
        //public MtEstiAPITest()
        //{
        //    //AggregateCatalog catalog = new AggregateCatalog();
        //    //catalog.Catalogs.Add(new AssemblyCatalog(typeof(AdapterService.MtEstiAdapter).Assembly));
        //    //catalog.Catalogs.Add(new AssemblyCatalog(typeof(MtEstiAdapterTest).Assembly));
        //    //catalog.Catalogs.Add(new AssemblyCatalog(typeof(FileParameterStoreImplementation).Assembly));
        //    //CompositionContainer result = new CompositionContainer(catalog, true);
        //    //result.ComposeExportedValue(result);
        //    //Composition.CompositionContainer = result;
        //    //var res = Composition.CompositionContainer.GetExportedValue<IAPIService>(typeof(IMtEstiAPI).FullName);
        //}

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
