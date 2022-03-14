using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApiServiceOperation;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/api-service-operations")]//required for default versioning
    [Route("api/v{version:apiVersion}/api-service-operations")]
    [Authorize]
    public class ApiServiceOperationController : ABaseGetAllController<ApiServiceOperationInDto, ApiServiceOperationOutDto, ApiServiceOperations, decimal>
    {
        public ApiServiceOperationController(IApiServiceOperationService aBaseService) 
            : base(aBaseService)
        {
        }
    }
}
