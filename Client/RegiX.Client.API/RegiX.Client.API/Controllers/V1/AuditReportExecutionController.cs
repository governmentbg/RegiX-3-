using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditReportExecution;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Services.Contracts;

namespace TechnoLogica.RegiX.Client.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/audit-report-executions")] //required for default versioning
    [Route("api/v{version:apiVersion}/audit-report-executions")]
    [Authorize]
    public class AuditReportExecutionController : ABaseGetAllController<AuditReportExecutionInDto,
        AuditReportExecutionOutDto, AuditReportExecutions, int>
    {
        private IAdapterOperationsService AdapterOperationsService { get; set; }
        public AuditReportExecutionController(
            IAuditReportExecutionService aBaseService,
            IAdapterOperationsService adapterOperationsService)
            : base(aBaseService)
        {
            AdapterOperationsService = adapterOperationsService;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut("{aId}")]
        public override IActionResult Put(int aId, [FromBody] AuditReportExecutionInDto aInDto)
        {
            return StatusCode(405);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("")]
        public override IActionResult Post([FromBody] AuditReportExecutionInDto aInDto)
        {
            return StatusCode(405);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete("{aId}")]
        public override IActionResult Delete(int aId)
        {
            return StatusCode(405);
        }


        [HttpPost("readReportExecution/{aId}")]
        public virtual async Task<IActionResult> ReaderReportExecution(int aId)
        {
            var result = (this.baseService as IAuditReportExecutionService).ReaderReportExecution(aId);

            if (!string.IsNullOrEmpty(result.ResponseXml) || (result.HasError.HasValue && result.HasError.Value))
            {
                var operationMetaData = AdapterOperationsService.GetWithMetadata(result.AdapterOperationId);
                return Ok(new
                {
                    CreatedOn = result.CreatedOn,
                    IsReady = true,
                    Request = result.RequestXml?.TransformServiceResultFromDatabase(operationMetaData.RequestXSLT),
                    Response = result.ResponseXml?.TransformServiceResultFromDatabase(operationMetaData.ResponseXSLT),
                    result.ResponsePdf,
                    result.RequestXml,
                    result.ResponseXml,
                    result.RawResponseXml,
                    result.SignatureVerified,
                    result.SignatureCertirifcate,
                    result.ContextServiceURI,
                    result.ContextServiceType,
                    result.ContextLawReason,
                    result.CallContext,
                    result.ContextEmployeeAdditionalId,
                    result.ApiServiceCallId,
                    result.HasError,
                    result.RegisterErrorMessage,
                    result.RegisterErrorContent,
                    result.UnhandledErrorMessage,
                    result.UnhandledErrorContent
                });
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
    }
}