using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegiX.Info.API.DTOs.ConsumerProfileUsers;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories;
using RegiX.Info.Services.Contracts;
using TechnoLogica.API.Common.Controllers;

namespace RegiX.Info.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/consumer-profile-users")]
    [Route("api/v{version:apiVersion}/consumer-profile-users")]
    [ApiController]
    [Authorize]
    public class ConsumerProfileUsersController : ABaseGetAllController<ConsumerProfileUsersInDto, ConsumerProfileUsersOutDto, ConsumerProfileUsers, decimal>
    {
        private readonly IConsumerContext consumerContext;

        public ConsumerProfileUsersController(IConsumerProfileUsersService aBaseService, IConsumerContext consumerContext) 
            : base(aBaseService)
        {
            this.consumerContext = consumerContext;
        }

        public override IActionResult Get(decimal aId)
        {
            //Stops the user from getting information about other consumer-profile-users
            if (this.consumerContext.UserId != aId)
            {
                return Unauthorized();
            }
            return base.Get(aId); 
        }

    }
}
