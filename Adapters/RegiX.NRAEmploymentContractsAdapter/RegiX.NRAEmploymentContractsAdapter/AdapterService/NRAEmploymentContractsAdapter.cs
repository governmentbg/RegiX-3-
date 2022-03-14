using System;
using System.Linq;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using TechnoLogica.RegiX.Common.DataContracts;
using System.Globalization;
using TechnoLogica.RegiX.WebServiceAdapterService;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using System.Net.Http;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;

namespace TechnoLogica.RegiX.NRAEmploymentContractsAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(NRAEmploymentContractsAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(NRAEmploymentContractsAdapter), typeof(IAdapterService))]
    public class NRAEmploymentContractsAdapter : RestServiceBaseAdapterService, INRAEmploymentContractsAdapter
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(NRAEmploymentContractsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrl =
           new ParameterInfo<string>("http://172.16.69.13:8078/RegiX.NRAObligatedPersonsAdapterMockup/NRAObligatedPersonsService.svc/GetEmploymentContracts")
           {
               Key = Constants.WebServiceUrlParameterKeyName,
               Description = "Web Service Url with method name",
               OwnerAssembly = typeof(NRAEmploymentContractsAdapter).Assembly
           };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(NRAEmploymentContractsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ServiceSslCertificateThumbPrint =
               new ParameterInfo<string>("")
               {
                   Key = "ServiceSslCertificateThumbPrint",
                   Description = "Service certificate thumbprint for the underlying restful service",
                   OwnerAssembly = typeof(NRAEmploymentContractsAdapter).Assembly
               };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(NRAEmploymentContractsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ClientSslCertificateThumbPrint =
                new ParameterInfo<string>("")
                {
                    Key = "ClientSslCertificateThumbPrint",
                    Description = "Client certificate thumbprint for the underlying restful service",
                    OwnerAssembly = typeof(NRAEmploymentContractsAdapter).Assembly
                };

        /// <summary>
        /// Проверява connection-a към услугата, като се подават и клиентски и сървърен сертификат, в случай че са конфигурирани за ssl
        /// </summary>
        /// <returns>Дали е успешна връзката с услугата</returns>
        public override string CheckRegisterConnection()
        {
            return CheckConnectionStatus(
                webServiceWithMethodUrl: WebServiceUrl.Value,
                webServiceUrl: WebServiceUrl.Value,
                clientCertThumbPrint: ClientSslCertificateThumbPrint.Value,
                serverCertThumbPrint: ServiceSslCertificateThumbPrint.Value
                ).Result;

        }
        /// <summary>
        /// Извлича резултат от извикването на услугата
        /// </summary>
        /// <param name="serviceClient">Клиент за услугата</param>
        /// <param name="argument">аргумент, сериализиран от входния обект</param>
        /// <param name="id">идентификатор на извикването, за логовете</param>
        /// <param name="aditionalParameters">допълнителните параметри към извикването, за логовете</param>
        /// <returns></returns>
        private async Task<string> GetResponse(HttpClient serviceClient, string argument, Guid id, AdapterAdditionalParameters aditionalParameters)
        {
            XmlDocument doc = new XmlDocument();
            doc.InnerXml = argument;
            HttpResponseMessage response = await serviceClient.PostAsXmlAsync("", doc.DocumentElement);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                string content = await response.Content.ReadAsStringAsync();
                LogData(aditionalParameters, new { NotSuccessfulResponse = response, Content = content, Guid = id });
                throw new Exception("StatusCode: " + response.StatusCode + "; Content: " + content);
            }
        }

        public string GetRequest(EmploymentContractsRequest argument)
        {
            Service.EContractRequest param = new Service.EContractRequest();
            param.Identity = new Service.Identity();
            param.Identity.ID = argument.Identity.ID;
            param.Identity.TYPE = (Service.EikTypeType)Enum.Parse(typeof(Service.EikTypeType), argument.Identity.TYPE.ToString());
            if(argument.ContractsFilterSpecified)
            {
                //TODO
                Service.EContractRequestSpan convertedValue;
                if(Enum.TryParse(argument.ContractsFilter.ToString().ToUpper(), out convertedValue))
                {
                    param.Span = convertedValue;
                    param.SpanSpecified = true;
                }
                else
                {
                    param.SpanSpecified = false;
                }
            }
            else
            {
                param.SpanSpecified = false;
                //за да работи, както преди да добавим този параметър
                //param.ContractsFilter =  ContractsFilterType.Active;
            }
            return param.XmlSerialize();
        }

        public CommonSignedResponse<EmploymentContractsRequest, EmploymentContractsResponse> GetEmploymentContracts(EmploymentContractsRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                var serviceClient = GetClient(
                   webServiceUrl: WebServiceUrl.Value,
                   clientCertThumbPrint: ClientSslCertificateThumbPrint.Value,
                   serverCertThumbPrint: ServiceSslCertificateThumbPrint.Value);
                
                string request = GetRequest(argument);
                string responseString = GetResponse(serviceClient, request, id, aditionalParameters).Result;
                EmploymentContractsResponse response = new EmploymentContractsResponse();
                try
                {
                    XElement resultXmlElement = XDocument.Parse(responseString).Root;
                    var responseMapper = CreateEmploymentContractsMapper(accessMatrix, (argument.ContractsFilterSpecified ? argument.ContractsFilter : ContractsFilterType.Active));
                    responseMapper.Map(resultXmlElement, response);
                }
                catch (Exception ex)
                {
                    LogError(aditionalParameters, ex, new { Request = request, Response = responseString });
                    response.Status = new StatusType();
                    response.Status.Code = 1;
                    response.Status.Message = "Услугата на НАП връща невалиден XML";
                }
                return
                    SigningUtils.CreateAndSign(
                        argument,
                        response,
                        accessMatrix,
                        aditionalParameters
                    );
            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }

        private static XPathMapper<EmploymentContractsResponse> CreateEmploymentContractsMapper(AccessMatrix accessMatrix, ContractsFilterType contractsFilter )
        {
            XPathMapper<EmploymentContractsResponse> mapper =
                new XPathMapper<EmploymentContractsResponse>(accessMatrix);
            
            mapper.AddConstantMap(p => p.ContractsFilter, contractsFilter);
            
            //Identity
            mapper.AddFunctionMap<string>(p => p.Identity.ID, node =>
            {
                var identityNode = node.SelectSingleNode("./*[local-name()='EContractResponse']/*[local-name()='Identity']");

                if (identityNode != null)
                {
                    XmlNode idNode = identityNode.SelectSingleNode("./*[local-name()='ID']");
                    if (idNode != null)
                    {
                        return idNode.InnerText;
                    }
                }
                return null;
            });

            mapper.AddFunctionMap<EikTypeType>(p => p.Identity.TYPE, node =>
            {
                var identityNode = node.SelectSingleNode("./*[local-name()='EContractResponse']/*[local-name()='Identity']");

                if (identityNode != null)
                {
                    XmlNode typeNode = identityNode.SelectSingleNode("./*[local-name()='TYPE']");
                    if (typeNode != null)
                    {
                        return (EikTypeType)Enum.Parse(typeof(EikTypeType), typeNode.InnerText);
                    }
                }
                return null;
            });

            mapper.AddFunctionMap(p => p.ReportDate, node =>
            {
                XmlNode reportDateNode =
                        node.SelectSingleNode(
                            "./*[local-name()='EContractResponse']/*[local-name()='ResDate']");
                if (reportDateNode != null &&
                    !string.IsNullOrWhiteSpace(reportDateNode.InnerText))
                {
                    return DateTime.ParseExact(reportDateNode.InnerText, "yyyy-MM-dd",
                                                CultureInfo.InvariantCulture
                                                        .DateTimeFormat);
                }
                return null;
            });


            //Status
            mapper.AddFunctionMap<int>(p => p.Status.Code, node =>
            {
                var identityNode = node.SelectSingleNode("./*[local-name()='EContractResponse']/*[local-name()='Status']");

                if (identityNode != null)
                {
                    XmlNode typeNode = identityNode.SelectSingleNode("./*[local-name()='Code']");
                    if (typeNode != null)
                    {
                        int result;
                        if (int.TryParse(typeNode.InnerText, out result))
                        {
                            return result;
                        }
                    }
                }
                return null;
            });

            mapper.AddFunctionMap<string>(p => p.Status.Message, node =>
            {
                var identityNode = node.SelectSingleNode("./*[local-name()='EContractResponse']/*[local-name()='Status']");

                if (identityNode != null)
                {
                    XmlNode typeNode = identityNode.SelectSingleNode("./*[local-name()='Message']");
                    if (typeNode != null)
                    {
                        return typeNode.InnerText;
                    }
                }
                return null;
            });

            //EContracts
            mapper.AddCollectionMap(p => p.EContracts, "./*[local-name()='EContractResponse']/*[local-name()='EContracts']/*[local-name()='EContract']");
            mapper.AddPropertyMap(p => p.EContracts[0].ContractorBulstat, "./*[local-name()='ContractorBulstat']");
            mapper.AddPropertyMap(p => p.EContracts[0].ContractorName, "./*[local-name()='ContractorName']");
            mapper.AddPropertyMap(p => p.EContracts[0].IndividualEIK, "./*[local-name()='IndividualEIK']");
            mapper.AddPropertyMap(p => p.EContracts[0].IndividualNames, "./*[local-name()='IndividualNames']");
            mapper.AddFunctionMap(p => p.EContracts[0].StartDate, node =>
            {
                XmlNode lastChangedDateNode =
                        node.SelectSingleNode(
                            "./*[local-name()='StartDate']");
                if (lastChangedDateNode != null &&
                    !string.IsNullOrWhiteSpace(lastChangedDateNode.InnerText))
                {
                    return DateTime.ParseExact(lastChangedDateNode.InnerText, "yyyy-MM-dd",
                                                CultureInfo.InvariantCulture
                                                        .DateTimeFormat);
                }
                return null;
            });

            mapper.AddFunctionMap(p => p.EContracts[0].LastAmendDate, node =>
            {
                XmlNode lastChangedDateNode =
                        node.SelectSingleNode(
                            "./*[local-name()='LastAmendDate']");
                if (lastChangedDateNode != null &&
                    !string.IsNullOrWhiteSpace(lastChangedDateNode.InnerText))
                {
                    return DateTime.ParseExact(lastChangedDateNode.InnerText, "yyyy-MM-dd",
                                                CultureInfo.InvariantCulture
                                                        .DateTimeFormat);
                }
                return null;
            });

            mapper.AddFunctionMap(p => p.EContracts[0].EndDate, node =>
            {
                XmlNode lastChangedDateNode =
                        node.SelectSingleNode(
                            "./*[local-name()='EndDate']");
                if (lastChangedDateNode != null &&
                    !string.IsNullOrWhiteSpace(lastChangedDateNode.InnerText))
                {
                    return DateTime.ParseExact(lastChangedDateNode.InnerText, "yyyy-MM-dd",
                                                CultureInfo.InvariantCulture
                                                        .DateTimeFormat);
                }
                return null;
            });

            mapper.AddFunctionMap(p => p.EContracts[0].Reason, node => ParseEContractReasonTypeEnum(node));
            mapper.AddFunctionMap(p => p.EContracts[0].TimeLimit, node =>
            {
                XmlNode lastChangedDateNode =
                        node.SelectSingleNode(
                            "./*[local-name()='TimeLimit']");
                if (lastChangedDateNode != null &&
                    !string.IsNullOrWhiteSpace(lastChangedDateNode.InnerText))
                {
                    return DateTime.ParseExact(lastChangedDateNode.InnerText, "yyyy-MM-dd",
                                                CultureInfo.InvariantCulture
                                                        .DateTimeFormat);
                }
                return null;
            });

            mapper.AddPropertyMap(p => p.EContracts[0].EcoCode, "./*[local-name()='EcoCode']");
            mapper.AddPropertyMap(p => p.EContracts[0].ProfessionCode, "./*[local-name()='ProfessionCode']");
            mapper.AddPropertyMap(p => p.EContracts[0].Remuneration, "./*[local-name()='Remuneration']");
            mapper.AddPropertyMap(p => p.EContracts[0].ProfessionName, "./*[local-name()='Position']");
            mapper.AddPropertyMap(p => p.EContracts[0].EKATTECode, "./*[local-name()='EKATTE']");
            mapper.AddPropertyMap(p => p.EContracts[0].LastTermId, "./*[local-name()='LastTermId']");


            return mapper;
        }


        private static EContractReasonType? ParseEContractReasonTypeEnum(XmlNode source)
        {
            EContractReasonType? target = null;
            try
            {
                var reason = source.SelectSingleNode("./*[local-name()='Reason']");
                if (reason != null)
                {
                    var reasonValue = reason.InnerText;
                    var enumValuesList = Enum.GetValues(typeof(EContractReasonType));
                    var enumType = typeof(EContractReasonType);
                    if (!enumType.IsEnum)
                        return null;
                    foreach (var value in enumValuesList)
                    {
                        var member = enumType.GetMember(value.ToString()).FirstOrDefault();
                        if (member == null)
                            return null;
                        var attribute = member.GetCustomAttributes(false).OfType<XmlEnumAttribute>().FirstOrDefault();
                        if (attribute != null)
                        {
                            var attributeName = attribute.Name;
                            if (attributeName.Equals(reasonValue))
                            {
                                target = (EContractReasonType)Enum.Parse(typeof(EContractReasonType), value.ToString());
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                target = null;
            }
            return target;
        }
        
    }
}