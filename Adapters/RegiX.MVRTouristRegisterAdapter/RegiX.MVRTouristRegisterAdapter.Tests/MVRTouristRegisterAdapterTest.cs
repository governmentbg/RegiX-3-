using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegiX.Adapters.FileParameterStore;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.MVRTouristRegisterAdapter.AdapterService;

namespace TechnoLogica.RegiX.MVRTouristRegisterAdapter.Tests
{
    [TestClass]
    public class MVRTouristRegisterAdapterTest : AdapterTest<AdapterService.MVRTouristRegisterAdapter, IMVRTouristRegisterAdapter>
    {
        public MVRTouristRegisterAdapterTest()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(AdapterService.MVRTouristRegisterAdapter).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(MVRTouristRegisterAdapterMockTest).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(FileParameterStoreImplementation).Assembly));
            CompositionContainer result = new CompositionContainer(catalog, true);
            result.ComposeExportedValue(result);
            Composition.CompositionContainer = result;
        }
	}
}
