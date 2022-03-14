using Microsoft.AspNetCore.Mvc;
using RegiX.Info.Services.Contracts;

namespace RegiX.Info.API.Controllers.DatabaseOperationsControllers
{
    [ApiVersion("1.0")]
    [Route("api/consumer-request-operation-db")]//required for default versioning
    [Route("api/v{version:apiVersion}/consumer-request-operation-db")]
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