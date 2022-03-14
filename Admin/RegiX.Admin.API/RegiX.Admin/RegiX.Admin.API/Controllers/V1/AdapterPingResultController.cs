using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AdapterPingResult;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;
namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/adapter-ping-results")]//required for default versioning
    [Route("api/v{version:apiVersion}/adapter-ping-results")]
    [Authorize]
    public class AdapterPingResultController : ABaseController<AdapterPingResultInDto, AdapterPingResultOutDto, AdapterPingResults, decimal>
    {
        public AdapterPingResultController(IAdapterPingResultService aBaseService) 
            : base(aBaseService)
        {
        }
    }
}
