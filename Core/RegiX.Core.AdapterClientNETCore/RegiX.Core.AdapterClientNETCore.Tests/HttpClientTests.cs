using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Text;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Core.AdapterClientNETCore;
using TechnoLogica.RegiX.Core.Data.Interfaces;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Core.Interfaces;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.DummyAdapter;

namespace RegiX.Core.AdapterClientNETCore.Tests
{
    public interface IAdapterServiceNETCore1 : IAdapterServiceNETCore
    {
        CommonSignedResponse<ExampleRequestType, ExampleResponse> ExampleOperation(ExampleRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }

   // [TestClass]
    public class HttpClientTests
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(HttpClientTests).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(HttpClientFactory<>).Assembly));
            CompositionContainer result = new CompositionContainer(catalog);

            var regiXData = new Mock<IRegiXData>();
            regiXData.Setup(a => a.GetBindingInfo(It.IsAny<string>())).Returns<string>((t) =>
            {
                var item = new Mock<IRegisterBindingInfo>();
                item
                    .Setup(i => i.AdapterURL)
                    .Returns("http://localhost:5000/DummyAdapter/");
                return item.Object;
            });

            result.ComposeExportedValue(regiXData.Object);

            var res = regiXData.Object.GetBindingInfo("whaterver");

            result.ComposeExportedValue(result);

            CompositionContainer = result;
        }

        public static CompositionContainer CompositionContainer { get; set; }
        
        public IAdapterServiceNETCore1 Channel
        {
            get
            {
                return CompositionContainer.GetExportedValue<IRegisterChannelFacotry<IAdapterServiceNETCore1>>().CreateChannel();
            }
        }

        [TestMethod]
        public void ExecuteTest()
        {
            RequestWrapper request = GetRequest();
            var resultObject = Channel.Execute(request);
            Console.WriteLine(resultObject.XmlSerialize());
        }

        private static RequestWrapper GetRequest()
        {
            return new RequestWrapper()
            {
                Request = new TechnoLogica.RegiX.Common.TransportObjects.ServiceRequestData()
                {
                    Argument = @" <ExampleRequest xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns=""http://egov.bg/RegiX/Dummy/ExampleRequest"">
        <Identifier>3</Identifier>
      </ExampleRequest>".ToXmlElement(),
                    Operation = "RegiX.DummyDotNetCoreSimpleAdapter.Controllers.IDummyDotNetCoreSimple.ExampleOperation"
                },
                AdditionalParameters = (new AdapterAdditionalParameters() { CitizenEGN = "7" }).XmlSerialize().ToXmlElement()
            };
        }

        [TestMethod]
        public void GetAdapterVersionTest()
        {
            var resultObject = Channel.GetAdapterVersion();
            Console.WriteLine(resultObject.XmlSerialize());
        }

        [TestMethod]
        public void GetParametersTest()
        {
            var resultObject = Channel.GetParameters();
            Console.WriteLine(resultObject.XmlSerialize());
        }

        [TestMethod]
        public void GetHealthCheckFunctionsTest()
        {
            var resultObject = Channel.GetHealthCheckFunctions();
            Console.WriteLine(resultObject.XmlSerialize());
        }

        [TestMethod]
        public void GetAdapterUptimeTest()
        {
            var resultObject = Channel.GetAdapterUptime();
            Console.WriteLine(resultObject.XmlSerialize());
        }

        [TestMethod]
        public void CheckHealthFunctionTest()
        {
            var resultObject = Channel.CheckHealthFunction("GetHostMachineInfo");
            Console.WriteLine(resultObject.XmlSerialize());
        }

        [TestMethod]
        public void CheckRegisterConnectionTest()
        {
            var resultObject = Channel.CheckRegisterConnection();
            Console.WriteLine(resultObject.XmlSerialize());
        }

        [TestMethod]
        public void GetHostMachineInfoTest()
        {
            var resultObject = Channel.GetHostMachineInfo();
            Console.WriteLine(resultObject.XmlSerialize());
        }

        [TestMethod]
        public void PingTest()
        {
            var resultObject = Channel.Ping(new byte[] { 1,2,3 });
            Console.WriteLine(resultObject.XmlSerialize());
        }

        [TestMethod]
        public void ExampleOperationTest()
        {
            var request = 
                @" <ExampleRequest xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns=""http://egov.bg/RegiX/Dummy/ExampleRequest"">
                    <Identifier>3</Identifier>
                   </ExampleRequest>".XmlDeserialize<ExampleRequestType>();
            var resultObject = Channel.ExampleOperation(request, AccessMatrix.CreateForType(typeof(ExampleRequestType)), new AdapterAdditionalParameters() {  });
            Console.WriteLine(resultObject.XmlSerialize());
        }
    
    }
}
