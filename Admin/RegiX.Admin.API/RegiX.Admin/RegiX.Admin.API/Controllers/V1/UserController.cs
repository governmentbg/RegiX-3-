using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/users")]//required for default versioning
    [Route("api/v{version:apiVersion}/users")]
    [Authorize]
    public class UserController : ABaseController<UserInDto, UserOutDto, Users, decimal>
    {
        public UserController(IUserService aBaseService) 
            : base(aBaseService)
        {
        }
    }
}
