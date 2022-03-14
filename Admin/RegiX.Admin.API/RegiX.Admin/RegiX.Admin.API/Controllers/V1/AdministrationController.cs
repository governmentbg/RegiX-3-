using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.RegiXInfo;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/administrations")]//required for default versioning
    [Route("api/v{version:apiVersion}/administrations")]
    [Authorize]
    public class AdministrationController : ABaseGetAllController<AdministrationInDto, AdministrationOutDto, Administrations, decimal>
    {
        private IInfoAPIClient InfoAPIClient { get; set; }

        public AdministrationController(
            IAdministrationService aBaseService, 
            IInfoAPIClient infoAPIClient) 
            : base(aBaseService)
        {
            InfoAPIClient = infoAPIClient;
        }

        public override IActionResult GetAll(ODataQueryOptions<Administrations> aQueryOptions)
        {
            return base.GetAll(aQueryOptions);
        }

        [AllowAnonymous]
        [HttpGet("GetAllPrimariesAnonymous")]
        public IActionResult GetAllPrimariesAnonymous(ODataQueryOptions<Administrations> aQueryOptions)
        {
            return Ok((this.baseService as IAdministrationService).SelectAllPrimariesAnonymous(aQueryOptions));
        }

        [HttpGet("GetAllPrimaries")]
        public IActionResult GetAllPrimaries(ODataQueryOptions<Administrations> aQueryOptions)
        {
            return Ok((this.baseService as IAdministrationService).SelectAllPrimaries(aQueryOptions));
        }

        [HttpGet("GetAllPrimariesWithPagination")]
        public IActionResult GetAllPrimariesWithPagination(ODataQueryOptions<Administrations> aQueryOptions)
        {
            return Ok((this.baseService as IAdministrationService).SelectAllPrimariesWithPagination(aQueryOptions));
        }

        [HttpPut("{aId}")]
        public override IActionResult Put(decimal aId, [FromBody] AdministrationInDto aInDto)
        {
            var result = base.Put(aId, aInDto);
            if ((this.baseService as IAdministrationService).IsPrimary(aId))
            {
                InfoAPIClient.NotifyInfoAPI().Wait();
            }
            return result;
        }
    }
}
