using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AuditException;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/audit-exceptions")]//required for default versioning
    [Route("api/v{version:apiVersion}/audit-exceptions")]
    [Authorize(Roles = "GLOBAL_ADMIN")]
    public class AuditExceptionController : ABaseController<AuditExceptionInDto, AuditExceptionOutDto, AuditExceptions, decimal>
    {
        public AuditExceptionController(IAuditExceptionService aBaseService) 
            : base(aBaseService)
        {
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut("{aId}")]
        public override IActionResult Put(decimal aId, [FromBody]AuditExceptionInDto aInDto)
        {
            return StatusCode(405);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("")]
        public override IActionResult Post([FromBody]AuditExceptionInDto aInDto)
        {
            return StatusCode(405);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete("{aId}")]
        public override IActionResult Delete(decimal aId)
        {
            return StatusCode(405);
        }

    }
}
