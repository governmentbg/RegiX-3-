using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegiX.Processors.PDFResponseProcessor;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.MVRBDSAdapter.AdapterService;
using TechnoLogica.RegiX.MVRBDSAdapter.APIService;

namespace RegiX.Processors.FOPResponseProcessor.Test
{
    public class MockEOPdfLicenseKeyResolver : IEOPdfLicenseKeyResolver
    {
        public string LicenseKey =>
            "####";
    }

    [TestClass]
    public class UnitTest1
    {

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(IMVRBDSAdapter).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(APITest<, >).Assembly));
            CompositionContainer result = new CompositionContainer(catalog, true);
            result.ComposeExportedValue(result);
            Composition.CompositionContainer = result;
        }

        [TestMethod]
        public void TestMethod1()
        {
            var res = Composition.CompositionContainer.GetExportedValues<IAPIService>();

            var result = 
                new ResponseProcessor(new MockEOPdfLicenseKeyResolver()).ProcessResponse(
                    new ServiceResultData()
                    {
                        Data = new TechnoLogica.RegiX.Common.DataContracts.DataContainer()
                        {
                            Response = new TechnoLogica.RegiX.Common.DataContracts.ResponseContainer()
                            {
                                Response = File.ReadAllText("IMVRBDSAdapter.GetPersonalIdentity.response.xml").ToXmlElement()
                            }
                        }
                    },
                    new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
                    {
                        ResponseProcessing = ResponseProcessing.TransformToPDF,
                        ProcessingData = new System.Collections.Generic.List<TechnoLogica.RegiX.Common.DataContracts.ProcessingDataEntry>()
                        {
                            new TechnoLogica.RegiX.Common.DataContracts.ProcessingDataEntry()
                            {
                                 Key = "APIServiceInterface",
                                 Value = "TechnoLogica.RegiX.MVRBDSAdapter.APIService.IMVRBDSAPI".XmlSerialize().ToXmlElement()
                            },
                            new TechnoLogica.RegiX.Common.DataContracts.ProcessingDataEntry()
                            {
                                 Key = "OperationName",
                                 Value = "GetPersonalIdentity".XmlSerialize().ToXmlElement()
                            },
                        }
                    });
            var binaryArgument = result.Data.Response.Response.Deserialize<BinaryArgument>();
            File.WriteAllBytes("Result.pdf", binaryArgument.Binary);
        }
    }
}
