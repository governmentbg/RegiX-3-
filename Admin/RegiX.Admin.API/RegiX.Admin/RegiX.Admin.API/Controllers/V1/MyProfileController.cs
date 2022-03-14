using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.MyProfile;
using TechnoLogica.RegiX.Admin.Infrastructure;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/my-profile")] //required for default versioning
    [Route("api/v{version:apiVersion}/my-profile")]
    [Authorize]
    public class MyProfileController : ABaseController<MyProfileInDto, MyProfileOutDto, Users, decimal>
    {
        private readonly IUserContext userContext;

        public MyProfileController(IMyProfileService aBaseService, IUserContext userContext)
            : base(aBaseService)
        {
            this.userContext = userContext;
        }
        public override IActionResult Get(decimal aId)
        {
            return base.Get(Convert.ToDecimal(this.userContext.UserId));
        }

        public override IActionResult GetAll(ODataQueryOptions<Users> aQueryOptions)
        {
            return StatusCode(405);
        }

        public override IActionResult Put(decimal aId, MyProfileInDto aInDto)
        {
            if (this.userContext.UserId != aInDto.Id)
            {
                return BadRequest("Identifiers must match !");
            }
            return base.Put(aId, aInDto);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("")]
        public override IActionResult Post(MyProfileInDto aInDto)
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
