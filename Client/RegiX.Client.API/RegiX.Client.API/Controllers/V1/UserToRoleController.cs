using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.UserToRole;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Services.Contracts;

namespace TechnoLogica.RegiX.Client.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/users-to-roles")] //required for default versioning
    [Route("api/v{version:apiVersion}/users-to-roles")]
    [Authorize]
    public class UserToRoleController : ABaseGetAllController<UserToRoleInDto, UserToRoleOutDto, UsersToRoles, int>
    {
        public UserToRoleController(IUserToRoleService aBaseService)
            : base(aBaseService)
        {
        }


        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut("{aId}")]
        public override IActionResult Put(int aId, [FromBody] UserToRoleInDto aInDto)
        {
            return StatusCode(405);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("")]
        public override IActionResult Post([FromBody] UserToRoleInDto aInDto)
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