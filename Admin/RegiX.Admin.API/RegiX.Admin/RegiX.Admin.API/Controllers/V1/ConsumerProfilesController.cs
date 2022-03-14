using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerProfiles;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/consumer-profiles")]//required for default versioning
    [Route("api/v{version:apiVersion}/consumer-profiles")]
    [Authorize]
    public class ConsumerProfilesController : ABaseGetAllController<ConsumerProfilesInDto, ConsumerProfilesOutDto, ConsumerProfiles, decimal>
    {
        public ConsumerProfilesController(IConsumerProfilesService aBaseService)
            : base(aBaseService)
        {
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete("{aId}")]
        public override IActionResult Delete(decimal aId)
        {
            return StatusCode(405);
        }


    }
}