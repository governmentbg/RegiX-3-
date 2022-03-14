using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerProfileUsers;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/consumer-profile-users")]//required for default versioning
    [Route("api/v{version:apiVersion}/consumer-profile-users")]
    [Authorize]
    public class ConsumerProfileUsersController : ABaseGetAllController<ConsumerProfileUsersInDto, ConsumerProfileUsersOutDto, ConsumerProfileUsers, decimal>
    {
        public ConsumerProfileUsersController(IConsumerProfileUsersService aBaseService)
            : base(aBaseService)
        {
        }
    }
}