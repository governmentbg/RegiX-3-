using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.RegisterObjectsLog;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/register-objects-log")]//required for default versioning
    [Route("api/v{version:apiVersion}/register-objects-log")]
    [Authorize]
    public class RegisterObjectsLogController : ABaseController<RegisterObjectsLogInDto, RegisterObjectsLogOutDto, RegisterObjectsLog, decimal>
    {
        public RegisterObjectsLogController(IRegisterObjectsLogService aBaseService) 
            : base(aBaseService)
        {
        }
    }
}
