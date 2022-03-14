//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using TechnoLogica.RegiX.Common;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.Common.AdapterCore;
//using TechnoLogica.RegiX.Common.Utils;
//using System.Data;
//using System.ComponentModel.Composition;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;
//using System.Xml;
//using System.Xml.Serialization;
//using System.IO;
//using System.Xml.Linq;
//using TechnoLogica.RegiX.Common.DataContracts;
//using System.Web.Services.Protocols;
//using System.Globalization;
//using TechnoLogica.RegiX.Common.TransportObject;
//using TechnoLogica.RegiX.WebServiceAdapterService;

//namespace TechnoLogica.RegiX.NRAEmploymentContractsAdapter.AdapterService
//{
//    public class NRAEmploymentContractsAdapter : RestServiceBaseAdapterService, INRAEmploymentContractsAdapter
//    {
//        [Export(typeof(ParameterInfo))]
//        [ExportFullName(typeof(NRAEmploymentContractsAdapter), typeof(ParameterInfo))]
//        public static ParameterInfo<string> WebServiceUrl =
//           new ParameterInfo<string>("http://regix2-adapters.regix.tlogica.com/MockRegisters/RegiX.Mockup.NRA/NRAObligatedPersonsService.svc/GetEmploymentContracts")
//           {
//               Key = Constants.WebServiceUrlParameterKeyName,
//               Description = "Web Service Url with method name",
//               OwnerAssembly = typeof(NRAEmploymentContractsAdapter).Assembly
//           };

//        private async Task<string> GetResponse(HttpClient serviceClient, string argument, Guid id, AdapterAdditionalParameters aditionalParameters)
//        {
//            XmlDocument doc = new XmlDocument();
//            doc.InnerXml = argument;

//            HttpResponseMessage response = await serviceClient.PostAsXmlAsync("", doc.DocumentElement);
//            // Service.EContractResponse result = new Service.EContractResponse();
//            string result;

//            if (response.IsSuccessStatusCode)
//            {
//                string res = await response.Content.ReadAsStringAsync();

//                //LogData(aditionalParameters, res);
//                result = res;//(Service.EContractResponse)res.ToXmlElement().Deserialize(typeof(Service.EContractResponse));
//            }
//            else
//            {
//                string content = await response.Content.ReadAsStringAsync();
//                LogData(aditionalParameters, new { NotSuccessfulResponse = response, Content = content, Guid = id });
//                throw new Exception("StatusCode: " + response.StatusCode + "; Content: " + content);
//            }


//            return result;
//        }

//        public string GetRequest(EmploymentContractsRequest argument)
//        {
//            Service.EContractRequest param = new Service.EContractRequest();
//            param.Identity = new Service.IdentityType();
//            param.Identity.ID = argument.Identity.ID;
//            param.Identity.TYPE = (EikTypeType)Enum.Parse(typeof(EikTypeType), argument.Identity.TYPE.ToString());
//            return param.XmlSerialize();
//        }

//        public CommonSignedResponse<EmploymentContractsRequest, EmploymentContractsResponse> GetEmploymentContracts(EmploymentContractsRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
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
//                //Service.EContractResponse result = GetResponse(serviceClient, request, id, aditionalParameters).Result;
//                //LogData(aditionalParameters, responseString);
//                var responseMapper = CreateEmploymentContractsMapper(accessMatrix);
//                EmploymentContractsResponse response = new EmploymentContractsResponse();
//                responseMapper.Map(resultXmlElement, response);
//                //LogData(aditionalParameters,new {response = response.XmlSerialize(), am = accessMatrix.Serialize(), serviceResult= resultXmlElement.XmlSerialize()});
//                //LogData(aditionalParameters, new { response.EContracts[0].IndividualNames, response.EContracts[0].IndividualEIK});
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

//        private static XPathMapper<EmploymentContractsResponse> CreateEmploymentContractsMapper(AccessMatrix accessMatrix)
//        {
//            XPathMapper<EmploymentContractsResponse> mapper =
//                new XPathMapper<EmploymentContractsResponse>(accessMatrix);

