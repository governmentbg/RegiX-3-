using RegiX.Processors.FOPResponseProcessor;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.BaseSigner;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.MFANotariesAdapter.AdapterService;
using TechnoLogica.RegiX.MFANotariesAdapter.APIService;
using TechnoLogica.RegiX.MFANotariesAdapter.Helpers;
using TechnoLogica.RegiX.SecureBlackBox.CertFinder.WinStore;
using TechnoLogica.RegiX.SecureBlackBoxSigner;

namespace TechnoLogica.RegiX.MFANotariesAdapter.Integration
{
    /// <summary>
    /// Utility for preparing ServiceResultData and BinaryArgument response manipulation
    /// </summary>
    public static class Util
    {
        /// <summary>
        /// Prepares the Composition container used as DI throughout the packages
        /// </summary>
        /// <param name="binDirectoryPath">Path of the bin directory. Shoule be HttpRuntime.BinDirectory or AppDomain.CurrentDomain.BaseDirectory</param>
        public static void Initialize(string binDirectoryPath, bool provideExternalCertificateFinder = false)
        {
            BinDirectoryLocator.BIN_DIRECTORY = binDirectoryPath;
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Signer).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(ABaseSigner).Assembly));
            if (!provideExternalCertificateFinder)
            {
                catalog.Catalogs.Add(new AssemblyCatalog(typeof(CertificateFinder).Assembly));
            }
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(ResponseProcessor).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(BaseAdapterService).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Composition).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Util).Assembly));
            catalog.Catalogs.Add(
                new TypeCatalog(
                    typeof(AdapterService.MFANotariesAdapter), 
                    typeof(MFANotariesAPI)
                )
            );
            CompositionContainer result = new CompositionContainer(catalog, true);
            result.ComposeExportedValue(result);
            Composition.CompositionContainer = result;
        }

        /// <summary>
        /// Prepare the result using the provided raw request and response
        /// </summary>
        /// <param name="rawRequest">Raw request</param>
        /// <param name="response">Response</param>
        /// <returns>Serialized ServiceRestultData</returns>
        public static string PrepareResult(string rawRequest, string rawResponse)
        {
            SendNotaryDocumentsResponse response = rawResponse.XmlDeserialize<SendNotaryDocumentsResponse>();
            OperationRequest operationRequest = rawRequest.XmlDeserialize<OperationRequest>();

            var notaryAdapter = Composition.CompositionContainer.GetExportedValue<IAdapterService>(typeof(AdapterService.MFANotariesAdapter).FullName) as AdapterService.MFANotariesAdapter;
            var singedResult = SigningUtils.CreateAndSign(operationRequest.Request, response, operationRequest.AccessMatrix, operationRequest.AdapterAdditionalParameters, operationRequest.AdapterAdditionalParameters.ResponseProcessing == 0);
            var serviceResultData = notaryAdapter.PrepareResult(singedResult, operationRequest.AdapterAdditionalParameters);
            return serviceResultData.XmlSerialize();
        }
        
        /// <summary>
        /// Extracts the PDF's binary from the unsigned result
        /// </summary>
        /// <param name="rawUnsignedResult">Unsigned result</param>
        /// <returns>Extracted PDF</returns>
        public static byte[] ExtractPDFResponse(string rawUnsignedResult)
        {
            var serviceResultData = rawUnsignedResult.XmlDeserialize<ServiceResultData>();
            return serviceResultData.Data.Response.Response.Deserialize<BinaryArgument>().Binary;
        }

        /// <summary>
        /// Replaces the unsigned PDF with the provided one (should be signed by operator)
        /// </summary>
        /// <param name="rawUnsignedResult">Unsigned result</param>
        /// <param name="signedPDFResult">Signed PDF</param>
        /// <returns>Replaced content in the result</returns>
        public static string ReplaceResponse(string rawUnsignedResult, byte[] signedPDFResult)
        {
            var serviceResultData = rawUnsignedResult.XmlDeserialize<ServiceResultData>();
            serviceResultData.Data.Response.Response = new BinaryArgument() { Binary = signedPDFResult }.XmlSerialize().ToXmlElement();
            return serviceResultData.XmlSerialize();
        }
    }
}
