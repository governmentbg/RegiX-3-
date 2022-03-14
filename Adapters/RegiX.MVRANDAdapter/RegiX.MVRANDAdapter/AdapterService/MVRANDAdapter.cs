using System;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.WebServiceAdapterService;
using TechnoLogica.RegiX.Common.Utils;
using System.Xml;
using System.IO;
using System.Globalization;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.MVRANDAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(MVRANDAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(MVRANDAdapter), typeof(IAdapterService))]
    public class MVRANDAdapter : SoapServiceBaseAdapterService, IMVRANDAdapter, IAdapterService
    {
        //[Export(typeof(ParameterInfo))]
        //public static ParameterInfo<string> WebServiceUrl =
        //                   new ParameterInfo<string>("http://10.254.130.25:7003/KAT/services/documentsInfo")
        //                   {
        //                       Key = Constants.WebServiceUrlParameterKeyName,
        //                       Description = "Web Service Url",
        //                       OwnerAssembly = typeof(MVRANDAdapter).Assembly
        //                   };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(MVRANDAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrl =
                          new ParameterInfo<string>("http://localhost:64635/MVRANDMockService.svc")
                          {
                              Key = Constants.WebServiceUrlParameterKeyName,
                              Description = "Web Service Url",
                              OwnerAssembly = typeof(MVRANDAdapter).Assembly
                          };
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(MVRANDAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrlPaymentNotifications =
                          new ParameterInfo<string>("http://172.31.14.11:4780/KAT/services/documentsInfo?wsdl")
                          {
                              Key = "WebServiceUrlPaymentNotifications",
                              Description = "Web Service Url for SendPaymentNotification",
                              OwnerAssembly = typeof(MVRANDAdapter).Assembly
                          };


        public CommonSignedResponse<ObligationDocumentsRequestType, ObligationDocumentsResponseType> GetObligationDocuments(ObligationDocumentsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                #region Request
                //MVR Wants to be sure that certain CallContext fields are not null. They will be always not null when request is made using RegiXClient
                //but if external system integrates with the adapter and send empty required field in CallContext, we should throw an axception
                // and not allow the operation to continue.
                try
                {
                    ValidateCallContext(additionalParameters);
                }
                catch (ArgumentException ex)
                {
                    LogError(additionalParameters, ex, new { Request = argument.XmlSerialize(), Guid = id });
                    throw ex;
                }

                MVRANDServiceReference.ObligationDocumentsRequest externalRequest = new MVRANDServiceReference.ObligationDocumentsRequest();
                externalRequest.documentSeries = argument.documentSeries;
                externalRequest.documentType = argument.documentType.ToString();
                externalRequest.documentNumber = argument.documentNumber;
                externalRequest.initialAmount = argument.initialAmount;
                externalRequest.username = additionalParameters.CallContext.EmployeeIdentifier;
                #endregion


                MVRANDServiceReference.DocumentWebServiceClient client = new MVRANDServiceReference.DocumentWebServiceClient("DocumentWebServicePort", WebServiceUrl.Value);
                var response = client.getObligationDocuments(externalRequest);
                //var response = File.ReadAllText("C:\\Users\\mmarinov\\Desktop\\getObligationDocumentsResponseXML.xml");
                #region Response
                ObligationDocumentsResponseType result = new ObligationDocumentsResponseType();
                try
                {
                    
                    XmlDocument resultXmlDoc = new XmlDocument();
                    var xml = response.XmlSerialize();
                    try
                    {
                        File.WriteAllText("C:\\RegiX\\MVRANDAdapter\\GetObligationDocuments.txt", xml);
                    }
                    catch (Exception ex)
                    {
                        LogError(additionalParameters, ex, new { xml = xml, Guid = id });
                    }

                    resultXmlDoc.LoadXml(xml);
                    XPathMapper<ObligationDocumentsResponseType> mapper = CreateObligationDocumentsMap(accessMatrix);
                    mapper.Map(resultXmlDoc, result);
                }
                catch (Exception ex)
                {
                    LogError(additionalParameters, ex, new { Request = argument.XmlSerialize(), Response = response, Guid = id });
                    ObligationDocumentsResponseType tempresult = new ObligationDocumentsResponseType();
                    ObjectMapper<ObligationDocumentsResponseType, ObligationDocumentsResponseType> selfmapper = CreateObligationDocumentsSelfMapper(accessMatrix);
                    selfmapper.Map(tempresult, result);
                }
                #endregion

                return
                    SigningUtils.CreateAndSign(
                        argument,
                        result,
                        accessMatrix,
                        additionalParameters
                    );
            }
            catch (Exception ex)
            {
                LogError(additionalParameters, ex, new { Request = argument.XmlSerialize(), Guid = id });
                throw ex;
            }
        }

        public CommonSignedResponse<SendPaymentNotificationRequestType, SendPaymentNotificationResponseType> SendPaymentNotification(SendPaymentNotificationRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                #region Request
                //MVR Wants to be sure that certain CallContext fields are not null. They will be always not null when request is made using RegiXClient
                //but if external system integrates with the adapter and send empty required field in CallContext, we should throw an axception
                // and not allow the operation to continue.
                try
                {
                    ValidateCallContext(additionalParameters);
                }
                catch (ArgumentException ex)
                {
                    LogError(additionalParameters, ex, new { Request = argument.XmlSerialize(), Guid = id });
                    throw ex;
                }

                PaymentNotificationServiceReference.PaymentNotificationExternalRequest externalRequest = new PaymentNotificationServiceReference.PaymentNotificationExternalRequest();
                externalRequest.transactionNumber = argument.TransactionNumber;
                externalRequest.documentNumber = argument.DocumentNumber;
                externalRequest.documentSeries = argument.DocumentSeries;
                externalRequest.documentType = argument.DocumentType.ToString();
                externalRequest.paymentAmount = argument.PaymentAmount;
                externalRequest.paymentDate = argument.PaymentDate.ToString("dd/MM/yyyy HH:mm:ss",CultureInfo.InvariantCulture);
                externalRequest.username = additionalParameters.CallContext.EmployeeIdentifier;
                externalRequest.payerPin = argument.PayerPin;
                externalRequest.payerType = argument.PayerTypeSpecified ? argument.PayerType.ToString() : null; 
                externalRequest.systemId = argument.SystemId;
                externalRequest.systemIdSpecified = argument.SystemIdSpecified;
                externalRequest.administrationName = argument.AdministrationName;
                #endregion


                PaymentNotificationServiceReference.DocumentWebServiceClient client = new PaymentNotificationServiceReference.DocumentWebServiceClient
                    (PaymentNotificationServiceReference.DocumentWebServiceClient.EndpointConfiguration.DocumentWebServicePort,
                    WebServiceUrlPaymentNotifications.Value);
                var response = client.sendPaymentNotificationExternalAsync(externalRequest);
                Task.WaitAll();

                #region Response
                SendPaymentNotificationResponseType result = new SendPaymentNotificationResponseType();
                try
                {
                    XmlDocument resultXmlDoc = new XmlDocument();
                    var xml = response.Result.XmlSerialize();
                    resultXmlDoc.LoadXml(xml);
                    XPathMapper<SendPaymentNotificationResponseType> mapper = CreatePaymentNotificationMap(accessMatrix);
                    mapper.Map(resultXmlDoc, result);
                }
                catch (Exception ex)
                {
                    LogError(additionalParameters, ex, new { Request = argument.XmlSerialize(), Response = response, Guid = id });
                    SendPaymentNotificationResponseType tempresult = new SendPaymentNotificationResponseType();
                    ObjectMapper<SendPaymentNotificationResponseType, SendPaymentNotificationResponseType> selfmapper = CreatePaymentNotificationSelfMapper(accessMatrix);
                    selfmapper.Map(tempresult, result);
                }
                #endregion

                return
                    SigningUtils.CreateAndSign(
                        argument,
                        result,
                        accessMatrix,
                        additionalParameters
                    );
            }
            catch (Exception ex)
            {
                LogError(additionalParameters, ex, new { Request = argument.XmlSerialize(), Guid = id });
                throw ex;
            }
        }

        public CommonSignedResponse<GetObligationDocumentsByEGNRequestType, GetObligationDocumentsByEGNResponseType> GetObligationDocumentsByEGN(GetObligationDocumentsByEGNRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                #region Request
                //MVR Wants to be sure that certain CallContext fields are not null. They will be always not null when request is made using RegiXClient
                //but if external system integrates with the adapter and send empty required field in CallContext, we should throw an axception
                // and not allow the operation to continue.
                try
                {
                    ValidateCallContext(additionalParameters);
                }
                catch (ArgumentException ex)
                {
                    LogError(additionalParameters, ex, new { Request = argument.XmlSerialize(), Guid = id });
                    throw ex;
                }

                MVRANDServiceReference.ObligationDocumentsByEgnRequest externalRequest = new MVRANDServiceReference.ObligationDocumentsByEgnRequest();
                externalRequest.egn = argument.EGN;
                externalRequest.username = additionalParameters.CallContext.EmployeeIdentifier;
                #endregion


                MVRANDServiceReference.DocumentWebServiceClient client = new MVRANDServiceReference.DocumentWebServiceClient("DocumentWebServicePort", WebServiceUrl.Value);
                var response = client.getObligationDocumentsByEgn(externalRequest);
                //var response = File.ReadAllText("C:\\Users\\mmarinov\\Desktop\\getObligationDocumentsByEGNResponseXML.xml");
                //var response = File.ReadAllText(@"C:\Users\mmarinov\Desktop\MvrAndReal\GetObligationDocumentsByEGN.txt");
                #region Response
                GetObligationDocumentsByEGNResponseType result = new GetObligationDocumentsByEGNResponseType();
                try
                {

                    XmlDocument resultXmlDoc = new XmlDocument();
                    var xml = response.XmlSerialize();
                    //var xml = response; // For local testing

                    try
                    {
                        File.WriteAllText("C:\\RegiX\\MVRANDAdapter\\GetObligationDocumentsByEGN.txt", xml);
                    }
                    catch (Exception ex)
                    {
                        LogError(additionalParameters, ex, new { xml = xml, Guid = id });
                    }

                    resultXmlDoc.LoadXml(xml);
                    XPathMapper<GetObligationDocumentsByEGNResponseType> mapper = CreateObligationDocumentsByEGNMap(accessMatrix);
                    mapper.Map(resultXmlDoc, result);
                }
                catch (Exception ex)
                {
                    LogError(additionalParameters, ex, new { Request = argument.XmlSerialize(), Response = response, Guid = id });
                    GetObligationDocumentsByEGNResponseType tempresult = new GetObligationDocumentsByEGNResponseType();
                    ObjectMapper<GetObligationDocumentsByEGNResponseType, GetObligationDocumentsByEGNResponseType> selfmapper = CreateObligationDocumentsByEGNSelfMapper(accessMatrix);
                    selfmapper.Map(tempresult, result);
                }
                #endregion

                return
                    SigningUtils.CreateAndSign(
                        argument,
                        result,
                        accessMatrix,
                        additionalParameters
                    );
            }
            catch (Exception ex)
            {
                LogError(additionalParameters, ex, new { Request = argument.XmlSerialize(), Guid = id });
                throw ex;
            }
        }

        public CommonSignedResponse<GetObligationDocumentsByLicenceNumRequestType, GetObligationDocumentsByLicenceNumResponseType> GetObligationDocumentsByLicenceNum(GetObligationDocumentsByLicenceNumRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                #region Request
                //MVR Wants to be sure that certain CallContext fields are not null. They will be always not null when request is made using RegiXClient
                //but if external system integrates with the adapter and send empty required field in CallContext, we should throw an axception
                // and not allow the operation to continue.
                try
                {
                    ValidateCallContext(additionalParameters);
                }
                catch (ArgumentException ex)
                {
                    LogError(additionalParameters, ex, new { Request = argument.XmlSerialize(), Guid = id });
                    throw ex;
                }

                MVRANDServiceReference.ObligationDocumentsByLicenceNumRequest externalRequest = new MVRANDServiceReference.ObligationDocumentsByLicenceNumRequest();
                externalRequest.egn = argument.EGN;
                externalRequest.licenceNum = argument.LicenceNum;
                externalRequest.username = additionalParameters.CallContext.EmployeeIdentifier;
                #endregion


                MVRANDServiceReference.DocumentWebServiceClient client = new MVRANDServiceReference.DocumentWebServiceClient("DocumentWebServicePort", WebServiceUrl.Value);
                var response = client.getObligationDocumentsByLicenceNum(externalRequest);
                //var response = File.ReadAllText("C:\\Users\\mmarinov\\Desktop\\getObligationDocumentsByLicenceNumResponseXML.xml");
                #region Response
                GetObligationDocumentsByLicenceNumResponseType result = new GetObligationDocumentsByLicenceNumResponseType();
                try
                {

                    XmlDocument resultXmlDoc = new XmlDocument();
                    var xml = response.XmlSerialize();

                    try
                    {
                        File.WriteAllText("C:\\RegiX\\MVRANDAdapter\\GetObligationDocumentsByLicenceNum.txt", xml);
                    }
                    catch (Exception ex)
                    {
                        LogError(additionalParameters, ex, new { xml = xml, Guid = id });
                    }

                    resultXmlDoc.LoadXml(xml);
                    XPathMapper<GetObligationDocumentsByLicenceNumResponseType> mapper = CreateObligationDocumentsByLicenceNumMap(accessMatrix);
                    mapper.Map(resultXmlDoc, result);
                }
                catch (Exception ex)
                {
                    LogError(additionalParameters, ex, new { Request = argument.XmlSerialize(), Response = response, Guid = id });
                    GetObligationDocumentsByLicenceNumResponseType tempresult = new GetObligationDocumentsByLicenceNumResponseType();
                    ObjectMapper<GetObligationDocumentsByLicenceNumResponseType, GetObligationDocumentsByLicenceNumResponseType> selfmapper = CreateObligationDocumentsByLicenceNumSelfMapper(accessMatrix);
                    selfmapper.Map(tempresult, result);
                }
                #endregion

                return
                    SigningUtils.CreateAndSign(
                        argument,
                        result,
                        accessMatrix,
                        additionalParameters
                    );
            }
            catch (Exception ex)
            {
                LogError(additionalParameters, ex, new { Request = argument.XmlSerialize(), Guid = id });
                throw ex;
            }
        }

        private static ObjectMapper<ObligationDocumentsResponseType, ObligationDocumentsResponseType> CreateObligationDocumentsSelfMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<ObligationDocumentsResponseType, ObligationDocumentsResponseType> mapper = new ObjectMapper<ObligationDocumentsResponseType, ObligationDocumentsResponseType>(accessMatrix);
            mapper.AddObjectMap((o) => o.Status, (c) => c.Status);
            return mapper;
        }

        private XPathMapper<ObligationDocumentsResponseType> CreateObligationDocumentsMap(AccessMatrix accessMatrix)
        {
            XPathMapper<ObligationDocumentsResponseType> mapper = new XPathMapper<ObligationDocumentsResponseType>(accessMatrix);

            mapper.AddPropertyMap(d => d.Status, "./*[local-name()='ObligationDocumentsResponse']/*[local-name()='status']");
            mapper.AddPropertyMap(d => d.CustomerType, "./*[local-name()='ObligationDocumentsResponse']/*[local-name()='customerType']");
            mapper.AddPropertyMap(d => d.UserPID, "./*[local-name()='ObligationDocumentsResponse']/*[local-name()='userPid']");

            mapper.AddCollectionMap(d => d.ObligationDocuments, "./*[local-name()='ObligationDocumentsResponse']/*[local-name()='allObligations']/*[local-name()='ObligationDocument']");
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].DocumentType, "./*[local-name()='documentType']");
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].DocumentSeries, "./*[local-name()='documentSeries']");
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].DocumentNumber, "./*[local-name()='documentNumber']");
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].InitialAmount, "./*[local-name()='initialAmount']");
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].Discount, "./*[local-name()='discount']");
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].TotalAmount, "./*[local-name()='totalAmount']");
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].IBAN, "./*[local-name()='iban']");
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].BIC, "./*[local-name()='bic']");
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].PaymentReason, "./*[local-name()='paymentReason']");
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].CreateDate, "./*[local-name()='createDate']");

            //mapper.AddFunctionMap(p => p.ObligationDocuments[0].CreateDate, node =>
            //{
            //    XmlNode dateNode =
            //           node.SelectSingleNode(
            //               "./*[local-name()='Vehicle']/*[local-name()='FirstRegistrationDate']");
            //    if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
            //    {
            //        return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat).ToString();
            //    }
            //    return null;
            //});

            mapper.AddPropertyMap(d => d.ObligationDocuments[0].IsMainDocument, "./*[local-name()='isMainDocument']", o => Convert.ToBoolean(o));
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].IsServed, "./*[local-name()='isServed']", o =>
            {
                if (o != null && o.ToString() != "")
                {
                    return Convert.ToBoolean(o);
                }

                return null;
            });

            return mapper;
        }

        private static ObjectMapper<SendPaymentNotificationResponseType, SendPaymentNotificationResponseType> CreatePaymentNotificationSelfMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<SendPaymentNotificationResponseType, SendPaymentNotificationResponseType> mapper = new ObjectMapper<SendPaymentNotificationResponseType, SendPaymentNotificationResponseType>(accessMatrix);
            mapper.AddObjectMap((o) => o.Status, (c) => c.Status);
            mapper.AddObjectMap((o) => o.ErrorMessage, (c) => c.ErrorMessage);


            return mapper;
        }

        private XPathMapper<SendPaymentNotificationResponseType> CreatePaymentNotificationMap(AccessMatrix accessMatrix)
        {
            XPathMapper<SendPaymentNotificationResponseType> mapper = new XPathMapper<SendPaymentNotificationResponseType>(accessMatrix);

            mapper.AddPropertyMap(d => d.Status, "./*[local-name()='sendPaymentNotificationExternalResponse']/*[local-name()='return']/*[local-name()='status']");
            mapper.AddPropertyMap(d => d.ErrorMessage, "./*[local-name()='sendPaymentNotificationExternalResponse']/*[local-name()='return']/*[local-name()='errorMessage']");

            return mapper;
        }

        private static ObjectMapper<GetObligationDocumentsByEGNResponseType, GetObligationDocumentsByEGNResponseType> CreateObligationDocumentsByEGNSelfMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<GetObligationDocumentsByEGNResponseType, GetObligationDocumentsByEGNResponseType> mapper = new ObjectMapper<GetObligationDocumentsByEGNResponseType, GetObligationDocumentsByEGNResponseType>(accessMatrix);
            mapper.AddObjectMap((o) => o.Status, (c) => c.Status);
            return mapper;
        }

        private XPathMapper<GetObligationDocumentsByEGNResponseType> CreateObligationDocumentsByEGNMap(AccessMatrix accessMatrix)
        {
            XPathMapper<GetObligationDocumentsByEGNResponseType> mapper = new XPathMapper<GetObligationDocumentsByEGNResponseType>(accessMatrix);
        
            mapper.AddPropertyMap(d => d.Status, "./*[local-name()='ObligationDocumentsByEgnResponse']/*[local-name()='status']");
            mapper.AddPropertyMap(d => d.CustomerType, "./*[local-name()='ObligationDocumentsByEgnResponse']/*[local-name()='customerType']");
            mapper.AddPropertyMap(d => d.UserPID, "./*[local-name()='ObligationDocumentsByEgnResponse']/*[local-name()='userPid']");

            mapper.AddCollectionMap(d => d.ObligationDocuments, "./*[local-name()='ObligationDocumentsByEgnResponse']/*[local-name()='allObligations']/*[local-name()='ObligationDocument']");
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].DocumentType, "./*[local-name()='documentType']");
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].DocumentSeries, "./*[local-name()='documentSeries']");
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].DocumentNumber, "./*[local-name()='documentNumber']");
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].InitialAmount, "./*[local-name()='initialAmount']");
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].Discount, "./*[local-name()='discount']");
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].TotalAmount, "./*[local-name()='totalAmount']");
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].IBAN, "./*[local-name()='iban']");
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].BIC, "./*[local-name()='bic']");
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].PaymentReason, "./*[local-name()='paymentReason']");
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].CreateDate, "./*[local-name()='createDate']");

            //mapper.AddFunctionMap(p => p.ObligationDocuments[0].CreateDate, node =>
            //{
            //    XmlNode dateNode =
            //           node.SelectSingleNode(
            //               "./*[local-name()='Vehicle']/*[local-name()='FirstRegistrationDate']");
            //    if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
            //    {
            //        return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat).ToString();
            //    }
            //    return null;
            //});

            mapper.AddPropertyMap(d => d.ObligationDocuments[0].IsMainDocument, "./*[local-name()='isMainDocument']", o => Convert.ToBoolean(o));
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].IsServed, "./*[local-name()='isServed']", o => 
            {
                if (o != null && o.ToString() != "")
                {
                    return Convert.ToBoolean(o);
                }

                return null;
            });

            return mapper;
        }

        private static ObjectMapper<GetObligationDocumentsByLicenceNumResponseType, GetObligationDocumentsByLicenceNumResponseType> CreateObligationDocumentsByLicenceNumSelfMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<GetObligationDocumentsByLicenceNumResponseType, GetObligationDocumentsByLicenceNumResponseType> mapper = new ObjectMapper<GetObligationDocumentsByLicenceNumResponseType, GetObligationDocumentsByLicenceNumResponseType>(accessMatrix);
            mapper.AddObjectMap((o) => o.Status, (c) => c.Status);
            return mapper;
        }

        private XPathMapper<GetObligationDocumentsByLicenceNumResponseType> CreateObligationDocumentsByLicenceNumMap(AccessMatrix accessMatrix)
        {
            XPathMapper<GetObligationDocumentsByLicenceNumResponseType> mapper = new XPathMapper<GetObligationDocumentsByLicenceNumResponseType>(accessMatrix);

            mapper.AddPropertyMap(d => d.Status, "./*[local-name()='ObligationDocumentsByLicenceNumResponse']/*[local-name()='status']");
            mapper.AddPropertyMap(d => d.CustomerType, "./*[local-name()='ObligationDocumentsByLicenceNumResponse']/*[local-name()='customerType']");
            mapper.AddPropertyMap(d => d.UserPID, "./*[local-name()='ObligationDocumentsByLicenceNumResponse']/*[local-name()='userPid']");

            mapper.AddCollectionMap(d => d.ObligationDocuments, "./*[local-name()='ObligationDocumentsByLicenceNumResponse']/*[local-name()='allObligations']/*[local-name()='ObligationDocument']");
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].DocumentType, "./*[local-name()='documentType']");
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].DocumentSeries, "./*[local-name()='documentSeries']");
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].DocumentNumber, "./*[local-name()='documentNumber']");
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].InitialAmount, "./*[local-name()='initialAmount']");
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].Discount, "./*[local-name()='discount']");
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].TotalAmount, "./*[local-name()='totalAmount']");
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].IBAN, "./*[local-name()='iban']");
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].BIC, "./*[local-name()='bic']");
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].PaymentReason, "./*[local-name()='paymentReason']");
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].CreateDate, "./*[local-name()='createDate']");

            //mapper.AddFunctionMap(p => p.ObligationDocuments[0].CreateDate, node =>
            //{
            //    XmlNode dateNode =
            //           node.SelectSingleNode(
            //               "./*[local-name()='Vehicle']/*[local-name()='FirstRegistrationDate']");
            //    if (dateNode != null && !string.IsNullOrWhiteSpace(dateNode.InnerText))
            //    {
            //        return DateTime.ParseExact(dateNode.InnerText, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat).ToString();
            //    }
            //    return null;
            //});

            mapper.AddPropertyMap(d => d.ObligationDocuments[0].IsMainDocument, "./*[local-name()='isMainDocument']", o => Convert.ToBoolean(o));
            mapper.AddPropertyMap(d => d.ObligationDocuments[0].IsServed, "./*[local-name()='isServed']", o =>
            {
                if (o != null && o.ToString() != "")
                {
                    return Convert.ToBoolean(o);
                }

                return null;
            });

            return mapper;
        }

        private void ValidateCallContext(AdapterAdditionalParameters additionalParameters)
        {
            if (string.IsNullOrEmpty(additionalParameters.CallContext.EmployeeIdentifier))
            {
                Exception ex = new ArgumentException("EmployeeIdentifier parameter is required in CallContext");
                throw ex;
            }
            if (string.IsNullOrEmpty(additionalParameters.CallContext.EmployeeNames))
            {
                Exception ex = new ArgumentException("EmployeeNames parameter is required in CallContext");
                throw ex;
            }
            if (string.IsNullOrEmpty(additionalParameters.CallContext.ServiceURI))
            {
                Exception ex = new ArgumentException("ServiceURI parameter is required in CallContext");
                throw ex;
            }
            if (string.IsNullOrEmpty(additionalParameters.CallContext.ServiceType))
            {
                Exception ex = new ArgumentException("ServiceType parameter is required in CallContext");
                throw ex;
            }
            if (string.IsNullOrEmpty(additionalParameters.CallContext.LawReason))
            {
                Exception ex = new ArgumentException("LawReason parameter is required in CallContext");
                throw ex;
            }
        }


    }
}
