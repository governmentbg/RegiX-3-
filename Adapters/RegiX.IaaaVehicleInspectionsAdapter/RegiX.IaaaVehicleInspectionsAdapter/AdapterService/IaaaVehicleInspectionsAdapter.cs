using System;
using System.Collections.Generic;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.DataContracts;
using System.Globalization;
using TechnoLogica.RegiX.WebServiceAdapterService;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net;
using System.Configuration;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.Net.Http;
using System.Net.Http.Headers;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;

namespace TechnoLogica.RegiX.IaaaVehicleInspectionsAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(IaaaVehicleInspectionsAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(IaaaVehicleInspectionsAdapter), typeof(IAdapterService))]
    public class IaaaVehicleInspectionsAdapter : WebServiceBaseAdapterService, IIaaaVehicleInspectionsAdapter, IAdapterService
    {
        #region
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(IaaaVehicleInspectionsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrl =
            new ParameterInfo<string>("https://192.168.168.11:8444/egov-web/api/rir2/reports/")
            {
                Key = Constants.WebServiceUrlParameterKeyName,
                Description = "Web Service Url",
                OwnerAssembly = typeof(IaaaVehicleInspectionsAdapter).Assembly
            };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(IaaaVehicleInspectionsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> Report1PermitMethodName =
                new ParameterInfo<string>("permits")
                {
                    Key = "Report1PermitMethodName",
                    Description = "Method name describing the service url",
                    OwnerAssembly = typeof(IaaaVehicleInspectionsAdapter).Assembly
                };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(IaaaVehicleInspectionsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> Report2PermitInspectorsMethodName =
                new ParameterInfo<string>("permit-inspectors")
                {
                    Key = "Report2PermitInspectorsMethodName",
                    Description = "Method name describing the service url",
                    OwnerAssembly = typeof(IaaaVehicleInspectionsAdapter).Assembly
                };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(IaaaVehicleInspectionsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> Report3PermitsInspectionCountReportMethodName =
                new ParameterInfo<string>("permits-inspection-count")
                {
                    Key = "Report3PermitsInspectionCountReportMethodName",
                    Description = "Method name describing the service url",
                    OwnerAssembly = typeof(IaaaVehicleInspectionsAdapter).Assembly
                };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(IaaaVehicleInspectionsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> Report4VehicleInspectionMethodName =
                new ParameterInfo<string>("vehicle-inspection")
                {
                    Key = "Report4VehicleInspectionMethodName",
                    Description = "Method name describing the service url",
                    OwnerAssembly = typeof(IaaaVehicleInspectionsAdapter).Assembly
                };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(IaaaVehicleInspectionsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> Report5VehicleInspectionStickerMethodName =
                new ParameterInfo<string>("vehicle-inspection-sticker")
                {
                    Key = "Report5VehicleInspectionStickerMethodName",
                    Description = "Method name describing the service url",
                    OwnerAssembly = typeof(IaaaVehicleInspectionsAdapter).Assembly
                };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(IaaaVehicleInspectionsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ServiceSslCertificateThumbPrint =
                new ParameterInfo<string>("7e 9a c3 ea f1 a9 cb 60 b2 38 5c 28 2d 12 ec 33 35 88 66 f1")
                {
                    Key = "ServiceSslCertificateThumbPrint",
                    Description = "Service certificate thumbprint for the underlying restful service",
                    OwnerAssembly = typeof(IaaaVehicleInspectionsAdapter).Assembly
                };
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(IaaaVehicleInspectionsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ClientSslCertificateThumbPrint =
                new ParameterInfo<string>("a6 7c 54 eb aa 05 71 ae 17 cb 16 40 16 e8 b6 ae a4 8f 76 f9")
                {
                    Key = "ClientSslCertificateThumbPrint",
                    Description = "Client certificate thumbprint for the underlying restful service",
                    OwnerAssembly = typeof(IaaaVehicleInspectionsAdapter).Assembly
                };
        private static bool _logResultsFromSource = Convert.ToBoolean(ConfigurationManager.AppSettings["LogResultsFromSource"]);

        #endregion

        private async Task<string> CheckConnectionStatus(string connectionStringUrl)
        {
            var serviceClient = GetClient();
            HttpResponseMessage response = await serviceClient.GetAsync(connectionStringUrl);

            if (response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.MethodNotAllowed)
            {
                return Constants.ConnectionOk;
            }
            else
            {
                string content = await response.Content.ReadAsStringAsync();
                return "StatusCode: " + response.StatusCode + "; Content: " + content;
            }
        }


        public override string CheckRegisterConnection()
        {
            Dictionary<string, string> results = new Dictionary<string, string>();

            string resultReport1PermitMethodName = CheckConnectionStatus(WebServiceUrl.Value + Report1PermitMethodName.Value).Result;
            string resultReport2PermitInspectorsMethodName = CheckConnectionStatus(WebServiceUrl.Value + Report2PermitInspectorsMethodName.Value).Result;
            string resultReport3PermitsInspectionCountReportMethodName = CheckConnectionStatus(WebServiceUrl.Value + Report3PermitsInspectionCountReportMethodName.Value).Result;
            string resultReport4VehicleInspectionMethodName = CheckConnectionStatus(WebServiceUrl.Value + Report4VehicleInspectionMethodName.Value).Result;
            string resultReport5VehicleInspectionStickerMethodName = CheckConnectionStatus(WebServiceUrl.Value + Report5VehicleInspectionStickerMethodName.Value).Result;

            results.Add("Report1PermitMethodName", resultReport1PermitMethodName);
            results.Add("Report2PermitInspectorsMethodName", resultReport2PermitInspectorsMethodName);
            results.Add("Report3PermitsInspectionCountReportMethodName", resultReport3PermitsInspectionCountReportMethodName);
            results.Add("Report4VehicleInspectionMethodName", resultReport4VehicleInspectionMethodName);
            results.Add("Report5VehicleInspectionStickerMethodName", resultReport5VehicleInspectionStickerMethodName);

            string description = string.Empty;
            int statusOk = 0;
            int statusNotSet = 0;
            int ststusError = 0;
            foreach (var res in results)
            {
                description += String.Format("{0}: {1}\r\n", res.Key, res.Value);
                if (res.Value == Constants.ConnectionOk)
                {
                    statusOk++;
                }
                else
                {
                    if (res.Value == Constants.WebServiceUrlNotSet)
                    {
                        statusNotSet++;
                    }
                    else
                    {
                        ststusError++;
                    }
                }
            }
            if (ststusError > 0)
            {
                return description;
            }
            else
            {
                if (statusNotSet > 0)
                {
                    return Constants.WebServiceUrlNotSet;
                }
                else
                {
                    return Constants.ConnectionOk;
                }
            }
        }

        private async Task<string> GetResponse(HttpClient serviceClient, string argument, string adress, Guid id, AdapterAdditionalParameters aditionalParameters)
        {
            XmlDocument doc = new XmlDocument();
            doc.InnerXml = argument;
            HttpResponseMessage response = await serviceClient.PostAsXmlAsync(adress, doc.DocumentElement);

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                if (_logResultsFromSource)
                {
                    LogData(aditionalParameters, new { Argument = argument, Response = responseString, Guid = id });
                }
                return responseString;
            }
            else
            {
                string content = await response.Content.ReadAsStringAsync();
                if (_logResultsFromSource)
                {
                    LogData(aditionalParameters, new { Argument = argument, Response = content, Guid = id });
                }
                if (content.Contains("<error:errorCode>NOT_FOUND</error:errorCode>"))
                {
                    return string.Empty;
                }
                LogData(aditionalParameters, new { NotSuccessfulResponse = response, Content = content, Guid = id });
                throw new Exception("StatusCode: " + response.StatusCode + "; Content: " + content);
            }
        }

        private X509Certificate2 GetMyX509Certificate()
        {
            string sslThumbPrint = ClientSslCertificateThumbPrint.Value;
            if (sslThumbPrint != null)
            {
                sslThumbPrint = sslThumbPrint.Replace(" ", "").ToUpper();
            }

            X509Certificate2 certSelected = null;
            X509Store x509Store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            x509Store.Open(OpenFlags.ReadOnly);

            X509Certificate2Collection certificateCollection = x509Store.Certificates;

            foreach (var cer in certificateCollection)
            {
                if (cer.Thumbprint.CompareTo(sslThumbPrint) == 0)//cer.Thumbprint == sslThumbPrint)
                {
                    certSelected = cer;
                    break;
                }
            }

            x509Store.Close();

            return certSelected;
        }

        private bool Verify_Certificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
            string thumbPrint = IaaaVehicleInspectionsAdapter.ServiceSslCertificateThumbPrint.Value.Replace(" ", "").ToUpper();
          
            string configurationThumbPrint = certificate.GetCertHashString();
            configurationThumbPrint = configurationThumbPrint.Replace(" ", "").ToLower();

            if (thumbPrint.CompareTo(configurationThumbPrint) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private HttpClient GetClient()
        {
            WebRequestHandler handler = new WebRequestHandler();
            X509Certificate2 certificate = GetMyX509Certificate();
            if (certificate != null)
            {
                handler.ClientCertificates.Add(certificate);
                handler.ServerCertificateValidationCallback += Verify_Certificate;
            }
            var serviceClient = new HttpClient(handler);
            serviceClient.BaseAddress = new Uri(WebServiceUrl.Value);
            serviceClient.DefaultRequestHeaders.Accept.Clear();
            serviceClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            return serviceClient;
        }

        /// <summary>
        /// Справка за статус на регистрацията по ЕИК
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="accessMatrix"></param>
        /// <param name="aditionalParameters"></param>
        /// <returns></returns>
        public CommonSignedResponse<PermitRequestType, PermitResponse> GetReport1Permit(PermitRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                if (argument == null || string.IsNullOrEmpty(argument.IdentNumber))
                {
                    throw new FaultException("Полето ЕИК/БУЛСТАТ е задължително!");
                }
                var serviceClient = GetClient();

                ServiceXMLShemas.permitRequest param = new ServiceXMLShemas.permitRequest();
                param.context = aditionalParameters.CallContext.ToString();
                param.identNumber = argument.IdentNumber;
                string request = param.XmlSerialize();

                string responseString = GetResponse(serviceClient, request, Report1PermitMethodName.Value, id, aditionalParameters).Result;

                PermitResponse result = new PermitResponse();
                if (!string.IsNullOrEmpty(responseString))
                {
                    XElement resultXmlElement = XDocument.Parse(responseString).Root;
                    XPathMapper<PermitResponse> responseMapper = CreatePermitResponseMapper(accessMatrix);
                    responseMapper.Map(resultXmlElement, result);
                }

                return
                    SigningUtils.CreateAndSign(
                        argument,
                        result,
                        accessMatrix,
                        aditionalParameters
                    );
            }
            catch (Exception ex)
            {
                string content = "";
                if (ex is AggregateException)
                {
                    var e = (AggregateException)ex;
                    foreach (var item in e.InnerExceptions)
                    {
                        content += "Message: " + item.Message + Environment.NewLine;
                        content += item.StackTrace + Environment.NewLine + Environment.NewLine;
                    }
                }
                else
                {
                    content = ex.Message;
                }

                LogError(aditionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }

        private static XPathMapper<PermitResponse> CreatePermitResponseMapper(AccessMatrix accessMatrix)
        {
            XPathMapper<PermitResponse> mapper =
                new XPathMapper<PermitResponse>(accessMatrix);

            mapper.AddCollectionMap(p => p.Permits, "/*[local-name()='permitResponse']/*[local-name()='permits']/*[local-name()='permit']");

            mapper.AddFunctionMap(p => p.Permits[0].CloseDate, node =>
            {
                XmlNode closeDateNode =
                        node.SelectSingleNode(
                            "./*[local-name()='closeDate']");
                if (closeDateNode != null &&
                    !string.IsNullOrWhiteSpace(closeDateNode.InnerText))
                {
                    return DateTime.ParseExact(closeDateNode.InnerText, "yyyy-MM-dd",
                                                CultureInfo.InvariantCulture
                                                        .DateTimeFormat);
                }
                return null;
            });

            mapper.AddPropertyMap(p => p.Permits[0].CloseReason, "./*[local-name()='closeReason']");

            mapper.AddFunctionMap(p => p.Permits[0].FirstRegDate, node =>
            {
                XmlNode firstRegDateNode =
                        node.SelectSingleNode(
                            "./*[local-name()='firstRegDate']");
                if (firstRegDateNode != null &&
                    !string.IsNullOrWhiteSpace(firstRegDateNode.InnerText))
                {
                    return DateTime.ParseExact(firstRegDateNode.InnerText, "yyyy-MM-dd",
                                                CultureInfo.InvariantCulture
                                                        .DateTimeFormat);
                }
                return null;
            });

            mapper.AddFunctionMap(p => p.Permits[0].InspectionDate, node =>
            {
                XmlNode inspectionDateNode =
                        node.SelectSingleNode(
                            "./*[local-name()='inspectionDate']");
                if (inspectionDateNode != null &&
                    !string.IsNullOrWhiteSpace(inspectionDateNode.InnerText))
                {
                    return DateTime.ParseExact(inspectionDateNode.InnerText, "yyyy-MM-dd",
                                                CultureInfo.InvariantCulture
                                                        .DateTimeFormat);
                }
                return null;
            });

            mapper.AddPropertyMap(p => p.Permits[0].InspectionProtocols, "./*[local-name()='inspectionProtocols']");
            mapper.AddCollectionMap(p => p.Permits[0].Inspectors, "./*[local-name()='inspectors']/*[local-name()='inspector']");
            mapper.AddPropertyMap(p => p.Permits[0].Inspectors[0].CurrentStatus, "./*[local-name()='currentStatus']");

            mapper.AddFunctionMap(p => p.Permits[0].Inspectors[0].IsChairman, node =>
            {
                XmlNode isChairmanNode =
                        node.SelectSingleNode(
                            "./*[local-name()='isChairman']");

                if (isChairmanNode != null &&
                    !string.IsNullOrWhiteSpace(isChairmanNode.InnerText))
                {
                    bool result;
                    if (bool.TryParse(isChairmanNode.InnerText, out result))
                        return result;
                }
                return null;
            });

            mapper.AddPropertyMap(p => p.Permits[0].Inspectors[0].SubjectFullName, "./*[local-name()='subjectFullName']");
            mapper.AddPropertyMap(p => p.Permits[0].Inspectors[0].SubjectIdentNumber, "./*[local-name()='subjectIdentNumber']");
            mapper.AddPropertyMap(p => p.Permits[0].KtpAddress, "./*[local-name()='ktpAddress']");
            mapper.AddPropertyMap(p => p.Permits[0].KtpCategoryLabel, "./*[local-name()='ktpCategoryLabel']");
            mapper.AddPropertyMap(p => p.Permits[0].KtpCityName, "./*[local-name()='ktpCityName']");
            mapper.AddPropertyMap(p => p.Permits[0].KtpName, "./*[local-name()='ktpName']");

            mapper.AddFunctionMap(p => p.Permits[0].LastChangeDate, node =>
            {
                XmlNode lastChangeDateNode =
                        node.SelectSingleNode(
                            "./*[local-name()='lastChangeDate']");
                if (lastChangeDateNode != null &&
                    !string.IsNullOrWhiteSpace(lastChangeDateNode.InnerText))
                {
                    return DateTime.ParseExact(lastChangeDateNode.InnerText, "yyyy-MM-dd",
                                                CultureInfo.InvariantCulture
                                                        .DateTimeFormat);
                }
                return null;
            });

            mapper.AddFunctionMap(p => p.Permits[0].LineCount, node =>
            {
                XmlNode lineCountNode =
                        node.SelectSingleNode(
                            "./*[local-name()='lineCount']");

                if (lineCountNode != null &&
                    !string.IsNullOrWhiteSpace(lineCountNode.InnerText))
                {
                    short result;
                    if (short.TryParse(lineCountNode.InnerText, out result))
                        return result;
                }
                return null;
            });

            mapper.AddFunctionMap(p => p.Permits[0].ListChangeDate, node =>
            {
                XmlNode listChangeDateNode =
                        node.SelectSingleNode(
                            "./*[local-name()='listChangeDate']");
                if (listChangeDateNode != null &&
                    !string.IsNullOrWhiteSpace(listChangeDateNode.InnerText))
                {
                    return DateTime.ParseExact(listChangeDateNode.InnerText, "yyyy-MM-dd",
                                                CultureInfo.InvariantCulture
                                                        .DateTimeFormat);
                }
                return null;
            });

            mapper.AddPropertyMap(p => p.Permits[0].OrgUnitShortName, "./*[local-name()='orgUnitShortName']");
            mapper.AddPropertyMap(p => p.Permits[0].PermitNumber, "./*[local-name()='permitNumber']");
            mapper.AddPropertyMap(p => p.Permits[0].PermitStatus, "./*[local-name()='permitStatus']");
            mapper.AddPropertyMap(p => p.Permits[0].PermitStatusCode, "./*[local-name()='permitStatusCode']");
            mapper.AddPropertyMap(p => p.Permits[0].Remarks, "./*[local-name()='remarks']");

            mapper.AddFunctionMap(p => p.Permits[0].StampNumber, node =>
            {
                XmlNode stampNumberNode =
                        node.SelectSingleNode(
                            "./*[local-name()='stampNumber']");

                if (stampNumberNode != null &&
                    !string.IsNullOrWhiteSpace(stampNumberNode.InnerText))
                {
                    short result;
                    if (short.TryParse(stampNumberNode.InnerText, out result))
                        return result;
                }
                return null;
            });

            mapper.AddPropertyMap(p => p.Permits[0].SubjectIdentNumber, "./*[local-name()='subjectIdentNumber']");

            mapper.AddFunctionMap(p => p.Permits[0].ValidTo, node =>
            {
                XmlNode validToNode =
                        node.SelectSingleNode(
                            "./*[local-name()='validTo']");
                if (validToNode != null &&
                    !string.IsNullOrWhiteSpace(validToNode.InnerText))
                {
                    return DateTime.ParseExact(validToNode.InnerText, "yyyy-MM-dd",
                                                CultureInfo.InvariantCulture
                                                        .DateTimeFormat);
                }
                return null;
            });

            return mapper;
        }

        /// <summary>
        /// Справка по лице за вписвания като председател на комисия/технически специалист в регистрирани пунктове за технически прегледи.
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="accessMatrix"></param>
        /// <param name="aditionalParameters"></param>
        /// <returns></returns>
        public CommonSignedResponse<PermitInspectorsRequestType, PermitInspectorsResponse> GetReport2PermitInspectors(PermitInspectorsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                if (argument == null || string.IsNullOrEmpty(argument.IdentNumber))
                {
                    throw new FaultException("Полето ЕГН е задължително!");
                }
                var serviceClient = GetClient();

                ServiceXMLShemas.permitInspectorsRequest param = new ServiceXMLShemas.permitInspectorsRequest();
                param.context = aditionalParameters.CallContext.ToString();
                param.identNumber = argument.IdentNumber;
                string request = param.XmlSerialize();
                
                string responseString = GetResponse(serviceClient, request, Report2PermitInspectorsMethodName.Value, id, aditionalParameters).Result;

                PermitInspectorsResponse result = new PermitInspectorsResponse();

                if (!string.IsNullOrEmpty(responseString))
                {
                    XElement resultXmlElement = XDocument.Parse(responseString).Root;
                    XPathMapper<PermitInspectorsResponse> responseMapper = CreatePermitInspectorsResponseMapper(accessMatrix);
                    responseMapper.Map(resultXmlElement, result);
                }
                return
                    SigningUtils.CreateAndSign(
                        argument,
                        result,
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

        private static XPathMapper<PermitInspectorsResponse> CreatePermitInspectorsResponseMapper(AccessMatrix accessMatrix)
        {
            XPathMapper<PermitInspectorsResponse> mapper =
                new XPathMapper<PermitInspectorsResponse>(accessMatrix);

            mapper.AddCollectionMap(p => p.Inspectors, "/*[local-name()='permitInspectorsResponse']/*[local-name()='inspectors']/*[local-name()='inspector']");
            mapper.AddPropertyMap(p => p.Inspectors[0].CurrentStatus, "./*[local-name()='currentStatus']");

            mapper.AddFunctionMap(p => p.Inspectors[0].IsChairman, node =>
            {
                XmlNode isChairmanNode =
                        node.SelectSingleNode(
                            "./*[local-name()='isChairman']");

                if (isChairmanNode != null &&
                    !string.IsNullOrWhiteSpace(isChairmanNode.InnerText))
                {
                    bool result;
                    if (bool.TryParse(isChairmanNode.InnerText, out result))
                        return result;
                }
                return null;
            });

            mapper.AddPropertyMap(p => p.Inspectors[0].SubjectFullName, "./*[local-name()='subjectFullName']");
            mapper.AddPropertyMap(p => p.Inspectors[0].SubjectIdentNumber, "./*[local-name()='subjectIdentNumber']");

            mapper.AddFunctionMap(p => p.Inspectors[0].Permit, node =>
            {
                XmlNode permitNode =
                        node.SelectSingleNode(
                            "./*[local-name()='permit']");

                if (permitNode != null &&
                    !string.IsNullOrWhiteSpace(permitNode.InnerText))
                {
                    return new PermitDto();
                }
                return null;
            });

            mapper.AddFunctionMap(p => p.Inspectors[0].Permit.CloseDate, node =>
            {
                XmlNode closeDateNode =
                        node.SelectSingleNode(
                            "./*[local-name()='permit']/*[local-name()='closeDate']");
                if (closeDateNode != null &&
                    !string.IsNullOrWhiteSpace(closeDateNode.InnerText))
                {
                    return DateTime.ParseExact(closeDateNode.InnerText, "yyyy-MM-dd",
                                                CultureInfo.InvariantCulture
                                                        .DateTimeFormat);
                }
                return null;
            });

            mapper.AddPropertyMap(p => p.Inspectors[0].Permit.CloseReason, "./*[local-name()='permit']/*[local-name()='closeReason']");

            mapper.AddFunctionMap(p => p.Inspectors[0].Permit.FirstRegDate, node =>
            {
                XmlNode firstRegDateNode =
                        node.SelectSingleNode(
                            "./*[local-name()='permit']/*[local-name()='firstRegDate']");
                if (firstRegDateNode != null &&
                    !string.IsNullOrWhiteSpace(firstRegDateNode.InnerText))
                {
                    return DateTime.ParseExact(firstRegDateNode.InnerText, "yyyy-MM-dd",
                                                CultureInfo.InvariantCulture
                                                        .DateTimeFormat);
                }
                return null;
            });

            mapper.AddFunctionMap(p => p.Inspectors[0].Permit.InspectionDate, node =>
            {
                XmlNode inspectionDateNode =
                        node.SelectSingleNode(
                            "./*[local-name()='permit']/*[local-name()='inspectionDate']");
                if (inspectionDateNode != null &&
                    !string.IsNullOrWhiteSpace(inspectionDateNode.InnerText))
                {
                    return DateTime.ParseExact(inspectionDateNode.InnerText, "yyyy-MM-dd",
                                                CultureInfo.InvariantCulture
                                                        .DateTimeFormat);
                }
                return null;
            });

            mapper.AddPropertyMap(p => p.Inspectors[0].Permit.InspectionProtocols, "./*[local-name()='permit']/*[local-name()='inspectionProtocols']");
            mapper.AddPropertyMap(p => p.Inspectors[0].Permit.KtpAddress, "./*[local-name()='permit']/*[local-name()='ktpAddress']");
            mapper.AddPropertyMap(p => p.Inspectors[0].Permit.KtpCategoryLabel, "./*[local-name()='permit']/*[local-name()='ktpCategoryLabel']");
            mapper.AddPropertyMap(p => p.Inspectors[0].Permit.KtpCityName, "./*[local-name()='permit']/*[local-name()='ktpCityName']");
            mapper.AddPropertyMap(p => p.Inspectors[0].Permit.KtpName, "./*[local-name()='permit']/*[local-name()='ktpName']");

            mapper.AddFunctionMap(p => p.Inspectors[0].Permit.LastChangeDate, node =>
            {
                XmlNode lastChangeDateNode =
                        node.SelectSingleNode(
                            "./*[local-name()='permit']/*[local-name()='lastChangeDate']");
                if (lastChangeDateNode != null &&
                    !string.IsNullOrWhiteSpace(lastChangeDateNode.InnerText))
                {
                    return DateTime.ParseExact(lastChangeDateNode.InnerText, "yyyy-MM-dd",
                                                CultureInfo.InvariantCulture
                                                        .DateTimeFormat);
                }
                return null;
            });

            mapper.AddFunctionMap(p => p.Inspectors[0].Permit.LineCount, node =>
            {
                XmlNode lineCountNode =
                        node.SelectSingleNode(
                            "./*[local-name()='permit']/*[local-name()='lineCount']");

                if (lineCountNode != null &&
                    !string.IsNullOrWhiteSpace(lineCountNode.InnerText))
                {
                    short result;
                    if (short.TryParse(lineCountNode.InnerText, out result))
                        return result;
                }
                return null;
            });

            mapper.AddFunctionMap(p => p.Inspectors[0].Permit.ListChangeDate, node =>
            {
                XmlNode listChangeDateNode =
                        node.SelectSingleNode(
                            "./*[local-name()='permit']/*[local-name()='listChangeDate']");
                if (listChangeDateNode != null &&
                    !string.IsNullOrWhiteSpace(listChangeDateNode.InnerText))
                {
                    return DateTime.ParseExact(listChangeDateNode.InnerText, "yyyy-MM-dd",
                                                CultureInfo.InvariantCulture
                                                        .DateTimeFormat);
                }
                return null;
            });

            mapper.AddPropertyMap(p => p.Inspectors[0].Permit.OrgUnitShortName, "./*[local-name()='permit']/*[local-name()='orgUnitShortName']");
            mapper.AddPropertyMap(p => p.Inspectors[0].Permit.PermitNumber, "./*[local-name()='permit']/*[local-name()='permitNumber']");
            mapper.AddPropertyMap(p => p.Inspectors[0].Permit.PermitStatus, "./*[local-name()='permit']/*[local-name()='permitStatus']");
            mapper.AddPropertyMap(p => p.Inspectors[0].Permit.PermitStatusCode, "./*[local-name()='permit']/*[local-name()='permitStatusCode']");
            mapper.AddPropertyMap(p => p.Inspectors[0].Permit.Remarks, "./*[local-name()='permit']/*[local-name()='remarks']");

            mapper.AddFunctionMap(p => p.Inspectors[0].Permit.StampNumber, node =>
            {
                XmlNode stampNumberNode =
                        node.SelectSingleNode(
                            "./*[local-name()='permit']/*[local-name()='stampNumber']");

                if (stampNumberNode != null &&
                    !string.IsNullOrWhiteSpace(stampNumberNode.InnerText))
                {
                    short result;
                    if (short.TryParse(stampNumberNode.InnerText, out result))
                        return result;
                }
                return null;
            });

            mapper.AddPropertyMap(p => p.Inspectors[0].Permit.SubjectIdentNumber, "./*[local-name()='permit']/*[local-name()='subjectIdentNumber']");

            mapper.AddFunctionMap(p => p.Inspectors[0].Permit.ValidTo, node =>
            {
                XmlNode validToNode =
                        node.SelectSingleNode(
                            "./*[local-name()='permit']/*[local-name()='validTo']");
                if (validToNode != null &&
                    !string.IsNullOrWhiteSpace(validToNode.InnerText))
                {
                    return DateTime.ParseExact(validToNode.InnerText, "yyyy-MM-dd",
                                                CultureInfo.InvariantCulture
                                                        .DateTimeFormat);
                }
                return null;
            });

            return mapper;
        }

        /// <summary>
        /// Справка по ЕИК за обслужени автомобили за период.
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="accessMatrix"></param>
        /// <param name="aditionalParameters"></param>
        /// <returns></returns>
        public CommonSignedResponse<PermitsInspectionCountRequestType, PermitsInspectionCountResponse> GetReport3PermitsInspectionCount(PermitsInspectionCountRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                if (argument == null || string.IsNullOrEmpty(argument.IdentNumber))
                {
                    throw new FaultException("Полето ЕИК/БУЛСТАТ е задължително!");
                }
                var serviceClient = GetClient();

                ServiceXMLShemas.permitsInspectionCountReportRequest param = new ServiceXMLShemas.permitsInspectionCountReportRequest();
                param.context = aditionalParameters.CallContext.ToString();
                param.identNumber = argument.IdentNumber;
                param.dateFrom = argument.DateFrom;
                param.dateFromSpecified = argument.DateFromSpecified;
                param.dateTo = argument.DateTo;
                param.dateToSpecified = argument.DateToSpecified;

                string request = param.XmlSerialize();
                string responseString = GetResponse(serviceClient, request, Report3PermitsInspectionCountReportMethodName.Value, id, aditionalParameters).Result;

                PermitsInspectionCountResponse result = new PermitsInspectionCountResponse();

                if (!string.IsNullOrEmpty(responseString))
                {
                    XElement resultXmlElement = XDocument.Parse(responseString).Root;

                    XPathMapper<PermitsInspectionCountResponse> responseMapper = CreatePermitsInspectionCountResponseMapper(accessMatrix);
                    
                    responseMapper.Map(resultXmlElement, result);
                }

                return
                    SigningUtils.CreateAndSign(
                        argument,
                        result,
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

        private static XPathMapper<PermitsInspectionCountResponse> CreatePermitsInspectionCountResponseMapper(AccessMatrix accessMatrix)
        {
            XPathMapper<PermitsInspectionCountResponse> mapper =
                new XPathMapper<PermitsInspectionCountResponse>(accessMatrix);

            mapper.AddCollectionMap(p => p.PermitsInspectionsCounts, "/*[local-name()='permitsInspectionCountResponse']/*[local-name()='permitsInspectionsCounts']/*[local-name()='permitInspectionsCount']");

            mapper.AddFunctionMap(p => p.PermitsInspectionsCounts[0].CloseDate, node =>
            {
                XmlNode closeDateNode =
                        node.SelectSingleNode(
                            "./*[local-name()='closeDate']");
                if (closeDateNode != null &&
                    !string.IsNullOrWhiteSpace(closeDateNode.InnerText))
                {
                    return DateTime.ParseExact(closeDateNode.InnerText, "yyyy-MM-dd",
                                                CultureInfo.InvariantCulture
                                                        .DateTimeFormat);
                }
                return null;
            });

            mapper.AddPropertyMap(p => p.PermitsInspectionsCounts[0].CloseReason, "./*[local-name()='closeReason']");

            mapper.AddFunctionMap(p => p.PermitsInspectionsCounts[0].FirstRegDate, node =>
            {
                XmlNode firstRegDateNode =
                        node.SelectSingleNode(
                            "./*[local-name()='firstRegDate']");
                if (firstRegDateNode != null &&
                    !string.IsNullOrWhiteSpace(firstRegDateNode.InnerText))
                {
                    return DateTime.ParseExact(firstRegDateNode.InnerText, "yyyy-MM-dd",
                                                CultureInfo.InvariantCulture
                                                        .DateTimeFormat);
                }
                return null;
            });

            mapper.AddPropertyMap(p => p.PermitsInspectionsCounts[0].InspectionCount, "./*[local-name()='inspectionCount']");

            mapper.AddFunctionMap(p => p.PermitsInspectionsCounts[0].InspectionDate, node =>
            {
                XmlNode inspectionDateNode =
                        node.SelectSingleNode(
                            "./*[local-name()='inspectionDate']");
                if (inspectionDateNode != null &&
                    !string.IsNullOrWhiteSpace(inspectionDateNode.InnerText))
                {
                    return DateTime.ParseExact(inspectionDateNode.InnerText, "yyyy-MM-dd",
                                                CultureInfo.InvariantCulture
                                                        .DateTimeFormat);
                }
                return null;
            });

            mapper.AddPropertyMap(p => p.PermitsInspectionsCounts[0].InspectionProtocols, "./*[local-name()='inspectionProtocols']");
            mapper.AddPropertyMap(p => p.PermitsInspectionsCounts[0].KtpAddress, "./*[local-name()='ktpAddress']");
            mapper.AddPropertyMap(p => p.PermitsInspectionsCounts[0].KtpCategoryLabel, "./*[local-name()='ktpCategoryLabel']");
            mapper.AddPropertyMap(p => p.PermitsInspectionsCounts[0].KtpCityName, "./*[local-name()='ktpCityName']");
            mapper.AddPropertyMap(p => p.PermitsInspectionsCounts[0].KtpName, "./*[local-name()='ktpName']");

            mapper.AddFunctionMap(p => p.PermitsInspectionsCounts[0].LastChangeDate, node =>
            {
                XmlNode lastChangeDateNode =
                        node.SelectSingleNode(
                            "./*[local-name()='lastChangeDate']");
                if (lastChangeDateNode != null &&
                    !string.IsNullOrWhiteSpace(lastChangeDateNode.InnerText))
                {
                    return DateTime.ParseExact(lastChangeDateNode.InnerText, "yyyy-MM-dd",
                                                CultureInfo.InvariantCulture
                                                        .DateTimeFormat);
                }
                return null;
            });

            mapper.AddFunctionMap(p => p.PermitsInspectionsCounts[0].LineCount, node =>
            {
                XmlNode lineCountNode =
                        node.SelectSingleNode(
                            "./*[local-name()='lineCount']");

                if (lineCountNode != null &&
                    !string.IsNullOrWhiteSpace(lineCountNode.InnerText))
                {
                    short result;
                    if (short.TryParse(lineCountNode.InnerText, out result))
                        return result;
                }
                return null;
            });

            mapper.AddFunctionMap(p => p.PermitsInspectionsCounts[0].ListChangeDate, node =>
            {
                XmlNode listChangeDateNode =
                        node.SelectSingleNode(
                            "./*[local-name()='listChangeDate']");
                if (listChangeDateNode != null &&
                    !string.IsNullOrWhiteSpace(listChangeDateNode.InnerText))
                {
                    return DateTime.ParseExact(listChangeDateNode.InnerText, "yyyy-MM-dd",
                                                CultureInfo.InvariantCulture
                                                        .DateTimeFormat);
                }
                return null;
            });

            mapper.AddPropertyMap(p => p.PermitsInspectionsCounts[0].OrgUnitShortName, "./*[local-name()='orgUnitShortName']");
            mapper.AddPropertyMap(p => p.PermitsInspectionsCounts[0].PermitNumber, "./*[local-name()='permitNumber']");
            mapper.AddPropertyMap(p => p.PermitsInspectionsCounts[0].PermitStatus, "./*[local-name()='permitStatus']");
            mapper.AddPropertyMap(p => p.PermitsInspectionsCounts[0].PermitStatusCode, "./*[local-name()='permitStatusCode']");
            mapper.AddPropertyMap(p => p.PermitsInspectionsCounts[0].Remarks, "./*[local-name()='remarks']");

            mapper.AddFunctionMap(p => p.PermitsInspectionsCounts[0].StampNumber, node =>
            {
                XmlNode stampNumberNode =
                        node.SelectSingleNode(
                            "./*[local-name()='stampNumber']");

                if (stampNumberNode != null &&
                    !string.IsNullOrWhiteSpace(stampNumberNode.InnerText))
                {
                    short result;
                    if (short.TryParse(stampNumberNode.InnerText, out result))
                        return result;
                }
                return null;
            });

            mapper.AddPropertyMap(p => p.PermitsInspectionsCounts[0].SubjectIdentNumber, "./*[local-name()='subjectIdentNumber']");

            mapper.AddFunctionMap(p => p.PermitsInspectionsCounts[0].ValidTo, node =>
            {
                XmlNode validToNode =
                        node.SelectSingleNode(
                            "./*[local-name()='validTo']");
                if (validToNode != null &&
                    !string.IsNullOrWhiteSpace(validToNode.InnerText))
                {
                    return DateTime.ParseExact(validToNode.InnerText, "yyyy-MM-dd",
                                                CultureInfo.InvariantCulture
                                                        .DateTimeFormat);
                }
                return null;
            });

            return mapper;
        }

        /// <summary>
        /// Справка за извършен технически преглед по регистрационен номер на автомобил.
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="accessMatrix"></param>
        /// <param name="aditionalParameters"></param>
        /// <returns></returns>
        public CommonSignedResponse<VehicleInspectionRequestType, VehicleInspectionResponse> GetReport4VehicleInspection(VehicleInspectionRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                if(argument == null || string.IsNullOrEmpty(argument.RegNumber))
                {
                    throw new FaultException("Полето регистрационен номер на автомобил е задължително!");
                }
                var serviceClient = GetClient();

                ServiceXMLShemas.vehicleInspectionRequest param = new ServiceXMLShemas.vehicleInspectionRequest();
                param.context = aditionalParameters.CallContext.ToString();
                param.regNumber = argument.RegNumber;
                string request = param.XmlSerialize();

                var taskResult = GetResponse(serviceClient, request, Report4VehicleInspectionMethodName.Value, id, aditionalParameters);
                taskResult.Wait();
                string responseString = taskResult.Result;

                VehicleInspectionResponse result = new VehicleInspectionResponse();

                if (!string.IsNullOrEmpty(responseString))
                {
                    XElement resultXmlElement = XDocument.Parse(responseString).Root;
                    XPathMapper<VehicleInspectionResponse> responseMapper = CreateVehicleInspectionResponseMapper(accessMatrix);
                    responseMapper.Map(resultXmlElement, result);
                }
                else
                {
                    result.Chairman = null;
                    result.Permit = null;
                    result.Member = null;
                }

                return
                    SigningUtils.CreateAndSign(
                        argument,
                        result,
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

        /// <summary>
        /// Справка за проверка на автентичност на стикер за технически преглед.
        /// </summary>
        /// <param name="accessMatrix"></param>
        /// <returns></returns>
        private static XPathMapper<VehicleInspectionResponse> CreateVehicleInspectionResponseMapper(AccessMatrix accessMatrix)
        {
            XPathMapper<VehicleInspectionResponse> mapper =
                new XPathMapper<VehicleInspectionResponse>(accessMatrix);

            mapper.AddFunctionMap(p => p.Chairman, node =>
            {
                XmlNode chairmanNode =
                        node.SelectSingleNode(
                            "/*[local-name()='vehicleInspectionResponse']/*[local-name()='chairman']");
                if (chairmanNode != null &&
                    !string.IsNullOrWhiteSpace(chairmanNode.InnerText))
                {
                    return new PermitInspectorDto();
                }
                return null;
            });

            mapper.AddPropertyMap(p => p.Chairman.CurrentStatus, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='chairman']/*[local-name()='currentStatus']");

            mapper.AddFunctionMap(p => p.Chairman.IsChairman, node =>
            {
                XmlNode isChairmanNode =
                        node.SelectSingleNode(
                            "/*[local-name()='vehicleInspectionResponse']/*[local-name()='chairman']/*[local-name()='isChairman']");

                if (isChairmanNode != null &&
                    !string.IsNullOrWhiteSpace(isChairmanNode.InnerText))
                {
                    bool result;
                    if (bool.TryParse(isChairmanNode.InnerText, out result))
                        return result;
                }
                return null;
            });

            mapper.AddPropertyMap(p => p.Chairman.SubjectFullName, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='chairman']/*[local-name()='subjectFullName']");
            mapper.AddPropertyMap(p => p.Chairman.SubjectIdentNumber, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='chairman']/*[local-name()='subjectIdentNumber']");
            mapper.AddPropertyMap(p => p.Conclusion, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='conclusion']");
            mapper.AddPropertyMap(p => p.CurrentStatus, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='currentStatus']");

            mapper.AddFunctionMap(p => p.EndDateTime, node =>
            {
                XmlNode endDateTimeNode =
                        node.SelectSingleNode(
                            "/*[local-name()='vehicleInspectionResponse']/*[local-name()='endDateTime']");
                if (endDateTimeNode != null &&
                    !string.IsNullOrWhiteSpace(endDateTimeNode.InnerText))
                {
                    return DateTime.ParseExact(endDateTimeNode.InnerText, "yyyy-MM-ddTHH:mm:ss.fff",
                                                CultureInfo.InvariantCulture
                                                        .DateTimeFormat);
                }
                return null;
            });

            mapper.AddFunctionMap(p => p.InspectionDateTime, node =>
            {
                XmlNode inspectionDateTimeNode =
                        node.SelectSingleNode(
                            "/*[local-name()='vehicleInspectionResponse']/*[local-name()='inspectionDateTime']");
                if (inspectionDateTimeNode != null &&
                    !string.IsNullOrWhiteSpace(inspectionDateTimeNode.InnerText))
                {
                    return DateTime.ParseExact(inspectionDateTimeNode.InnerText, "yyyy-MM-ddTHH:mm:ss.fff",
                                                CultureInfo.InvariantCulture
                                                        .DateTimeFormat);
                }
                return null;
            });

            mapper.AddFunctionMap(p => p.Member, node =>
            {
                XmlNode chairmanNode =
                        node.SelectSingleNode(
                            "/*[local-name()='vehicleInspectionResponse']/*[local-name()='member']");
                if (chairmanNode != null &&
                    !string.IsNullOrWhiteSpace(chairmanNode.InnerText))
                {
                    return new PermitInspectorDto();
                }
                return null;
            });

            mapper.AddPropertyMap(p => p.Member.CurrentStatus, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='member']/*[local-name()='currentStatus']");

            mapper.AddFunctionMap(p => p.Member.IsChairman, node =>
            {
                XmlNode isChairmanNode =
                        node.SelectSingleNode(
                            "/*[local-name()='vehicleInspectionResponse']/*[local-name()='member']/*[local-name()='isChairman']");

                if (isChairmanNode != null &&
                    !string.IsNullOrWhiteSpace(isChairmanNode.InnerText))
                {
                    bool result;
                    if (bool.TryParse(isChairmanNode.InnerText, out result))
                        return result;
                }
                return null;
            });

            mapper.AddPropertyMap(p => p.Member.SubjectFullName, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='member']/*[local-name()='subjectFullName']");
            mapper.AddPropertyMap(p => p.Member.SubjectIdentNumber, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='member']/*[local-name()='subjectIdentNumber']");
            mapper.AddPropertyMap(p => p.NextInspectionDate, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='nextInspectionDate']");

            mapper.AddFunctionMap(p => p.Permit, node =>
            {
                XmlNode chairmanNode =
                        node.SelectSingleNode(
                            "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']");
                if (chairmanNode != null &&
                    !string.IsNullOrWhiteSpace(chairmanNode.InnerText))
                {
                    return new PermitDto();
                }
                return null;
            });

            mapper.AddFunctionMap(p => p.Permit.CloseDate, node =>
            {
                XmlNode closeDateNode =
                        node.SelectSingleNode(
                            "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='closeDate']");
                if (closeDateNode != null &&
                    !string.IsNullOrWhiteSpace(closeDateNode.InnerText))
                {
                    return DateTime.ParseExact(closeDateNode.InnerText, "yyyy-MM-dd",
                                                CultureInfo.InvariantCulture
                                                        .DateTimeFormat);
                }
                return null;
            });

            mapper.AddPropertyMap(p => p.Permit.CloseReason, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='closeReason']");

            mapper.AddFunctionMap(p => p.Permit.FirstRegDate, node =>
            {
                XmlNode firstRegDateNode =
                        node.SelectSingleNode(
                            "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='firstRegDate']");
                if (firstRegDateNode != null &&
                    !string.IsNullOrWhiteSpace(firstRegDateNode.InnerText))
                {
                    return DateTime.ParseExact(firstRegDateNode.InnerText, "yyyy-MM-dd",
                                                CultureInfo.InvariantCulture
                                                        .DateTimeFormat);
                }
                return null;
            });

            mapper.AddFunctionMap(p => p.Permit.InspectionDate, node =>
            {
                XmlNode inspectionDateNode =
                        node.SelectSingleNode(
                            "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='inspectionDate']");
                if (inspectionDateNode != null &&
                    !string.IsNullOrWhiteSpace(inspectionDateNode.InnerText))
                {
                    return DateTime.ParseExact(inspectionDateNode.InnerText, "yyyy-MM-dd",
                                                CultureInfo.InvariantCulture
                                                        .DateTimeFormat);
                }
                return null;
            });

            mapper.AddPropertyMap(p => p.Permit.InspectionProtocols, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='inspectionProtocols']");
            mapper.AddPropertyMap(p => p.Permit.KtpAddress, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='ktpAddress']");
            mapper.AddPropertyMap(p => p.Permit.KtpCategoryLabel, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='ktpCategoryLabel']");
            mapper.AddPropertyMap(p => p.Permit.KtpCityName, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='ktpCityName']");
            mapper.AddPropertyMap(p => p.Permit.KtpName, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='ktpName']");

            mapper.AddFunctionMap(p => p.Permit.LastChangeDate, node =>
            {
                XmlNode lastChangeDateNode =
                        node.SelectSingleNode(
                            "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='lastChangeDate']");
                if (lastChangeDateNode != null &&
                    !string.IsNullOrWhiteSpace(lastChangeDateNode.InnerText))
                {
                    return DateTime.ParseExact(lastChangeDateNode.InnerText, "yyyy-MM-dd",
                                                CultureInfo.InvariantCulture
                                                        .DateTimeFormat);
                }
                return null;
            });

            mapper.AddFunctionMap(p => p.Permit.LineCount, node =>
            {
                XmlNode lineCountNode =
                        node.SelectSingleNode(
                            "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='lineCount']");

                if (lineCountNode != null &&
                    !string.IsNullOrWhiteSpace(lineCountNode.InnerText))
                {
                    short result;
                    if (short.TryParse(lineCountNode.InnerText, out result))
                        return result;
                }
                return null;
            });

            mapper.AddFunctionMap(p => p.Permit.ListChangeDate, node =>
            {
                XmlNode listChangeDateNode =
                        node.SelectSingleNode(
                            "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='listChangeDate']");
                if (listChangeDateNode != null &&
                    !string.IsNullOrWhiteSpace(listChangeDateNode.InnerText))
                {
                    return DateTime.ParseExact(listChangeDateNode.InnerText, "yyyy-MM-dd",
                                                CultureInfo.InvariantCulture
                                                        .DateTimeFormat);
                }
                return null;
            });

            mapper.AddPropertyMap(p => p.Permit.OrgUnitShortName, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='orgUnitShortName']");
            mapper.AddPropertyMap(p => p.Permit.PermitNumber, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='permitNumber']");
            mapper.AddPropertyMap(p => p.Permit.PermitStatus, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='permitStatus']");
            mapper.AddPropertyMap(p => p.Permit.PermitStatusCode, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='permitStatusCode']");
            mapper.AddPropertyMap(p => p.Permit.Remarks, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='remarks']");

            mapper.AddFunctionMap(p => p.Permit.StampNumber, node =>
            {
                XmlNode stampNumberNode =
                        node.SelectSingleNode(
                            "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='stampNumber']");

                if (stampNumberNode != null &&
                    !string.IsNullOrWhiteSpace(stampNumberNode.InnerText))
                {
                    short result;
                    if (short.TryParse(stampNumberNode.InnerText, out result))
                        return result;
                }
                return null;
            });

            mapper.AddPropertyMap(p => p.Permit.SubjectIdentNumber, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='subjectIdentNumber']");

            mapper.AddFunctionMap(p => p.Permit.ValidTo, node =>
            {
                XmlNode validToNode =
                        node.SelectSingleNode(
                            "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='validTo']");
                if (validToNode != null &&
                    !string.IsNullOrWhiteSpace(validToNode.InnerText))
                {
                    return DateTime.ParseExact(validToNode.InnerText, "yyyy-MM-dd",
                                                CultureInfo.InvariantCulture
                                                        .DateTimeFormat);
                }
                return null;
            });

            mapper.AddFunctionMap(p => p.ProtocolNumber, node =>
            {
                XmlNode protocolNumberNode =
                        node.SelectSingleNode(
                            "/*[local-name()='vehicleInspectionResponse']/*[local-name()='protocolNumber']");

                if (protocolNumberNode != null &&
                    !string.IsNullOrWhiteSpace(protocolNumberNode.InnerText))
                {
                    long result;
                    if (long.TryParse(protocolNumberNode.InnerText, out result))
                        return result;
                }
                return null;
            });

            mapper.AddPropertyMap(p => p.RegNumber, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='regNumber']");

            mapper.AddFunctionMap(p => p.StickerNumber, node =>
            {
                XmlNode stickerNumberNode =
                        node.SelectSingleNode(
                            "/*[local-name()='vehicleInspectionResponse']/*[local-name()='stickerNumber']");

                if (stickerNumberNode != null &&
                    !string.IsNullOrWhiteSpace(stickerNumberNode.InnerText))
                {
                    long result;
                    if (long.TryParse(stickerNumberNode.InnerText, out result))
                        return result;
                }
                return null;
            });

            return mapper;
        }

        public CommonSignedResponse<VehicleInspectionStickerRequestType, VehicleInspectionResponse> GetReport5VehicleInspectionSticker(VehicleInspectionStickerRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                if (argument == null || string.IsNullOrEmpty(argument.RegNumber))
                {
                    throw new FaultException("Полето регистрационен номер на автомобил е задължително!");
                }
                if (!argument.StickerNumberSpecified)
                {
                    throw new FaultException("Полето номер на стикер е задължително!");
                }
                var serviceClient = GetClient();

                ServiceXMLShemas.vehicleInspectionStickerRequest param = new ServiceXMLShemas.vehicleInspectionStickerRequest();
                param.context = aditionalParameters.CallContext.ToString();
                param.regNumber = argument.RegNumber;
                param.stickerNumber = argument.StickerNumber;
                param.stickerNumberSpecified = argument.StickerNumberSpecified;
                string request = param.XmlSerialize();

                string responseString = GetResponse(serviceClient, request, Report5VehicleInspectionStickerMethodName.Value, id, aditionalParameters).Result;
                
                XPathMapper<VehicleInspectionResponse> responseMapper = CreateVehicleInspectionResponseMapper(accessMatrix);
                VehicleInspectionResponse result = new VehicleInspectionResponse();
                if (!string.IsNullOrEmpty(responseString))
                {

                    try
                    {
                        XElement resultXmlElement = XDocument.Parse(responseString).Root;
                        responseMapper.Map(resultXmlElement, result);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error parsing the response from register source: " + responseString);
                    }
                }
                else
                {
                    result.Chairman = null;
                    result.Permit = null;
                    result.Member = null;
                }
                
               
                return
                    SigningUtils.CreateAndSign(
                        argument,
                        result,
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


    }
}
