using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.UsersToRoles;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;
using TechnoLogica.RegiX.AdapterConsole.Services.Contracts;

namespace TechnoLogica.RegiX.AdapterConsole.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/users-to-roles")] //required for default versioning
    [Route("api/v{version:apiVersion}/users-to-roles")]
    [Authorize]
    public class
        UserToRoleController : ABaseGetAllController<UsersToRolesInDto, UsersToRolesOutDto, AspNetUserRoles, int>
    {
        public UserToRoleController(IUsersToRolesService aBaseService)
            : base(aBaseService)
        {
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut("{aId}")]
        public override IActionResult Put(int aId, [FromBody] UsersToRolesInDto aInDto)
        {
            return StatusCode(405);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("")]
        public override IActionResult Post([FromBody] UsersToRolesInDto aInDto)
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