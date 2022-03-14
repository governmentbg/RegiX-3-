using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.MyProfileDtos;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories;
using TechnoLogica.RegiX.Client.Services.Contracts;

namespace TechnoLogica.RegiX.Client.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/my-profile")] //required for default versioning
    [Route("api/v{version:apiVersion}/my-profile")]
    [Authorize]
    public class MyProfileController : ABaseController<MyProfileInDto, MyProfileOutDto, Users, int>
    {
        private readonly IUserContext userContext;

        public MyProfileController(IMyProfileService aBaseService, IUserContext userContext)
            : base(aBaseService)
        {
            this.userContext = userContext;
        }


        public override IActionResult Put(int aId, MyProfileInDto aInDto)
        {
            if (this.userContext.UserId != aInDto.Id || this.userContext.IsPublic)
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
        public override IActionResult Delete(int aId)
        {
            return StatusCode(405);
        }
    }
}