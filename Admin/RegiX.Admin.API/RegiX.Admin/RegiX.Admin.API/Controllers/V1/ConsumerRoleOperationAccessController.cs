using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerRoleOperationAccess;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/consumer-role-operation-access")]
    [Route("api/v{version:apiVersion}/consumer-role-operation-access")]
    [Authorize]
    public class ConsumerRoleOperationAccessController : ABaseGetAllController<ConsumerRoleOperationAccessInDto, ConsumerRoleOperationAccessOutDto, ConsumerRoleOperationAccess, decimal>
    {
        public ConsumerRoleOperationAccessController(IConsumerRoleOperationAccessService aBaseService)
            : base(aBaseService)
        {
        }
    }
}