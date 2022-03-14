using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerRequests;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;
namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
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

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete("{aId}")]
        public override IActionResult Delete(decimal aId)
        {
            return StatusCode(405);
        }
    }
}