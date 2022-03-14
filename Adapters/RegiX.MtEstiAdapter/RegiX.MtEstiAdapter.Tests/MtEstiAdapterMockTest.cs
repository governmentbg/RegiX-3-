using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegiX.Adapters.FileParameterStore;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.MtEstiAdapter.AdapterService;
using TechnoLogica.RegiX.MtEstiAdapter.Mock;

namespace TechnoLogica.RegiX.MtEstiAdapter.Tests
{
    [TestClass]
    public class MtEstiAdapterMockTest : MockTest<MtEstiAdapterMock, IMtEstiAdapter>
    {
        public MtEstiAdapterMockTest()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(AdapterService.MtEstiAdapter).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(MtEstiAdapterTest).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(FileParameterStoreImplementation).Assembly));
            CompositionContainer result = new CompositionContainer(catalog, true);
            result.ComposeExportedValue(result);
            Composition.CompositionContainer = result;
        }
    }
}

