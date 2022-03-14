using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;
using Microsoft.AspNetCore.Authorization;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.AdapterOperations;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Services.Contracts;
using TechnoLogica.RegiX.Common.Utils;
using static TechnoLogica.RegiX.Client.API.RegiXCoreClient;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Client.Repositories;
using System.Security.Cryptography.X509Certificates;
using TechnoLogica.RegiX.Common.Metadata.AdapterOperations;
using TechnoLogica.RegiX.Common.Metadata;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.Authorities;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.User;
using IUserContext = TechnoLogica.RegiX.Client.Repositories.IUserContext;
using TechnoLogica.RegiX.Client.IoC.Configuration.Profiles;

namespace TechnoLogica.RegiX.Client.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/adapter-operations")] //required for default versioning
    [Route("api/v{version:apiVersion}/adapter-operations")]
    [Authorize]
    public class AdapterOperationsController : ABaseGetAllController<AdapterOperationsInDto, AdapterOperationsOutDto,
        AdapterOperations, int>
    {
        RegiXClientSettings RegiXClientSettings { get; set; }
        IAuthoritiesService AuthoritiesService { get; set; }
        IAsyncReportExecutionsService AsyncReportExecutionsService { get; set; }
        IAuditReportExecutionService AuditReportExecutionService { get; set; }
        IUserContext UserContext { get; set; }
        IUserService UserService { get; set; }

        public AdapterOperationsController(
            IAdapterOperationsService aBaseService,
            RegiXClientSettings regiXClientSettings,
            IAuthoritiesService aAuthoritiesService,
            IAuditReportExecutionService aAuditReportExecutionService,
            IAsyncReportExecutionsService aAsyncReportExecutionService,
            IUserService aUserService,
            IUserContext userContext)
            : base(aBaseService)
        {
            RegiXClientSettings = regiXClientSettings;
            AuthoritiesService = aAuthoritiesService;
            AsyncReportExecutionsService = aAsyncReportExecutionService;
            AuditReportExecutionService = aAuditReportExecutionService;
            UserContext = userContext;
            UserService = aUserService;
        }

        /// <summary>
        /// </summary>
        /// <returns>The IActionResult</returns>
        [HttpGet("withParameters/{id}")]
        public virtual IActionResult GetAllNoWrap(int id)
        {
            var result = ((IAdapterOperationsService)baseService).GetWithMetadata(id);

            if (result != null)
            {
                var withParams = new AdapterOperationsWithParams
                {
                    Id = result.Id,
                    OperationName = result.OperationName,
                    DisplayOperationName = result.DisplayOperationName,
                    Register = result.Register,
                    Resource = result.Resource,
                    IsActive = result.IsActive,
                    Code = result.Code,
                    ControllerName = result.ControllerName,
                    RequestObjectName = result.RequestObjectName,
                    Namespace = result.Namespace,
                    Url = result.Url,
                    CreatedBy = result.CreatedBy,
                    CreatedOn = result.CreatedOn,
                    ModifiedBy = result.ModifiedBy,
                    ModifiedOn = result.ModifiedOn,
                    RequestMetadata = result.MetadataXml.XmlDeserialize<AdapterOperation>()
                };
                return Ok(withParams);
            }
            return NotFound();
        }

        [HttpPost("executeRequest")]
        public virtual async Task<IActionResult> ExecuteRequest([FromBody] JObject requestWithMeta)
        {
            if (UserContext.AdministrationID.HasValue)
            {
                var reportID = requestWithMeta["reportId"].Value<int>();
                using (var client = new RegiXCoreClient(EndpointConfiguration.BasicHttpBindingSecurityClientCertificate))
                {
                    var authorityDTO = this.AuthoritiesService.Select(UserContext.AdministrationID.Value);
                    SetClientCredentials(client, authorityDTO);

                    if (!UserContext.UserId.HasValue)
                    {
                        throw new ApplicationException("User should have userID!");
                    }
                    var user = UserService.Select(UserContext.UserId.Value);

                    var requestData = requestWithMeta["requestData"] as JObject;

                    var operationMetaData = ((IAdapterOperationsService)baseService).GetWithMetadata(requestWithMeta["operationId"].Value<int>());
                    var request =
                        PrepareRequest(
                            operationMetaData,
                            requestData,
                            authorityDTO,
                            user
                        );
                    bool transformToPDF = requestData["regiXClient_resultAsPDF"].Value<bool>();
                    if (transformToPDF)
                    {
                        request.Request.ResponseProcessing = Common.TransportObjects.ResponseProcessing.TransformToPDF;
                    }

                    try 
                    {                     
                        var clientResult = await client.ExecuteAsync(request);

                        var hasError = clientResult?.Result?.HasError;
                        var isReady = clientResult?.Result?.IsReady;
                        var serviceCallId = clientResult?.Result?.ServiceCallID;
                        var verifcationCode = clientResult?.Result?.VerificationCode;
                        if (hasError.HasValue && !hasError.Value &&
                            isReady.HasValue && !isReady.Value &&
                            serviceCallId.HasValue &&
                            !string.IsNullOrEmpty(verifcationCode))
                        {
                            try
                            {
                                var insertedAsyncExecution =
                                    AsyncReportExecutionsService.Insert(
                                        new AsyncReportExecutionsInDto()
                                        {
                                            AdapterOperationId = requestWithMeta["operationId"].Value<int>(),
                                            ApiServiceCallId = serviceCallId.Value,
                                            VerificationCode = verifcationCode,
                                            SubmittedOn = DateTime.Now,
                                            UserId = user.Id
                                        }
                                    );

                                return Ok(new
                                {
                                    IsReady = false,
                                    AsyncReportExecutionId = insertedAsyncExecution.Id,
                                    ServiceCallID = clientResult?.Result?.ServiceCallID,
                                    VerificationCode = clientResult?.Result?.VerificationCode
                                });
                            }
                            catch (Exception ex)
                            {
                                return Ok(
                                    new
                                    {
                                        IsReady = false,
                                        AsyncReportExecutionID = 0,
                                    }
                                );
                            }
                        }
                        else
                        {
                            AuditReportExecutionService.Insert(
                                new DataContracts.DTO.AuditReportExecution.AuditReportExecutionInDto()
                                {
                                    ReportExecutionTime = DateTime.Now,
                                    ReportId = reportID,
                                    RequestXml = request?.XmlSerialize().ToXmlElement().OuterXml,
                                    ResponseXml = clientResult?.XmlSerialize().ToXmlElement().OuterXml,
                                    ApiServiceCallId = serviceCallId,
                                    ContextEmployeeAdditionalId = request.Request.CallContext.EmployeeAditionalIdentifier,
                                    ContextServiceType = request.Request.CallContext.ServiceType,
                                    ContextServiceURI = request.Request.CallContext.ServiceURI,
                                    ContextLawReason = request.Request.CallContext.LawReason,
                                    CallContext = request.Request.CallContext.XmlSerialize(),
                                    HasError = clientResult?.Result.HasError,
                                    RegisterErrorMessage = clientResult?.Result.Error,
                                }
                            );

                            if (!transformToPDF)
                            {
                                return Ok(new
                                {
                                    Error = clientResult?.Result?.Error,
                                    HasError = clientResult?.Result?.HasError,
                                    IsReady = clientResult?.Result?.IsReady,
                                    ServiceCallID = clientResult?.Result?.ServiceCallID,
                                    VerificationCode = clientResult?.Result?.VerificationCode,
                                    Request = clientResult?.Result?.Data?.Request?.Request?.OuterXml?.TransformServiceResultFromDatabase(operationMetaData.RequestXSLT),
                                    Response = clientResult?.Result?.Data?.Response?.Response?.OuterXml?.TransformServiceResultFromDatabase(operationMetaData.ResponseXSLT),
                                    RequestXml = clientResult?.Result?.Data?.Request?.Request?.OuterXml,
                                    ResponseXml = clientResult?.Result?.Data?.Response?.Response?.OuterXml,
                                    RawResponseXml = clientResult?.XmlSerialize().ToXmlElement().OuterXml,
                                    SignatureVerified = clientResult?.GetSignatureVerified(),
                                    SignatureCertirifcate = clientResult?.GetSignatureCertirifcate(),
                                });
                            }
                            else
                            {
                                try
                                {
                                    return Ok(new
                                    {
                                        Error = clientResult?.Result?.Error,
                                        HasError = clientResult?.Result?.HasError,
                                        IsReady = clientResult?.Result?.IsReady,
                                        ServiceCallID = clientResult?.Result?.ServiceCallID,
                                        VerificationCode = clientResult?.Result?.VerificationCode,
                                        Request = clientResult?.Result?.Data?.Request?.Request?.OuterXml?.TransformServiceResultFromDatabase(operationMetaData.RequestXSLT),
                                        ResponsePdf = clientResult?.Result?.Data?.Response?.Response?.Deserialize<BinaryArgument>().Binary,
                                        RequestXml = clientResult?.Result?.Data?.Request?.Request?.OuterXml,
                                        ResponseXml = clientResult?.Result?.Data?.Response?.Response?.OuterXml
                                    });
                                }
                                catch (Exception ex)
                                {
                                    return NotFound(
                                        ex.Message + Environment.NewLine +
                                        clientResult?.Result?.Data?.XmlSerialize() + Environment.NewLine +
                                        request.XmlSerialize());
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        AuditReportExecutionService.Insert(
                            new DataContracts.DTO.AuditReportExecution.AuditReportExecutionInDto()
                            {
                                ReportExecutionTime = DateTime.Now,
                                ReportId = reportID,
                                RequestXml = request.XmlSerialize().ToXmlElement().OuterXml,
                                ContextEmployeeAdditionalId = request.Request.CallContext.EmployeeAditionalIdentifier,
                                ContextServiceType = request.Request.CallContext.ServiceType,
                                ContextServiceURI = request.Request.CallContext.ServiceURI,
                                ContextLawReason = request.Request.CallContext.LawReason,
                                CallContext = request.Request.CallContext.XmlSerialize(),
                                HasError = true,
                                UnhandledErrorMessage = ex.Message,
                                UnhandledErrorContent = ex.StackTrace
                            }
                        );
                        return NotFound(ex.Message);
                    }
                }
            }
            else
            {
                throw new ApplicationException("User should have Authority!");
            }
        }

        private Core.Interfaces.TransportObjects.RequestWrapper PrepareRequest(
            AdapterOperationsWithMetadata result,
            JObject requestData,
            AuthoritiesOutDto authorityDTO,
            UserOutDto user)
        {
            ApplyPublicContext(requestData);
            var xmlRequest =
                MetadataUtilsLocal.CreateXML(
                    UserContext,
                    requestData,
                    result.MetadataXml.XmlDeserialize<AdapterOperation>());
            var request =
                new Core.Interfaces.TransportObjects.RequestWrapper()
                {
                    Request = new Common.TransportObjects.ServiceRequestData()
                    {
                        Operation = result.OperationName,
                        Argument = xmlRequest,
                        CallbackURL = this.RegiXClientSettings.RegiXClientCallbackURL,
                        CallContext = new CallContext()
                        {
                            AdministrationName = authorityDTO.Name,
                            AdministrationOId = authorityDTO.Oid,
                            EmployeeIdentifier = 
                                string.IsNullOrEmpty(requestData["regiXClient_employeeId"]?.Value<string>()) ? 
                                    user.UserName : 
                                    requestData["regiXClient_employeeId"]?.Value<string>(),
                            EmployeeAditionalIdentifier = requestData["regiXClient_additionalEmployeeId"]?.Value<string>(),
                            EmployeeNames = user.Name,
                            EmployeePosition = user.Position,
                            LawReason = requestData["regiXClient_lawReason"]?.Value<string>(),
                            Remark = requestData["regiXClient_remarks"]?.Value<string>(),
                            // ResponsiblePersonIdentifier = "",
                            ServiceURI = requestData["regiXClient_serviceURI"]?.Value<string>(),
                            ServiceType = requestData["regiXClient_serviceType"]?.Value<string>()
                        },
                    //CitizenEGN = "",
                    //EmployeeEGN = "",
                    ReturnAccessMatrix = requestData["regiXClient_returnAccessMatrix"].Value<bool>(),
                        SignResult = requestData["regiXClient_signResult"].Value<bool>()
                    }
                };
            return request;
        }

        private void ApplyPublicContext(JObject requestData)
        {
            if (UserContext.IsPublic)
            {
                requestData["regiXClient_additionalEmployeeId"] = this.RegiXClientSettings.PublicCallContext.EmployeeAditionalIdentifier;
                requestData["regiXClient_employeeId"] = this.RegiXClientSettings.PublicCallContext.EmployeeIdentifier;
                requestData["regiXClient_employeeName"] = this.RegiXClientSettings.PublicCallContext.EmployeeNames;
                requestData["regiXClient_lawReason"] = this.RegiXClientSettings.PublicCallContext.LawReason;
                requestData["regiXClient_remarks"] = this.RegiXClientSettings.PublicCallContext.Remark;
                requestData["regiXClient_serviceType"] = this.RegiXClientSettings.PublicCallContext.ServiceType;
                requestData["regiXClient_serviceURI"] = this.RegiXClientSettings.PublicCallContext.ServiceURI;
            }            
        }

        public static void SetClientCredentials(RegiXCoreClient client, AuthoritiesOutDto authorityDTO)
        {
            var findValue = authorityDTO.CertificateThumbprint;
            var storeName = authorityDTO.CertificateStore;
            client.ClientCredentials.ClientCertificate.SetCertificate(
                StoreLocation.LocalMachine,
                storeName ?? StoreName.My,
                X509FindType.FindByThumbprint,
                findValue);
        }
    }

    public class AdapterOperationsWithParams : AdapterOperationsOutDto
    {
        public Common.Metadata.AdapterOperations.AdapterOperation RequestMetadata { get; set; }
    }

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
}