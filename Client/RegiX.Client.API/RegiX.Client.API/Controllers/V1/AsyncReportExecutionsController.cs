using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.AdapterOperations;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditTables;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories;
using TechnoLogica.RegiX.Client.Services.Contracts;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common.Utils;
using static TechnoLogica.RegiX.Client.API.RegiXCoreClient;

namespace TechnoLogica.RegiX.Client.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/async-report-execution")] //required for default versioning
    [Route("api/v{version:apiVersion}/async-report-execution")]
    [Authorize]
    public class AsyncReportExecutionsController : ABaseController<AsyncReportExecutionsInDto, AsyncReportExecutionsOutDto, AsyncReportExecutions, int>
    {
        IAdapterOperationsService AdapterOperationsService { get; set; }
        IUserContext UserContext { get; set; }
        IAuthoritiesService AuthoritiesService { get; set; }

        public AsyncReportExecutionsController(
            IAsyncReportExecutionsService aBaseService,
            IAuthoritiesService aAuthoritiesService,
            IAdapterOperationsService adapterOperationsService,
            IUserContext userContext)
            : base(aBaseService)
        {
            AdapterOperationsService = adapterOperationsService;
            AuthoritiesService = aAuthoritiesService;
            UserContext = userContext;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut("{aId}")]
        public override IActionResult Put(int aId, [FromBody] AsyncReportExecutionsInDto aInDto)
        {
            return StatusCode(405);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("")]
        public override IActionResult Post([FromBody] AsyncReportExecutionsInDto aInDto)
        {
            return StatusCode(405);
        }
        
        [HttpPost("readReportExecution/{aId}")]
        public virtual async Task<IActionResult> ReaderReportExecution( int aId)
        {
            var result = this.baseService.Select(aId);

            if (!string.IsNullOrEmpty(result.Result))
            {
                var operationMetaData = AdapterOperationsService.GetWithMetadata(result.AdapterOperationId);
                var serviceResultData = result.Result.XmlDeserialize<ServiceResultData>();
                if (serviceResultData?.Data?.Response?.Response?.LocalName == nameof(BinaryArgument))
                {
                    return Ok(new
                    {
                        SubmittedOn = result.SubmittedOn,
                        ReceivedOn = result.ReceivedOn,
                        Error = serviceResultData?.Error,
                        HasError = serviceResultData?.HasError,
                        IsReady = serviceResultData?.IsReady,
                        Request = serviceResultData?.Data?.Request?.Request?.OuterXml?.TransformServiceResultFromDatabase(operationMetaData.RequestXSLT),
                        ResponsePdf = serviceResultData?.Data?.Response?.Response?.Deserialize<BinaryArgument>().Binary,
                        RequestXml = serviceResultData?.Data?.Request?.Request?.OuterXml
                    });
                }
                else
                {
                    return Ok(new
                    {
                        SubmittedOn = result.SubmittedOn,
                        ReceivedOn = result.ReceivedOn,
                        Error = serviceResultData?.Error,
                        HasError = serviceResultData?.HasError,
                        IsReady = serviceResultData?.IsReady,
                        Request = serviceResultData?.Data?.Request?.Request?.OuterXml?.TransformServiceResultFromDatabase(operationMetaData.RequestXSLT),
                        Response = serviceResultData?.Data?.Response?.Response?.OuterXml?.TransformServiceResultFromDatabase(operationMetaData.ResponseXSLT),
                        RequestXml = serviceResultData?.Data?.Request?.Request?.OuterXml,
                        ResponseXml = serviceResultData?.Data?.Response?.Response?.OuterXml
                    });
                }
            }
            else
            {
                return Ok(
                    new
                    {
                        NotReady = true
                    }
                );
            }
        }


        [HttpPost("poll/{aId}")]
        public virtual async Task<IActionResult> Poll(int aId)
        {
            if (UserContext.AdministrationID.HasValue)
            {
                var asyncExecution = this.baseService.Select(aId);
                if (asyncExecution.UserId == UserContext.UserId)
                {
                    var serviceCheck =
                        new Core.Interfaces.TransportObjects.ServiceCheckResultWrapper()
                        {
                            Request = new ServiceCheckResultArgument()
                            {
                                ServiceCallID = asyncExecution.ApiServiceCallId,
                                ServiceCallIDSpecified = true,
                                VerificationCode = asyncExecution.VerificationCode
                            }
                        };

                    var authorityDTO = this.AuthoritiesService.Select(UserContext.AdministrationID.Value);

                    var client = new RegiXCoreClient(EndpointConfiguration.BasicHttpBindingSecurityClientCertificate);
                    AdapterOperationsController.SetClientCredentials(client, authorityDTO);
                    var pollResult = client.CheckResultAsync(serviceCheck).GetAwaiter().GetResult();
                    if (pollResult.Result.IsReady)
                    {
                        var updateResult =
                            (baseService as IAsyncReportExecutionsService).UpdateRequest(
                                pollResult.Result.ServiceCallID,
                                pollResult.Result.VerificationCode,
                                pollResult.Result.XmlSerialize());

                        // Acknowledge
                        client.AcknowledgeResultReceivedAsync(serviceCheck).GetAwaiter().GetResult();
                        return Ok(updateResult);
                    }
                    else
                    {
                        return Ok(asyncExecution);
                    }
                }
                else
                {
                    return NotFound("You do not have permission to poll this request!");
                }
            }
            else
            {
                return NotFound("User should have Authority!");
            }
        }
    }
}