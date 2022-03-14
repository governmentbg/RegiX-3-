using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AdapterHealthFunction;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/adapter-health-functions")]//required for default versioning
    [Route("api/v{version:apiVersion}/adapter-health-functions")]
    [Authorize]
    public class AdapterHealthFunctionController : ABaseController<AdapterHealthFunctionInDto, AdapterHealthFunctionOutDto, AdapterHealthFunctions, decimal>
    {
        public AdapterHealthFunctionController(IAdapterHealthFunctionService aBaseService) 
            : base(aBaseService)
        {
        }
    }
}
