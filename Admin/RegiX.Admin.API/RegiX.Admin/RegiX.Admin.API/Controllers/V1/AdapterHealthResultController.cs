using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AdapterHealthResult;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/adapter-health-results")]//required for default versioning
    [Route("api/v{version:apiVersion}/adapter-health-results")]
    [Authorize]
    public class AdapterHealthResultController : ABaseController<AdapterHealthResultInDto, AdapterHealthResultOutDto, AdapterHealthResults, decimal>
    {
        public AdapterHealthResultController(IAdapterHealthResultService aBaseService) 
            : base(aBaseService)
        {
        }
    }
}
