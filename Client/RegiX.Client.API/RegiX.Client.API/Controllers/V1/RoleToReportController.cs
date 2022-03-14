using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.RoleToReport;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Services.Contracts;

namespace TechnoLogica.RegiX.Client.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/roles-to-reports")] //required for default versioning
    [Route("api/v{version:apiVersion}/roles-to-reports")]
    [Authorize]
    public class
        RoleToReportController : ABaseGetAllController<RoleToReportInDto, RoleToReportOutDto, RolesToReports, int>
    {
        public RoleToReportController(IRoleToReportService aBaseService)
            : base(aBaseService)
        {
        }


        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut("{aId}")]
        public override IActionResult Put(int aId, [FromBody] RoleToReportInDto aInDto)
        {
            return StatusCode(405);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("")]
        public override IActionResult Post([FromBody] RoleToReportInDto aInDto)
        {
            return StatusCode(405);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete("{aId}")]
        public override IActionResult Delete(int aId)
        {
            return StatusCode(405);
        }
    }
}