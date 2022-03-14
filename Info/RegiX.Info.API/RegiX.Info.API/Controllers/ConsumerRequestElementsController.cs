using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegiX.Info.DataContracts.DTO.ConsumerRequestElements;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Services.Contracts;
using TechnoLogica.API.Common.Controllers;

namespace RegiX.Info.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/consumer-request-elements")]//required for default versioning
    [Route("api/v{version:apiVersion}/consumer-request-elements")]
    [Authorize]
    public class ConsumerRequestElementsController : ABaseGetAllController<ConsumerRequestElementsInDto, ConsumerRequestElementsOutDto, ConsumerRequestElements, decimal>
    {
        public ConsumerRequestElementsController(IConsumerRequestElementsService aBaseService)
            : base(aBaseService)
        {
        }
    }
}
