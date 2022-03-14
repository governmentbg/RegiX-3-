using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.OperationsToRoles;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;
using TechnoLogica.RegiX.AdapterConsole.Services.Contracts;

namespace TechnoLogica.RegiX.AdapterConsole.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/operations-to-roles")] //required for default versioning
    [Route("api/v{version:apiVersion}/operations-to-roles")]
    [Authorize]
    public class OperationToRoleController : ABaseGetAllController<OperationsToRolesInDto, OperationsToRolesOutDto,
        OperationsToRoles, int>
    {
        public OperationToRoleController(IOperationsToRolesService aBaseService)
            : base(aBaseService)
        {
        }
    }
}