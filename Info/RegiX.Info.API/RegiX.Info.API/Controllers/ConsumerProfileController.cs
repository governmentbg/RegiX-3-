using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegiX.Info.DataContracts.DTO.ConsumerProfile;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories;
using RegiX.Info.Services.Contracts;
using TechnoLogica.API.Common.Controllers;

namespace RegiX.Info.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/consumer-profile")]
    [Route("api/v{version:apiVersion}/consumer-profile")]
    [ApiController]
    [Authorize]
    public class ConsumerProfileController : ABaseGetAllController<ConsumerProfileInDto, ConsumerProfileOutDto, ConsumerProfiles, decimal>
    {
        private readonly IConsumerContext consumerContext;

        public ConsumerProfileController(IConsumerProfileService aBaseService, IConsumerContext consumerContext) 
            : base(aBaseService)
        {
            this.consumerContext = consumerContext;
        }

        public override IActionResult Get(decimal aId)
        {
            //Stops the user from getting information about other profiles
            if (this.consumerContext.ConsumerProfileID != aId)
            {
                return Unauthorized();
            }
            return base.Get(aId);
        }
    }
}
