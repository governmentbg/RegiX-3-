using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegiX.Adapters.Mocks.Tests;
using RegiX.GraoNBDAdapter.Mock;
using RegiX.Processors.FOPResponseProcessor;
using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Threading;
using TechnoLogica.RegiX.Adapters.Mocks.Tests2;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.DummyAdapter;
using TechnoLogica.RegiX.GraoNBDAdapter.AdapterService;

namespace TechnoLogica.RegiX.Adapters.Mocks.Tests
{
    [TestClass]
    public class BaseAdapterServiceProxyTests
    {
        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(ResponseProcessor).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(NBDAdapterMock).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(NBDAdapter).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(BaseAdapterServiceProxyTests).Assembly));
            CompositionContainer result = new CompositionContainer(catalog, true);
            result.ComposeExportedValue(result);
            Composition.CompositionContainer = result;
        }


        [TestMethod]
        public void MultipleResolversTest()
        {
            new DummyTestAdapterServiceNETCoreMock();
            new DummyTestAdapterServiceNETCoreMock();
        }

        [TestMethod]
        public void AssureDataFolderFromDifferentAssemblies()
        {
            new DummyTestAdapterServiceNETCoreMock();
            new DummyTestAdapterServiceNETCoreMock2();
            Assert.IsFalse(DummyTestAdapterServiceNETCoreMock.DataFolder == DummyTestAdapterServiceNETCoreMock2.DataFolder);
        }

        [TestMethod]
        public void DummyTestAdapterServiceNETCoreMock_ExampleOperation()
        {
            var mock = new DummyTestAdapterServiceNETCoreMock().Create();
            mock.ExampleOperation("blah", null, new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters() { ReturnAccessMatrix = false, SignResult = false });
        }

        [TestMethod]
        public void DummyTestAdapterServiceNETCoreMock_ExampleOperation2()
        {
            var mock = new DummyTestAdapterServiceNETCoreMock().Create();
            mock.ExampleOperation2("blah", null, new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters() { ReturnAccessMatrix = false, SignResult = false });
        }

        [TestMethod]
        public void DummyTestAdapterServiceNETCoreMock_Augmentation()
        { 
            var mock = new DummyTestAdapterServiceNETCoreMock().Create();
            var result = mock.Augmented(new ExampleRequestType(), null, new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters() { ReturnAccessMatrix = false, SignResult = false });
            Assert.IsTrue(result.Data.Response.StringData == "Augmented");
        }

        [TestMethod]
        public void DummyTestAdapterServiceNETCoreMock_Execute()
        {
            var mock = new DummyTestAdapterServiceNETCoreMock().Create();
            var result = mock.Execute(
                new TechnoLogica.RegiX.Common.DataContracts.RequestWrapper()
                {
                    AccessMatrix = null,
                    Request = new TechnoLogica.RegiX.Common.TransportObjects.ServiceRequestData()
                    {
                        Operation = "RegiX.Adapters.Mocks.Tests.IDummyTestAdapterServiceNETCore.ExampleOperation"
                    },
                    AdditionalParameters = new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
                    {
                        ReturnAccessMatrix = false,
                        SignResult = false
                    }.XmlSerialize().ToXmlElement()
                });
            //Console.WriteLine(result.XmlSerialize());
        }

 //       [TestMethod]
        public void DummyTestAdapterServiceNETCoreMock_Execute_PDFProcessing()
        {
            var mock = NBDAdapterMock.MockExport;
            var result = mock.Execute(
                    new TechnoLogica.RegiX.Common.TransportObjects.ServiceRequestData()
                    {
                        Operation = "TechnoLogica.RegiX.GraoNBDAdapter.APIService.INBDAPI.RelationsSearch"
                    },
                    null,
                    new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
                    {
                        ReturnAccessMatrix = false,
                        SignResult = false,
                        ResponseProcessing =    RegiX.Common.TransportObjects.ResponseProcessing.TransformToPDF
                    }
                );
            //Console.WriteLine(result.XmlSerialize());
        }

        [TestMethod]
        public void DummyTestAdapterServiceNETCoreMock_ExecuteMultipleParameters()
        {
            var mock = new DummyTestAdapterServiceNETCoreMock().Create();
            var result = mock.Execute(
                new TechnoLogica.RegiX.Common.TransportObjects.ServiceRequestData()
                {
                    Operation = "RegiX.Adapters.Mocks.Tests.IDummyTestAdapterServiceNETCore.ExampleOperation"
                },
                null,
                new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
                {
                    ReturnAccessMatrix = false,
                    SignResult = false }
                );
            //Console.WriteLine(result.XmlSerialize());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DummyTestAdapterServiceNETCoreMock_ExecuteMultipleParameters_Decrypt()
        {
            var mock = new DummyTestAdapterServiceNETCoreMock().Create();
            var result = mock.Execute(
                new TechnoLogica.RegiX.Common.TransportObjects.ServiceRequestData()
                {
                    Operation = "RegiX.Adapters.Mocks.Tests.IDummyTestAdapterServiceNETCore.ExampleOperation",
                    RequestProcessing = TechnoLogica.RegiX.Common.TransportObjects.RequestProcessing.Decrypt
                },
                null,
                new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
                {
                    ReturnAccessMatrix = false,
                    SignResult = false
                }
                );
        }

        [TestMethod]
        public void DummyTestAdapterServiceNETCoreMock_CustomResponse()
        {
            var mock = new DummyTestAdapterServiceNETCoreMock().Create();
            var result = 
                mock.CustomResponse(
                    null, 
                    null, 
                    new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
                    {
                        ReturnAccessMatrix = false,
                        SignResult = false
                    }
                );
            //Console.WriteLine(result.XmlSerialize());
        }

        [TestMethod]
        public void DummyTestAdapterServiceNETCoreMock_AdapterServiceName()
        {
            var mock = new DummyTestAdapterServiceNETCoreMock().Create();
            var result = mock.AdapterServiceName;
            Assert.IsTrue(result == typeof(DummyTestAdapterServiceNETCoreMock).Name);
        }

        [TestMethod]
        public void DummyTestAdapterServiceNETCoreMock_AdapterServiceType()
        {
            var mock = new DummyTestAdapterServiceNETCoreMock().Create();
            var result = mock.AdapterServiceType;
            Assert.IsTrue(result == typeof(DummyTestAdapterServiceNETCoreMock));
        }

        [TestMethod]
        public void DummyTestAdapterServiceNETCoreMock_Ping()
        {
            var mock = new DummyTestAdapterServiceNETCoreMock().Create();
            byte[] byteArray = new byte[] { 1, 2, 3 };
            var result = mock.Ping(byteArray);
            Assert.IsTrue(result.Equals(byteArray));
        }

        [TestMethod]
        public void DummyTestAdapterServiceNETCoreMock_GetAdapterUptime()
        {
            var mock = new DummyTestAdapterServiceNETCoreMock().Create();
            Thread.Sleep(5);
            var result = mock.GetAdapterUptime();
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void DummyTestAdapterServiceNETCoreMock_GetSystemUptime()
        {
            var mock = new DummyTestAdapterServiceNETCoreMock().Create();
            var result = mock.GetSystemUptime();
            Assert.IsTrue(result > 0);
        }
    }
}
