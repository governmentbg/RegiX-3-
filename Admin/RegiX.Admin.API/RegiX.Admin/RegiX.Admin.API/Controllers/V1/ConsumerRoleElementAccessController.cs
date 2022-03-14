using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerRoleElementAccess;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/consumer-role-element-access")]
    [Route("api/v{version:apiVersion}/consumer-role-element-access")]
    [Authorize]
    public class ConsumerRoleElementAccessController : ABaseGetAllController<ConsumerRoleElementAccessInDto, ConsumerRoleElementAccessOutDto, ConsumerRoleElementAccess, decimal>
    {
        public ConsumerRoleElementAccessController(IConsumerRoleElementAccessService aBaseService)
            : base(aBaseService)
        {
        }
    }
}