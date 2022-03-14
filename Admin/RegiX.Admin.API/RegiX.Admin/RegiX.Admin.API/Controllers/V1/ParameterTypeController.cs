using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ParameterType;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/parameter-types")]//required for default versioning
    [Route("api/v{version:apiVersion}/parameter-types")]
    [Authorize]
    public class ParameterTypeController : ABaseController<ParameterTypeInDto, ParameterTypeOutDto, ParameterTypes, decimal>
    {
        public ParameterTypeController(IParameterTypeService aBaseService) 
            : base(aBaseService)
        {
        }
    }
}
