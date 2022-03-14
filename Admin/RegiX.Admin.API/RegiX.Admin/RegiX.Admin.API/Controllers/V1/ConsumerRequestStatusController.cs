using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerRequestStatus;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;
namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/consumer-request-status")]//required for default versioning
    [Route("api/v{version:apiVersion}/consumer-request-status")]
    [Authorize]
    public class ConsumerRequestStatusController : ABaseController<ConsumerRequestStatusInDto, ConsumerRequestStatusOutDto, ConsumerRequestStatus, decimal>
    {
        public ConsumerRequestStatusController(IConsumerRequestStatusService aBaseService)
            : base(aBaseService)
        {
        }
    }
}