//            mapper.AddFunctionMap<string>(p => p.Identity.ID, node =>
//            {
//                var identityNode = node.SelectSingleNode("./*[local-name()='EContractResponse']/*[local-name()='Identity']");

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
//                var identityNode = node.SelectSingleNode("./*[local-name()='EContractResponse']/*[local-name()='Identity']");

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

//            mapper.AddFunctionMap<int>(p => p.Status.Code, node =>
//            {
//                var identityNode = node.SelectSingleNode("./*[local-name()='EContractResponse']/*[local-name()='Status']");

//                if (identityNode != null)
//                {
//                    XmlNode typeNode = identityNode.SelectSingleNode("./*[local-name()='Code']");
//                    if (typeNode != null)
//                    {
//                        int result;
//                        if (int.TryParse(identityNode.InnerText, out result))
//                        {
//                            return result;
//                        }
//                    }
//                }
//                return null;
//            });

//            mapper.AddFunctionMap<string>(p => p.Status.Message, node =>
//            {
//                var identityNode = node.SelectSingleNode("./*[local-name()='EContractResponse']/*[local-name()='Status']");

//                if (identityNode != null)
//                {
//                    XmlNode typeNode = identityNode.SelectSingleNode("./*[local-name()='Message']");
//                    if (typeNode != null)
//                    {
//                        return identityNode.InnerText;
//                    }
//                }
//                return null;
//            });

//            mapper.AddCollectionMap(p => p.EContracts, "./*[local-name()='EContractResponse']/*[local-name()='EContracts']/*[local-name()='EContract']");
//            mapper.AddPropertyMap(p => p.EContracts[0].ContractorBulstat, "./*[local-name()='ContractorBulstat']");
//            mapper.AddPropertyMap(p => p.EContracts[0].ContractorName, "./*[local-name()='ContractorName']");
//            mapper.AddPropertyMap(p => p.EContracts[0].EcoCode, "./*[local-name()='EcoCode']");
//            // mapper.AddPropertyMap(p => p.EContracts[0].EndDate, "./*[local-name()='EContract']/*[local-name()='EndDate']");
//            mapper.AddFunctionMap(p => p.EContracts[0].EndDate, node =>
//            {
//                XmlNode lastChangedDateNode =
//                        node.SelectSingleNode(
//                            "./*[local-name()='EndDate']");
//                if (lastChangedDateNode != null &&
//                    !string.IsNullOrWhiteSpace(lastChangedDateNode.InnerText))
//                {
//                    return DateTime.ParseExact(lastChangedDateNode.InnerText, "yyyy-MM-dd",
//                                                CultureInfo.InvariantCulture
//                                                        .DateTimeFormat);
//                }
//                return null;
//            });
//            mapper.AddPropertyMap(p => p.EContracts[0].IndividualEIK, "./*[local-name()='IndividualEIK']");
//            mapper.AddPropertyMap(p => p.EContracts[0].IndividualNames, "./*[local-name()='IndividualNames']");

