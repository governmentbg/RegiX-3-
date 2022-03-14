using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.Users;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;
using TechnoLogica.RegiX.AdapterConsole.Services.Contracts;

namespace TechnoLogica.RegiX.AdapterConsole.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/users")] //required for default versioning
    [Route("api/v{version:apiVersion}/users")]
    [Authorize]
    public class UserController : ABaseGetAllController<UsersInDto, UsersOutDto, AspNetUsers, int>
    {
        private readonly IUsersService _aBaseService;

        public UserController(IUsersService aBaseService)
            : base(aBaseService)
        {
            _aBaseService = aBaseService;
        }

        [HttpGet("getUsersByOperation/{aId}")]
        public IList<UsersOutDto> GetUsersByOperation(int aId)
        {
            return _aBaseService.GetUsersByOperation(aId);
        }
    }
}