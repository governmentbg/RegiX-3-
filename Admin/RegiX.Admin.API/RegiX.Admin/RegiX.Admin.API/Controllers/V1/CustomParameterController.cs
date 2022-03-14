using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.CustomParameter;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/custom-parameters")]//required for default versioning
    [Route("api/v{version:apiVersion}/custom-parameters")]
    [Authorize]
    public class CustomParameterController : ABaseController<CustomParameterInDto, CustomParameterOutDto, CustomParameters, decimal>
    {
        public CustomParameterController(ICustomParameterService aBaseService) 
            : base(aBaseService)
        {
        }
    }
}
