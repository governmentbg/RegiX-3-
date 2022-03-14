using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AuditUserAction;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/audit-user-actions")]//required for default versioning
    [Route("api/v{version:apiVersion}/audit-user-actions")]
    [Authorize(Roles = "GLOBAL_ADMIN")]
    public class AuditUserActionController : ABaseGetAllController<AuditUserActionInDto, AuditUserActionOutDto, AuditUserActions, decimal>
    {
        public AuditUserActionController(IAuditUserActionService aBaseService) 
            : base(aBaseService)
        {
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut("{aId}")]
        public override IActionResult Put(decimal aId, [FromBody]AuditUserActionInDto aInDto)
        {
            return StatusCode(405);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("")]
        public override IActionResult Post([FromBody]AuditUserActionInDto aInDto)
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
