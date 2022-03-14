using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts.DatabaseOperationsServicesInterfaces;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1.DatabaseOperationsControllers
{
    [ApiVersion("1.0")]
    [Route("api/consumer-request-operation-db")]//required for default versioning
    [Route("api/v{version:apiVersion}/consumer-request-operation-db")]
    [Authorize]
    public class ConsumerRequestOperationDbController : Controller
    {
        protected IDatabaseOperationService service;

        public ConsumerRequestOperationDbController(IDatabaseOperationService aService)
        {
            service = aService;
        }

        [HttpGet("{Id}")]
        public IActionResult Get(decimal Id)
        {
            var results = service.GetHierarchyByOperationId(Id);
            return Ok(results);
        }
    }
}
