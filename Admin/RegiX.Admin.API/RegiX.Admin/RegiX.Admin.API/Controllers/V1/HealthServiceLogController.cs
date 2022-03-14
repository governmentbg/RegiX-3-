using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.HealthServiceLog;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/health-service-log")]//required for default versioning
    [Route("api/v{version:apiVersion}/health-service-log")]
    [Authorize]
    public class HealthServiceLogController : ABaseController<HealthServiceLogInDto, HealthServiceLogOutDto, HealthServiceLog, decimal>
    {
        public HealthServiceLogController(IHealthServiceLogService aBaseService) 
            : base(aBaseService)
        {
        }
    }
}
