using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoLogica.RegiX.Client.Services.Contracts;

namespace TechnoLogica.RegiX.Client.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/sync")] //required for default versioning
    [Route("api/v{version:apiVersion}/sync")]
    [Authorize]
    public class SyncController : ControllerBase
    {
        private  IMetadataSyncService SyncService { get; set; }
        public SyncController(IMetadataSyncService syncService)
        {
            SyncService = syncService;
        }

        [HttpGet("")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Get()
        {
            SyncService.UpdateMetadata();
            return Ok();
        }
    }
}
