using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegiX.Info.DataContracts.DTO.ConsumerRequests;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Services.Contracts;
using TechnoLogica.API.Common.Controllers;

namespace RegiX.Info.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/consumer-requests")]//required for default versioning
    [Route("api/v{version:apiVersion}/consumer-requests")]
    [Authorize]
    public class ConsumerRequestsController : ABaseGetAllController<ConsumerRequestsInDto, ConsumerRequestsOutDto, ConsumerRequests, decimal>
    {
        public ConsumerRequestsController(IConsumerRequestsService aBaseService)
            : base(aBaseService)
        {
        }

        [HttpPost("GetReport/{consumerRequest}")]
        public IActionResult GetAllPrimaries(decimal consumerRequest)
        {
            return Ok((this.baseService as IConsumerRequestsService).CreateReport(consumerRequest));
        }
    }
}
