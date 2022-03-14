using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AdapterOperation;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/adapter-operations")]//required for default versioning
    [Route("api/v{version:apiVersion}/adapter-operations")]
    [Authorize]
    public class AdapterOperationController : ABaseGetAllController<AdapterOperationInDto, AdapterOperationOutDto, AdapterOperations, decimal>
    {
        public AdapterOperationController(IAdapterOperationService aBaseService) 
            : base(aBaseService)
        {
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("")]
        public override IActionResult Post([FromBody]AdapterOperationInDto aInDto)
        {
            return StatusCode(405);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut("{aId}")]
        public override IActionResult Put(decimal aId, [FromBody]AdapterOperationInDto aInDto)
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
