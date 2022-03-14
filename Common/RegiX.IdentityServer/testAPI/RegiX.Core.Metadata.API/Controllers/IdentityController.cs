using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegiX.Core.Metadata.API
{
    [Route("identity")]
    [Authorize]     
    public class IdentityController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }


        [Route("administrationID")]
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult GetAdministrationID()
        {
            return new JsonResult(
                from c in User.Claims
                select new { c.Type, c.Value });
        }
    }
}
