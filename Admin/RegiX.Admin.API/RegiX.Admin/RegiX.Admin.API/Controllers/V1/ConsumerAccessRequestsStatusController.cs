using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerAccessRequestsStatus;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/consumer-access-requests-status")]//required for default versioning
    [Route("api/v{version:apiVersion}/consumer-access-requests-status")]
    [Authorize]
    public class ConsumerAccessRequestsStatusController : ABaseController<ConsumerAccessRequestsStatusInDto, ConsumerAccessRequestsStatusOutDto, ConsumerAccessRequestsStatus, decimal>
    {
        public ConsumerAccessRequestsStatusController(IConsumerAccessRequestsStatusService aBaseService)
            : base(aBaseService)
        {
        }
    }
}