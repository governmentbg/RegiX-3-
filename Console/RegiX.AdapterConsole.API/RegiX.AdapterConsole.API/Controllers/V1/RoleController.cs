using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.AdapterConsole.DataContracts;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;
using TechnoLogica.RegiX.AdapterConsole.Services.Contracts;

namespace TechnoLogica.RegiX.AdapterConsole.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/roles")] //required for default versioning
    [Route("api/v{version:apiVersion}/roles")]
    [Authorize]
    public class RoleController : ABaseGetAllController<RolesInDto, RolesOutDto, AspNetRoles, int>
    {
        public RoleController(IRolesService aBaseService)
            : base(aBaseService)
        {
        }
    }
}