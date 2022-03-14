//using System;
//using System.ComponentModel.Composition;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;
//using System.Xml;
//using System.Xml.Linq;
//using TechnoLogica.RegiX.Common;
//using TechnoLogica.RegiX.Common.AdapterCore;
//using TechnoLogica.RegiX.Common.DataContracts;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.Common.ServiceContracts;
//using TechnoLogica.RegiX.Common.TransportObject;
//using TechnoLogica.RegiX.Common.Utils;
//using TechnoLogica.RegiX.WebServiceAdapterService;
//namespace TechnoLogica.RegiX.NRAObligatedPersonsAdapter.AdapterService
//{
//    public class NRAObligatedPersonsAdapter : RestServiceBaseAdapterService, INRAObligatedPersonsAdapter, IAdapterService
//    {
//        [Export(typeof(ParameterInfo))]
//        [ExportFullName(typeof(NRAObligatedPersonsAdapter), typeof(ParameterInfo))]
//        public static ParameterInfo<string> WebServiceUrl =
//           new ParameterInfo<string>("http://regix2-adapters.regix.tlogica.com/MockRegisters/RegiX.Mockup.NRA/NRAObligatedPersonsService.svc/GetObligatedPerson")
//           {
//               Key = Constants.WebServiceUrlParameterKeyName,
//               Description = "Web Service Url with method name",
//               OwnerAssembly = typeof(NRAObligatedPersonsAdapter).Assembly
//           };

//        private async Task<string> GetResponse(HttpClient serviceClient, string argument, Guid id, AdapterAdditionalParameters aditionalParameters)
//        {
//            XmlDocument doc = new XmlDocument();
//            doc.InnerXml = argument;
//            HttpResponseMessage response = await serviceClient.PostAsXmlAsync("", doc.DocumentElement);
//            if (response.IsSuccessStatusCode)
//            {
//                return await response.Content.ReadAsStringAsync();
//            }
//            else
//            {
//                string content = await response.Content.ReadAsStringAsync();
//                LogData(aditionalParameters, new { NotSuccessfulResponse = response, Content = content, Guid = id });
//                throw new Exception("StatusCode: " + response.StatusCode + "; Content: " + content);
//            }
//        }

//        private string GetRequest(ObligationRequest argument)
//        {
//            ServiceXMLShemas.ObligationRequest param = new ServiceXMLShemas.ObligationRequest();
//            param.Identity = new ServiceXMLShemas.IdentityType();
//            param.Identity.ID = argument.Identity.ID;
//            param.Identity.TYPE = (EikTypeType)Enum.Parse(typeof(EikTypeType), argument.Identity.TYPE.ToString());
//            param.Threshold = argument.Threshold;
//            param.ThresholdSpecified = argument.ThresholdSpecified;
//            return param.XmlSerialize();
//        }

//        public CommonSignedResponse<ObligationRequest, ObligationResponse> GetObligatedPersons(ObligationRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                var serviceClient = new HttpClient();
//                serviceClient.BaseAddress = new Uri(WebServiceUrl.Value);
//                serviceClient.DefaultRequestHeaders.Accept.Clear();
//                serviceClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

//                string request = GetRequest(argument);
//                string responseString = GetResponse(serviceClient, request, id, aditionalParameters).Result;
//                XElement resultXmlElement = XDocument.Parse(responseString).Root;

//                XPathMapper<ObligationResponse> responseMapper = CreateObligatedPersonsMapper(accessMatrix);
//                ObligationResponse response = new ObligationResponse();
//                responseMapper.Map(resultXmlElement, response);

//                return
//                    SigningUtils.CreateAndSign(
//                        argument,
//                        response,
//                        accessMatrix,
//                        aditionalParameters
//                    );
//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

//        private static XPathMapper<ObligationResponse> CreateObligatedPersonsMapper(AccessMatrix accessMatrix)
//        {
//            XPathMapper<ObligationResponse> mapper =
//                new XPathMapper<ObligationResponse>(accessMatrix);


//            mapper.AddFunctionMap<string>(p => p.Identity.ID, node =>
//            {
//                var identityNode = node.SelectSingleNode("./*[local-name()='ObligationResponse']/*[local-name()='Identity']");

//                if (identityNode != null)
//                {
//                    XmlNode idNode = identityNode.SelectSingleNode("./*[local-name()='ID']");
//                    if (idNode != null)
//                    {
//                        return idNode.InnerText;
//                    }
//                }
//                return null;
//            });

//            mapper.AddFunctionMap<EikTypeType>(p => p.Identity.TYPE, node =>
//            {
//                var identityNode = node.SelectSingleNode("./*[local-name()='ObligationResponse']/*[local-name()='Identity']");

//                if (identityNode != null)
//                {
//                    XmlNode typeNode = identityNode.SelectSingleNode("./*[local-name()='TYPE']");
//                    if (typeNode != null)
//                    {
//                        return (EikTypeType)Enum.Parse(typeof(EikTypeType), typeNode.InnerText);
//                    }
//                }
//                return null;
//            });

//            mapper.AddFunctionMap<ObligationStatusType>(p => p.ObligationStatus, node =>
//            {
//                var obligationStatusNode = node.SelectSingleNode("./*[local-name()='ObligationResponse']/*[local-name()='ObligationStatus']");

//                if (obligationStatusNode != null)
//                {
//                    return (ObligationStatusType)Enum.Parse(typeof(ObligationStatusType), obligationStatusNode.InnerText);
//                }
//                return null;
//            });

//            mapper.AddFunctionMap<int>(p => p.Status.Code, node =>
//            {
//                var statusNode = node.SelectSingleNode("./*[local-name()='ObligationResponse']/*[local-name()='Status']");

//                if (statusNode != null)
//                {
//                    XmlNode codeNode = statusNode.SelectSingleNode("./*[local-name()='Code']");
//                    if (codeNode != null)
//                    {
//                        return int.Parse(codeNode.InnerText);
//                    }
//                }
//                return null;
//            });

//            mapper.AddFunctionMap<string>(p => p.Status.Message, node =>
//            {
//                var statusNode = node.SelectSingleNode("./*[local-name()='ObligationResponse']/*[local-name()='Status']");

//                if (statusNode != null)
//                {
//                    XmlNode messageNode = statusNode.SelectSingleNode("./*[local-name()='Message']");
//                    if (messageNode != null)
//                    {
//                        return messageNode.InnerText;
//                    }
//                }
//                return null;
//            });

//            mapper.AddFunctionMap<ushort>(p => p.Threshold, node =>
//            {
//                var thresholdNode = node.SelectSingleNode("./*[local-name()='ObligationResponse']/*[local-name()='Threshold']");

//                if (thresholdNode != null && !String.IsNullOrEmpty(thresholdNode.InnerText))
//                {
//                    return ushort.Parse(thresholdNode.InnerText);
//                }
//                return null;
//            });

//            return mapper;
//        }
//    }
//}
