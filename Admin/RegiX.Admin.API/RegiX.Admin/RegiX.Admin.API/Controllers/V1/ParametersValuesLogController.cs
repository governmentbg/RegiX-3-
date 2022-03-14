using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ParametersValuesLog;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/parameters-values-log")]//required for default versioning
    [Route("api/v{version:apiVersion}/parameters-values-log")]
    [Authorize]
    public class ParametersValuesLogController : ABaseController<ParametersValuesLogInDto, ParametersValuesLogOutDto, ParametersValuesLog, decimal>
    {
        public ParametersValuesLogController(IParametersValuesLogService aBaseService) 
            : base(aBaseService)
        {
        }
    }
}
