using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.DTO.OperationsPersistance;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;
using TechnoLogica.RegiX.AdapterConsole.Services.Contracts;

namespace TechnoLogica.RegiX.AdapterConsole.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/operations-persistance")] //required for default versioning
    [Route("api/v{version:apiVersion}/operations-persistance")]
    //[Authorize]
    public class OperationsPersistanceController : ABaseGetAllController<OperationsPersistanceInDto, OperationsPersistanceOutDto,
        OperationsPersistance, int>
    {
        public OperationsPersistanceController(IOperationsPersistanceService aBaseService)
            : base(aBaseService)
        {
        }
    }
}
