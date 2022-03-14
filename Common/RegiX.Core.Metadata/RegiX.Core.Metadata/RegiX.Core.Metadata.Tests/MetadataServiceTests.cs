using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RegiX.Core.Metadata.Services;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Core.Data.Interfaces;
using TechnoLogica.RegiX.MVRBDSAdapter.AdapterService;
using TechnoLogica.RegiX.GraoLEAdapter.AdapterService;

namespace RegiX.Core.Metadata.Tests
{
    [TestClass]
    public class MetadataServiceTests
    {
        private MetadataService service;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {

            AggregateCatalog catalog = new AggregateCatalog();
            CompositionContainer result = new CompositionContainer(catalog, true);
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(MVRBDSAdapter).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(LEAdapter).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(APITest<,>).Assembly));

            Mock<IRegiXData> regiXDataMock = new Mock<IRegiXData>();
            regiXDataMock.Setup(c => c.GetAllAdapters()).Returns(GetAdaptersAssemblyNames());
            result.ComposeExportedValue(regiXDataMock.Object);

            catalog.Catalogs.Add(new AssemblyCatalog(typeof(IRegiXData).Assembly));

            result.ComposeExportedValue(result);
            Composition.CompositionContainer = result;
        }

        [TestInitialize]
        public void Init()
        {
            service = new MetadataService();
        }
        private static IEnumerable<IAdapterVersion> GetAdaptersAssemblyNames()
        {
            var adapters = new List<IAdapterVersion>();

            adapters.Add(new AdapterVersion
            {
                AdapterName = "RegiX.ZADSAdapter",
                AdapterAssembly = "RegiX.ZADSAdapter.dll"

            });

            adapters.Add(new AdapterVersion
            {
                AdapterName = "RegiX.AZJobsAdapter",
                AdapterAssembly = "RegiX.AZJobsAdapter.dll"

            });

            adapters.Add(new AdapterVersion
            {
                AdapterName = "RegiX.AVBulstatAdapter",
                AdapterAssembly = "RegiX.AVBulstatAdapter.dll"

            });

            adapters.Add(new AdapterVersion
            {
                AdapterName = "RegiX.MVRBDSAdapter",
                AdapterAssembly = "RegiX.MVRBDSAdapter.dll",
                VersionOfAdapter = "1.0.2.0"


            });

            return adapters;


        }

        [TestMethod]
        public void GetRegisteredAdaptersTest()
        {
            var res2 = service.GetRegisteredAdapters();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GetFullAdapterInformationTest()
        {
            var res2 = service.GetFullAdapterInformation("RegiX.MVRBDSAdapter 1.0.1.0");
            Assert.IsTrue(true);
        }


        [TestMethod]
        public void GetNotRegisteredAdaptersTest()
        {
            var res = service.GetNotRegisteredAdapters();
            Assert.IsTrue(true);

        }

        [TestMethod]
        public void GetRegisteredAdaptersWithDiffVersionsTest()
        {
            var res1 = service.GetRegisteredAdaptersWithDiffVersions();
            Assert.IsTrue(true);
        }


        [TestMethod]
        public void GetAdaptersInfoTest()
        {
            //var id = typeof(IMVRBDSAPI).FullName;
            var res1 = service.GetAdaptersInfo();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GetAllAdapterData()
        {
            var name = "RegiX.MVRBDSAdapter";
            var res1 = service.GetAllAdapterData(name);
            Assert.IsTrue(true);
        }
    }
}
