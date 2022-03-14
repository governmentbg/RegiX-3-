using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegiX.Info.DataContracts.DTO.RegisterAdapter;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Services.Contracts;
using TechnoLogica.API.Common.Controllers;

namespace RegiX.Info.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/register-adapters")]//required for default versioning
    [Route("api/v{version:apiVersion}/register-adapters")]
    //[Authorize]
    public class RegisterAdapterController : ABaseGetAllController<RegisterAdapterInDto, RegisterAdapterOutDto, RegisterAdapters, decimal>
    {

        public RegisterAdapterController(
            IRegisterAdapterService aBaseService
            )
            : base(aBaseService)
        {
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("")]
        public override IActionResult Post([FromBody] RegisterAdapterInDto aInDto)
        {
            return StatusCode(405);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete("{aId}")]
        public override IActionResult Delete(decimal aId)
        {
            return StatusCode(405);
        }
    }
}
