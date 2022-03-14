using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegiX.Info.DataContracts.DTO.ConsumerSystems;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Services.Contracts;
using TechnoLogica.API.Common.Controllers;

namespace RegiX.Info.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/consumer-systems")]//required for default versioning
    [Route("api/v{version:apiVersion}/consumer-systems")]
    [Authorize]
    public class ConsumerSystemsController : ABaseGetAllController<ConsumerSystemsInDto, ConsumerSystemsOutDto, ConsumerSystems, decimal>
    {
        public ConsumerSystemsController(IConsumerSystemsService aBaseService)
            : base(aBaseService)
        {
        }
    }
}
