using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApiServiceAdapterOperation;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/api-service-adapter-operations")]//required for default versioning
    [Route("api/v{version:apiVersion}/api-service-adapter-operations")]
    [Authorize]
    public class ApiServiceAdapterOperationController : ABaseController<ApiServiceAdapterOperationInDto, ApiServiceAdapterOperationOutDto, ApiServiceAdapterOperations, decimal>
    {
        public ApiServiceAdapterOperationController(IApiServiceAdapterOperationService aBaseService) 
            : base(aBaseService)
        {
        }
    }
}
