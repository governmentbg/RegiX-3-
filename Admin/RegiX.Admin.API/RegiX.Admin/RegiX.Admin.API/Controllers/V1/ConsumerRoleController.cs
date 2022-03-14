using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerRole;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/consumer-roles")]
    [Route("api/v{version:apiVersion}/consumer-roles")]
    [Authorize]
    public class ConsumerRoleController : ABaseGetAllController<ConsumerRoleInDto, ConsumerRoleOutDto, ConsumerRoles, decimal>
    {
        public ConsumerRoleController(IConsumerRoleService aBaseService)
            : base(aBaseService)
        {
        }
    }
}
