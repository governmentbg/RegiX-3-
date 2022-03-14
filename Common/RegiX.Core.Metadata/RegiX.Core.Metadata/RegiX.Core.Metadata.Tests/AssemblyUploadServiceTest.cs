using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegiX.Core.Metadata.Services;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.ReflectionModel;
using System.Linq;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.AVBulstat2Adapter.AdapterService;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.MVRBDSAdapter.AdapterService;
using TechnoLogica.RegiX.NHIFAdapter.AdapterService;

namespace RegiX.Core.Metadata.Tests
{
    [TestClass]
    public class AssemblyUploadServiceTest
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            var catalog = new AggregateCatalog();
            var result = new CompositionContainer(catalog, true);
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(MVRBDSAdapter).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(AVBulstat2Adapter).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(NHIFAdapter).Assembly));

            catalog.Catalogs.Add(new AssemblyCatalog(typeof(APITest<,>).Assembly));
            result.ComposeExportedValue(result);
            Composition.CompositionContainer = result;
        }

        [TestMethod]
        public void TestAssemblyUploadService()
        {
            //var adapterName = "RegiX.MVRBDSAdapter";
            var adapterName = "RegiX.NHIFAdapter";
            //var adapterName = "RegiX.AVBulstat2Adapter";

            var result =
                Composition
                    .CompositionContainer
                    .Catalog
                    .Parts
                    .Where(
                        p => p.ExportDefinitions.Any(
                                 e => e.ContractName == typeof(IAdapterService).FullName
                             ) && ReflectionModelServices.GetPartType(p).Value.Assembly.GetName().Name == adapterName)
                    .Select(ed => ReflectionModelServices.GetPartType(ed).Value)
                    .FirstOrDefault();

            var name = result?.Assembly.GetName().Name;
            var adapterData =
               new AssemblyInspectorService()
               .InspectAssembly(name);
        }
    }
}