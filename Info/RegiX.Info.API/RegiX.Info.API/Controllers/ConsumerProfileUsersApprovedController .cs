using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegiX.Info.DataContracts.DTO.ConsumerProfileUsersApproved;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Services.Contracts;
using TechnoLogica.API.Common.Controllers;

namespace RegiX.Info.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/consumer-profile-users-approved")]
    [Route("api/v{version:apiVersion}/consumer-profile-users-approved")]
    [ApiController]
    [Authorize]
    public class ConsumerProfileUsersApprovedController : ABaseGetAllController<ConsumerProfileUsersApprovedInDto, ConsumerProfileUsersApprovedOutDto, ConsumerProfileUsers, decimal>
    {

        public ConsumerProfileUsersApprovedController(IConsumerProfileUsersApprovedService aBaseService) 
            : base(aBaseService)
        {
        }

       
    }
}