//            // mapper.AddPropertyMap(p => p.EContracts[0].LastAmendDate, "./*[local-name()='EContract']/*[local-name()='LastAmendDate']");
//            mapper.AddFunctionMap(p => p.EContracts[0].LastAmendDate, node =>
//            {
//                XmlNode lastChangedDateNode =
//                        node.SelectSingleNode(
//                            "./*[local-name()='LastAmendDate']");
//                if (lastChangedDateNode != null &&
//                    !string.IsNullOrWhiteSpace(lastChangedDateNode.InnerText))
//                {
//                    return DateTime.ParseExact(lastChangedDateNode.InnerText, "yyyy-MM-dd",
//                                                CultureInfo.InvariantCulture
//                                                        .DateTimeFormat);
//                }
//                return null;
//            });
//            mapper.AddPropertyMap(p => p.EContracts[0].ProfessionCode, "./*[local-name()='ProfessionCode']");
//            mapper.AddFunctionMap(p => p.EContracts[0].Reason, node => ParseEContractReasonTypeEnum(node));
//            //mapper.AddPropertyMap(p => p.EContracts[0].Reason, "./*[local-name()='Reason']");
//            mapper.AddPropertyMap(p => p.EContracts[0].Remuneration, "./*[local-name()='Remuneration']");
//            // mapper.AddPropertyMap(p => p.EContracts[0].StartDate, "./*[local-name()='EContract']/*[local-name()='StartDate']");
//            mapper.AddFunctionMap(p => p.EContracts[0].StartDate, node =>
//            {
//                XmlNode lastChangedDateNode =
//                        node.SelectSingleNode(
//                            "./*[local-name()='StartDate']");
//                if (lastChangedDateNode != null &&
//                    !string.IsNullOrWhiteSpace(lastChangedDateNode.InnerText))
//                {
//                    return DateTime.ParseExact(lastChangedDateNode.InnerText, "yyyy-MM-dd",
//                                                CultureInfo.InvariantCulture
//                                                        .DateTimeFormat);
//                }
//                return null;
//            });
//            // mapper.AddPropertyMap(p => p.EContracts[0].TimeLimit, "./*[local-name()='EContract']/*[local-name()='TimeLimit']");
//            mapper.AddFunctionMap(p => p.EContracts[0].TimeLimit, node =>
//            {
//                XmlNode lastChangedDateNode =
//                        node.SelectSingleNode(
//                            "./*[local-name()='TimeLimit']");
//                if (lastChangedDateNode != null &&
//                    !string.IsNullOrWhiteSpace(lastChangedDateNode.InnerText))
//                {
//                    return DateTime.ParseExact(lastChangedDateNode.InnerText, "yyyy-MM-dd",
//                                                CultureInfo.InvariantCulture
//                                                        .DateTimeFormat);
//                }
//                return null;
//            });

//            //mapper.AddFunctionMap<string>(p => p.EContracts[0].ContractorBulstat, node =>
//            //{
//            //    var identityNode = node.SelectSingleNode("./*[local-name()='EContractResponse']/*[local-name()='EContracts']/*[local-name()='EContract']");

//            //    if (identityNode != null)
//            //    {
//            //        XmlNode typeNode = identityNode.SelectSingleNode("./*[local-name()='ContractorBulstat']");
//            //        if (typeNode != null)
//            //        {
//            //            return identityNode.InnerText;
//            //        }
//            //    }
//            //    return null;
//            //});

//            //mapper.AddFunctionMap<string>(p => p.EContracts[0].ContractorName, node =>
//            //{
//            //    var identityNode = node.SelectSingleNode("./*[local-name()='EContractResponse']/*[local-name()='EContracts']");

//            //    if (identityNode != null)
//            //    {
//            //        XmlNode typeNode = identityNode.SelectSingleNode("./*[local-name()='ContractorName']");
//            //        if (typeNode != null)
//            //        {
//            //            return identityNode.InnerText;
//            //        }
//            //    }
//            //    return null;
//            //});

//            //mapper.AddFunctionMap<string>(p => p.EContracts[0].EcoCode, node =>
//            //{
//            //    var identityNode = node.SelectSingleNode("./*[local-name()='EContractResponse']/*[local-name()='EContracts']");

//            //    if (identityNode != null)
//            //    {
//            //        XmlNode typeNode = identityNode.SelectSingleNode("./*[local-name()='EcoCode']");
//            //        if (typeNode != null)
//            //        {
//            //            return identityNode.InnerText;
//            //        }
//            //    }
//            //    return null;
//            //});

//            //mapper.AddFunctionMap<DateTime>(p => p.EContracts[0].EndDate, node =>
//            //{
//            //    var identityNode = node.SelectSingleNode("./*[local-name()='EContractResponse']/*[local-name()='EContracts']");

//            //    if (identityNode != null)
//            //    {
//            //        XmlNode typeNode = identityNode.SelectSingleNode("./*[local-name()='EndDate']");
//            //        if (typeNode != null)
//            //        {
//            //            DateTime result;
//            //            if (DateTime.TryParse(typeNode.InnerText, out result))
//            //            {
//            //                return result;
//            //            }
//            //        }
//            //    }
//            //    return null;
//            //});

//            //mapper.AddFunctionMap<string>(p => p.EContracts[0].IndividualEIK, node =>
//            //{
//            //    var identityNode = node.SelectSingleNode("./*[local-name()='EContractResponse']/*[local-name()='EContracts']");

