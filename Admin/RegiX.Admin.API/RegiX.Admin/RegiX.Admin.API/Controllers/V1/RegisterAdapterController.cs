using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.RegisterAdapter;
using TechnoLogica.RegiX.Admin.API.RegiXInfo;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/register-adapters")]//required for default versioning
    [Route("api/v{version:apiVersion}/register-adapters")]
    [Authorize]
    public class RegisterAdapterController : ABaseGetAllController<RegisterAdapterInDto, RegisterAdapterOutDto, RegisterAdapters, decimal>
    {
        private IInfoAPIClient InfoAPIClient { get; set; }

        public RegisterAdapterController(
            IRegisterAdapterService aBaseService,
            IInfoAPIClient infoAPIClient) 
            : base(aBaseService)
        {
            InfoAPIClient = infoAPIClient;
        }

        [HttpPut("{aId}")]
        public override IActionResult Put(decimal aId, [FromBody] RegisterAdapterInDto aInDto)
        {
            var result = base.Put(aId, aInDto);
            InfoAPIClient.NotifyInfoAPI().Wait();
            return result;
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
