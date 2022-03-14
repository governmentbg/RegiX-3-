using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerRequestElements;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
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