using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegiX.Info.DataContracts.DTO.ConsumerAccessRequests;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Services.Contracts;
using TechnoLogica.API.Common.Controllers;

namespace RegiX.Info.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/consumer-access-requests")]//required for default versioning
    [Route("api/v{version:apiVersion}/consumer-access-requests")]
    [Authorize]
    public class ConsumerAccessRequestsController : ABaseGetAllController<ConsumerAccessRequestsInDto, ConsumerAccessRequestsOutDto, ConsumerAccessRequests, decimal>
    {
        public ConsumerAccessRequestsController(IConsumerAccessRequestsService aBaseService)
            : base(aBaseService)
        {
        }
    }
}
