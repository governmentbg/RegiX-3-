using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.HealthServicePing;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/health-service-ping")]//required for default versioning
    [Route("api/v{version:apiVersion}/health-service-ping")]
    [Authorize]
    public class HealthServicePingController : ABaseController<HealthServicePingInDto, HealthServicePingOutDto, HealthServicePing, decimal>
    {
        public HealthServicePingController(IHealthServicePingService aBaseService) 
            : base(aBaseService)
        {
        }
    }
}
