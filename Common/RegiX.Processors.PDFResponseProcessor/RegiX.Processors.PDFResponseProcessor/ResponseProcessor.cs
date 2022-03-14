using EO.Pdf;
using RegiX.Processors.PDFResponseProcessor;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;
using TechnoLogica.RegiX.Adapters.Common.Interfaces;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common.Utils;

namespace RegiX.Processors.FOPResponseProcessor
{
    public static class TransformationUtil
    {
        public static string TransformServiceResultFromDatabase(this string serviceResultXmlString, string xslt)
        {
            XslCompiledTransform transformation = new XslCompiledTransform();
            XmlReader xmlReader = XmlReader.Create(new StringReader(xslt));

            transformation.Load(xmlReader);

            XmlReader serviceResultXmlReader = new XmlTextReader(new StringReader(serviceResultXmlString));
            Stream transformedHtmlStream = new MemoryStream();
            transformation.Transform(serviceResultXmlReader, new XsltArgumentList(), transformedHtmlStream);
            transformedHtmlStream.Position = 0;
            serviceResultXmlReader.Close();

            StreamReader reader = new StreamReader(transformedHtmlStream);
            string transformedResult = reader.ReadToEnd();

            return transformedResult;
        }
    }

    [Export(nameof(ResponseProcessing.TransformToPDF), typeof(IResponseProcessor))]
    public class ResponseProcessor : IResponseProcessor
    {
        [Import]
        public ISigner Signer { get; set;}

        [ImportingConstructor]
        public ResponseProcessor([Import] IEOPdfLicenseKeyResolver keyResolver)
        {
            Runtime.AddLicense(keyResolver.LicenseKey);
        }

        public ServiceResultData ProcessResponse(ServiceResultData result, AdapterAdditionalParameters additionalParameters)
        {
            if (additionalParameters.ResponseProcessing.HasFlag(ResponseProcessing.TransformToPDF))
            {
                var apiServiceInterface = additionalParameters.ProcessingData.First(pd => pd.Key == "APIServiceInterface").Value.Deserialize<string>();
                var apiServiceOperation = additionalParameters.ProcessingData.First(pd => pd.Key == "OperationName").Value.Deserialize<string>();
                var apiService = Composition.CompositionContainer.GetExportedValue<IAPIService>(apiServiceInterface);
                var xsltRequest = apiService.GetRequestXslt(apiServiceOperation);
                var xsltResponse = apiService.GetResponseXslt(apiServiceOperation);

                string htmlResponse = result.Data.Response.Response.OuterXml.TransformServiceResultFromDatabase(xsltResponse);
                string htmlRequest = result.Data.Request.Request.OuterXml.TransformServiceResultFromDatabase(xsltRequest);
                string htmlAdditionalData = 
                    "<html><body>"+
                    $"<h4>Дата на изпълнение: {DateTime.Now: dd.MM.yyyy HH:mm:ss}</h4>" +
                    $"<h4>Номер на заявка в RegiX: {additionalParameters.ApiServiceCallId}</h4>"+
                    "</html></body>";
                using (MemoryStream ms = new MemoryStream())
                {
                    HtmlToPdf.ConvertHtml(htmlResponse + htmlRequest + htmlAdditionalData, ms);
                    ms.Position = 0;

                    var signedPDF = Signer.SignPDF(ms.ToArray());

                    result.Data.Response.Response = 
                        new BinaryArgument() 
                        {
                            Binary = signedPDF
                        }
                        .XmlSerialize()
                        .ToXmlElement();
                }
                return result;
            }
            else
            {
                throw new NotImplementedException("EncryptedResponsetProcessor only handles response with Encrypt flag");
            }
        }
    }
}
