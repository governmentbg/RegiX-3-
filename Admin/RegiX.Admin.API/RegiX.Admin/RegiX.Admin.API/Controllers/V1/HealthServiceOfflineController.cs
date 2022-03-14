using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.HealthServiceOffline;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/health-service-offline")]//required for default versioning
    [Route("api/v{version:apiVersion}/health-service-offline")]
    [Authorize]
    public class HealthServiceOfflineController : ABaseController<HealthServiceOfflineInDto, HealthServiceOfflineOutDto, HealthServiceOffline, decimal>
    {
        public HealthServiceOfflineController(IHealthServiceOfflineService aBaseService) 
            : base(aBaseService)
        {
        }
    }
}