//            //    if (identityNode != null)
//            //    {
//            //        XmlNode typeNode = identityNode.SelectSingleNode("./*[local-name()='IndividualEIK']");
//            //        if (typeNode != null)
//            //        {
//            //            return identityNode.InnerText;
//            //        }
//            //    }
//            //    return null;
//            //});

//            //mapper.AddFunctionMap<string>(p => p.EContracts[0].IndividualNames, node =>
//            //{
//            //    var identityNode = node.SelectSingleNode("./*[local-name()='EContractResponse']/*[local-name()='EContracts']");

//            //    if (identityNode != null)
//            //    {
//            //        XmlNode typeNode = identityNode.SelectSingleNode("./*[local-name()='IndividualNames']");
//            //        if (typeNode != null)
//            //        {
//            //            return identityNode.InnerText;
//            //        }
//            //    }
//            //    return null;
//            //});

//            //mapper.AddFunctionMap<DateTime>(p => p.EContracts[0].LastAmendDate, node =>
//            //{
//            //    var identityNode = node.SelectSingleNode("./*[local-name()='EContractResponse']/*[local-name()='EContracts']");

//            //    if (identityNode != null)
//            //    {
//            //        XmlNode typeNode = identityNode.SelectSingleNode("./*[local-name()='LastAmendDate']");
//            //        if (typeNode != null)
//            //        {
//            //            DateTime result;
//            //            if (DateTime.TryParse(typeNode.InnerText, out result))
//            //            {
//            //                return result;
//            //            }
//            //        }
//            //    }
//            //    return null;
//            //});

//            //mapper.AddFunctionMap<string>(p => p.EContracts[0].ProfessionCode, node =>
//            //{
//            //    var identityNode = node.SelectSingleNode("./*[local-name()='EContractResponse']/*[local-name()='EContracts']");

//            //    if (identityNode != null)
//            //    {
//            //        XmlNode typeNode = identityNode.SelectSingleNode("./*[local-name()='ProfessionCode']");
//            //        if (typeNode != null)
//            //        {
//            //            return identityNode.InnerText;
//            //        }
//            //    }
//            //    return null;
//            //});

//            //mapper.AddFunctionMap<EContractReasonType>(p => p.EContracts[0].Reason, node =>
//            //{
//            //    var identityNode = node.SelectSingleNode("./*[local-name()='EContractResponse']/*[local-name()='Identity']");

//            //    if (identityNode != null)
//            //    {
//            //        XmlNode typeNode = identityNode.SelectSingleNode("./*[local-name()='Reason']");
//            //        if (typeNode != null)
//            //        {
//            //            return (EContractReasonType)Enum.Parse(typeof(EContractReasonType), typeNode.InnerText);
//            //        }
//            //    }
//            //    return null;
//            //});

//            //mapper.AddFunctionMap<decimal>(p => p.EContracts[0].Remuneration, node =>
//            //{
//            //    var identityNode = node.SelectSingleNode("./*[local-name()='EContractResponse']/*[local-name()='EContracts']");

//            //    if (identityNode != null)
//            //    {
//            //        XmlNode typeNode = identityNode.SelectSingleNode("./*[local-name()='Remuneration']");
//            //        if (typeNode != null)
//            //        {
//            //            decimal result;
//            //            if (decimal.TryParse(identityNode.InnerText, out result))
//            //            {
//            //                return result;
//            //            }
//            //        }
//            //    }
//            //    return null;
//            //});

//            //mapper.AddFunctionMap<DateTime>(p => p.EContracts[0].StartDate, node =>
//            //{
//            //    var identityNode = node.SelectSingleNode("./*[local-name()='EContractResponse']/*[local-name()='EContracts']");

//            //    if (identityNode != null)
//            //    {
//            //        XmlNode typeNode = identityNode.SelectSingleNode("./*[local-name()='StartDate']");
//            //        if (typeNode != null)
//            //        {
//            //            DateTime result;
//            //            if (DateTime.TryParse(typeNode.InnerText, out result))
//            //            {
//            //                return result;
//            //            }
//            //        }
//            //    }
//            //    return null;
//            //});

