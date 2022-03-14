using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.User;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Services.Contracts;

namespace TechnoLogica.RegiX.Client.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/users")] //required for default versioning
    [Route("api/v{version:apiVersion}/users")]
    [Authorize]
    public class UserController : ABaseGetAllController<UserInDto, UserOutDto, Users, int>
    {
        public UserController(IUserService aBaseService)
            : base(aBaseService)
        {
        }
    }
}