using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApiServiceOperationLog;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/api-service-operation-log")]//required for default versioning
    [Route("api/v{version:apiVersion}/api-service-operation-log")]
    [Authorize]
    public class ApiServiceOperationLogController : ABaseController<ApiServiceOperationLogInDto, ApiServiceOperationLogOutDto, ApiServiceOperationLog, decimal>
    {
        public ApiServiceOperationLogController(IApiServiceOperationLogService aBaseService) 
            : base(aBaseService)
        {
        }
    }
}