//            //mapper.AddFunctionMap<DateTime>(p => p.EContracts[0].TimeLimit, node =>
//            //{
//            //    var identityNode = node.SelectSingleNode("./*[local-name()='EContractResponse']/*[local-name()='EContracts']");

//            //    if (identityNode != null)
//            //    {
//            //        XmlNode typeNode = identityNode.SelectSingleNode("./*[local-name()='TimeLimit']");
//            //        if (typeNode != null)
//            //        {
//            //            DateTime result;
//            //            if (DateTime.TryParse(typeNode.InnerText, out result))
//            //            {
//            //                return result;
//            //            }
//            //        }
//            //    }
//            //    return null;
//            //});



//            //ObjectMapper<Service.EContractResponse, EmploymentContractsResponse> mapper = new ObjectMapper<Service.EContractResponse, EmploymentContractsResponse>(accessMatrix);
//            //mapper.AddObjectMap((o) => o.Identity, (c) => c.Identity);
//            //mapper.AddPropertyMap((o) => o.Identity.ID, (c) => c.Identity.ID);
//            //mapper.AddPropertyMap((o) => o.Identity.TYPE, (c) => c.Identity.TYPE);

//            //mapper.AddObjectMap((o) => o.Status, (c) => c.Status);
//            //mapper.AddPropertyMap((o) => o.Status.Code, (c) => c.Status.Code);
//            //mapper.AddPropertyMap((o) => o.Status.Message, (c) => c.Status.Message);

//            //mapper.AddCollectionMap<Service.EContractResponse>((o) => o.EContracts, (c) => c.EContracts);
//            //mapper.AddPropertyMap((o) => o.EContracts[0].ContractorBulstat, (c) => c.EContracts[0].ContractorBulstat);
//            //mapper.AddPropertyMap((o) => o.EContracts[0].ContractorName, (c) => c.EContracts[0].ContractorName);
//            //mapper.AddPropertyMap((o) => o.EContracts[0].IndividualEIK, (c) => c.EContracts[0].IndividualEIK);
//            //mapper.AddPropertyMap((o) => o.EContracts[0].IndividualNames, (c) => c.EContracts[0].IndividualNames);
//            //mapper.AddPropertyMap((o) => o.EContracts[0].StartDate, (c) => c.EContracts[0].StartDate);
//            //mapper.AddPropertyMap((o) => o.EContracts[0].LastAmendDate, (c) => c.EContracts[0].LastAmendDate);
//            //mapper.AddPropertyMap((o) => o.EContracts[0].EndDate, (c) => c.EContracts[0].EndDate);
//            //mapper.AddPropertyMap((o) => o.EContracts[0].Reason, (c) => c.EContracts[0].Reason);
//            //mapper.AddPropertyMap((o) => o.EContracts[0].TimeLimit, (c) => c.EContracts[0].TimeLimit);
//            //mapper.AddPropertyMap((o) => o.EContracts[0].EcoCode, (c) => c.EContracts[0].EcoCode);
//            //mapper.AddPropertyMap((o) => o.EContracts[0].ProfessionCode, (c) => c.EContracts[0].ProfessionCode);
//            //mapper.AddPropertyMap((o) => o.EContracts[0].Remuneration, (c) => c.EContracts[0].Remuneration);

//            return mapper;
//        }


//        private static EContractReasonType? ParseEContractReasonTypeEnum(XmlNode source)
//        {
//            EContractReasonType? target = null;

//            try
//            {
//                var reason = source.SelectSingleNode("./*[local-name()='Reason']");
//                if (reason != null)
//                {
//                    var reasonValue = reason.InnerText;
//                    var enumValuesList = Enum.GetValues(typeof(EContractReasonType));
//                    var enumType = typeof(EContractReasonType);
//                    if (!enumType.IsEnum)
//                        return null;
//                    foreach (var value in enumValuesList)
//                    {
//                        var member = enumType.GetMember(value.ToString()).FirstOrDefault();
//                        if (member == null)
//                            return null;
//                        var attribute = member.GetCustomAttributes(false).OfType<XmlEnumAttribute>().FirstOrDefault();
//                        if (attribute != null)
//                        {
//                            var attributeName = attribute.Name;
//                            if (attributeName.Equals(reasonValue))
//                            {
//                                target = (EContractReasonType)Enum.Parse(typeof(EContractReasonType), value.ToString());
//                                break;
//                            }
//                        }
//                    }
//                }

