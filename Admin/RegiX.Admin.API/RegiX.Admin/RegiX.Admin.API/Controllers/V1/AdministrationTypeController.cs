using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AdministrationType;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/administration-types")]//required for default versioning
    [Route("api/v{version:apiVersion}/administration-types")]
    [Authorize]
    public class AdministrationTypeController : ABaseGetAllController<AdministrationTypeInDto, AdministrationTypeOutDto, AdministrationTypes, decimal>
    {
        public AdministrationTypeController(IAdministrationTypeService aBaseService) 
            : base(aBaseService)
        {
        }
    }
}
