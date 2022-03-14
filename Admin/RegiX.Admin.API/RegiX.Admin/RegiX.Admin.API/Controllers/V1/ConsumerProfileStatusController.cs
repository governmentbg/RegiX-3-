using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerProfileStatus;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/consumer-profile-status")]//required for default versioning
    [Route("api/v{version:apiVersion}/consumer-profile-status")]
    [Authorize]
    public class ConsumerProfileStatusController : ABaseGetAllController<ConsumerProfileStatusInDto, ConsumerProfileStatusOutDto, ConsumerProfileStatus, decimal>
    {
        public ConsumerProfileStatusController(IConsumerProfileStatusService aBaseService)
            : base(aBaseService)
        {
        }
    }
}