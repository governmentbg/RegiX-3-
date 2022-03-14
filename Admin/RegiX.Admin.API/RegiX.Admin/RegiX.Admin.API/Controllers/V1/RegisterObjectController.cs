using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.RegisterObject;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/register-objects")]//required for default versioning
    [Route("api/v{version:apiVersion}/register-objects")]
    [Authorize]
    public class RegisterObjectController : ABaseController<RegisterObjectInDto, RegisterObjectOutDto, RegisterObjects, decimal>
    {
        public RegisterObjectController(IRegisterObjectService aBaseService) 
            : base(aBaseService)
        {
        }
    }
}
