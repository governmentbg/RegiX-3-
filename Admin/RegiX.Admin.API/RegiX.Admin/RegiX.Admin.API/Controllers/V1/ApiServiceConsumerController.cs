using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApiServiceConsumer;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;
namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/api-service-consumers")]//required for default versioning
    [Route("api/v{version:apiVersion}/api-service-consumers")]
    [Authorize]
    public class ApiServiceConsumerController : ABaseGetAllController<ApiServiceConsumerInDto, ApiServiceConsumerOutDto, ApiServiceConsumers, decimal>
    {
        public ApiServiceConsumerController(IApiServiceConsumerService aBaseService) 
            : base(aBaseService)
        {
        }
    }
}