//            }
//            catch (Exception)
//            {
//                target = null;
//            }

//            return target;
//        }


//        //private static ObjectMapper<Service.EContractResponse, EmploymentContractsResponse> CreateEmploymentContractsMapper(AccessMatrix accessMatrix)
//        //{
//        //    ObjectMapper<Service.EContractResponse, EmploymentContractsResponse> mapper = new ObjectMapper<Service.EContractResponse, EmploymentContractsResponse>(accessMatrix);
//        //    mapper.AddObjectMap((o) => o.Identity, (c) => c.Identity);
//        //    mapper.AddPropertyMap((o) => o.Identity.ID, (c) => c.Identity.ID);
//        //    mapper.AddPropertyMap((o) => o.Identity.TYPE, (c) => c.Identity.TYPE);

//        //    mapper.AddObjectMap((o) => o.Status, (c) => c.Status);
//        //    mapper.AddPropertyMap((o) => o.Status.Code, (c) => c.Status.Code);
//        //    mapper.AddPropertyMap((o) => o.Status.Message, (c) => c.Status.Message);

//        //    mapper.AddCollectionMap<Service.EContractResponse>((o) => o.EContracts, (c) => c.EContracts);
//        //    mapper.AddPropertyMap((o) => o.EContracts[0].ContractorBulstat, (c) => c.EContracts[0].ContractorBulstat);
//        //    mapper.AddPropertyMap((o) => o.EContracts[0].ContractorName, (c) => c.EContracts[0].ContractorName);
//        //    mapper.AddPropertyMap((o) => o.EContracts[0].IndividualEIK, (c) => c.EContracts[0].IndividualEIK);
//        //    mapper.AddPropertyMap((o) => o.EContracts[0].IndividualNames, (c) => c.EContracts[0].IndividualNames);
//        //    mapper.AddFunctionMap<Service.EContractResponse, DateTime?>((o) => o.EContracts[0].StartDate, (c) => c.EContracts[0].StartDate);
//        //    //mapper.AddPropertyMap((o) => o.EContracts[0].StartDate, (c) => (c.EContracts[0].StartDate==null)? null : c.EContracts[0].StartDate);
//        //    mapper.AddFunctionMap<Service.EContractResponse, DateTime?>((o) => o.EContracts[0].LastAmendDate, (c) => c.EContracts[0].LastAmendDate);
//        //   // mapper.AddPropertyMap((o) => o.EContracts[0].LastAmendDate, (c) => c.EContracts[0].LastAmendDate);
//        //    mapper.AddFunctionMap<Service.EContractResponse, DateTime?>((o) => o.EContracts[0].EndDate, (c) => c.EContracts[0].EndDate);
//        //   // mapper.AddPropertyMap((o) => o.EContracts[0].EndDate, (c) => c.EContracts[0].EndDate);
//        //    mapper.AddPropertyMap((o) => o.EContracts[0].Reason, (c) => c.EContracts[0].Reason);
//        //    mapper.AddFunctionMap<Service.EContractResponse, DateTime?>((o) => o.EContracts[0].TimeLimit, (c) => c.EContracts[0].TimeLimit);
//        //   // mapper.AddPropertyMap((o) => o.EContracts[0].TimeLimit, (c) => c.EContracts[0].TimeLimit);
//        //    mapper.AddPropertyMap((o) => o.EContracts[0].EcoCode, (c) => c.EContracts[0].EcoCode);
//        //    mapper.AddPropertyMap((o) => o.EContracts[0].ProfessionCode, (c) => c.EContracts[0].ProfessionCode);
//        //    mapper.AddPropertyMap((o) => o.EContracts[0].Remuneration, (c) => c.EContracts[0].Remuneration);

//        //    return mapper;
//        //}
//    }
//}