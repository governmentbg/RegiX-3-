using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts.DatabaseOperationsServicesInterfaces;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1.DatabaseOperationsControllers
{
    [ApiVersion("1.0")]
    [Route("api/statistics")]//required for default versioning
    [Route("api/v{version:apiVersion}/statistics")]
    [Authorize]
    public class StatisticsController : Controller
    {
        protected IDatabaseOperationService service;

        public StatisticsController(IDatabaseOperationService aService)
        {
            service = aService;
        }

        [HttpPost("")]
        public  IActionResult Get([FromBody] StatisticsInput input)
        {
            var results = service.CallStoredProcedure(input);
            return Ok(results);
        }
    }
}
