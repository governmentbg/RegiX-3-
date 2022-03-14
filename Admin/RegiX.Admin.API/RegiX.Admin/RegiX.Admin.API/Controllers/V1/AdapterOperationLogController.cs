using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AdapterOperationLog;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/adapter-operation-log")]//required for default versioning
    [Route("api/v{version:apiVersion}/adapter-operation-log")]
    [Authorize]
    public class AdapterOperationLogController : ABaseController<AdapterOperationLogInDto, AdapterOperationLogOutDto, AdapterOperationLog, decimal>
    {
        public AdapterOperationLogController(IAdapterOperationLogService aBaseService) 
            : base(aBaseService)
        {
        }
    }
}
