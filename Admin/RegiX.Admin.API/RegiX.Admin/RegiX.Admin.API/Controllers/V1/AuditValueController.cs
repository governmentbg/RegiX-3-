using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AuditValue;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;
using TechnoLogica.API.Common.Controllers;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/audit-values")]//required for default versioning
    [Route("api/v{version:apiVersion}/audit-values")]
    [Authorize(Roles = "GLOBAL_ADMIN")]
    public class AuditValueController : ABaseController<AuditValueInDto, AuditValueOutDto, AuditValues, decimal>
    {
        public AuditValueController(IAuditValueService aBaseService) 
            : base(aBaseService)
        {
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut("{aId}")]
        public override IActionResult Put(decimal aId, [FromBody]AuditValueInDto aInDto)
        {
            return StatusCode(405);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("")]
        public override IActionResult Post([FromBody]AuditValueInDto aInDto)
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
