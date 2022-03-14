using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.Role;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Services.Contracts;

namespace TechnoLogica.RegiX.Client.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/roles")] //required for default versioning
    [Route("api/v{version:apiVersion}/roles")]
    [Authorize]
    public class RoleController : ABaseGetAllController<RoleInDto, RoleOutDto, Roles, int>
    {
        public RoleController(IRoleService aBaseService)
            : base(aBaseService)
        {
        }
    }
}