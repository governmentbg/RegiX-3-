using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegiX.Info.DataContracts.DTO.ConsumerRequestOperations;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoLogica.API.Common.Controllers;

namespace RegiX.Info.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/consumer-request-operations")]//required for default versioning
    [Route("api/v{version:apiVersion}/consumer-request-operations")]
    [Authorize]
    public class ConsumerRequestOperationsController : ABaseGetAllController<ConsumerRequestOperationsInDto, ConsumerRequestOperationsOutDto, ConsumerRequestOperations, decimal>
    {
        public ConsumerRequestOperationsController(IConsumerRequestOperationsService aBaseService)
            : base(aBaseService)
        {
        }
    }
}
