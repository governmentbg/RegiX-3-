using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApprovedRequestElements;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/approved-request-elements")]//required for default versioning
    [Route("api/v{version:apiVersion}/approved-request-elements")]
    [Authorize]
    public class ApprovedRequestElementsController : ABaseGetAllController<ApprovedRequestElementsInDto, ApprovedRequestElementsOutDto, ApprovedRequestElements, decimal>
    {
        public ApprovedRequestElementsController(IApprovedRequestElementsService aBaseService)
            : base(aBaseService)
        {
        }
    }
}
