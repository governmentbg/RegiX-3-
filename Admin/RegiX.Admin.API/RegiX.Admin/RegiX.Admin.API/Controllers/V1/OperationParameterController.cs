using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.OperationParameter;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/operation-parameters")]//required for default versioning
    [Route("api/v{version:apiVersion}/operation-parameters")]
    [Authorize]
    public class OperationParameterController : ABaseController<OperationParameterInDto, OperationParameterOutDto, OperationParameters, decimal>
    {
        public OperationParameterController(IOperationParameterService aBaseService) 
            : base(aBaseService)
        {
        }
    }
}
