using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using RegiX.Info.DataContracts.DTO.AdapterOperations;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using TechnoLogica.API.Common.Controllers;

namespace RegiX.Info.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/adapter-operations")]//required for default versioning
    [Route("api/v{version:apiVersion}/adapter-operations")]
    //[Authorize]
    public class AdapterOperationController : ABaseGetAllController<AdapterOperationInDto, AdapterOperationOutDto, AdapterOperations, decimal>
    {
        public AdapterOperationController(
            IAdapterOperationService aBaseService)
            : base(aBaseService)
        {
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("")]
        public override IActionResult Post([FromBody] AdapterOperationInDto aInDto)
        {
            return StatusCode(405);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut("{aId}")]
        public override IActionResult Put(decimal aId, [FromBody] AdapterOperationInDto aInDto)
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
