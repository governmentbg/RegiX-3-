using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.Authorities;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Services.Contracts;

namespace TechnoLogica.RegiX.Client.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/authorities")] //required for default versioning
    [Route("api/v{version:apiVersion}/authorities")]
    [Authorize]
    public class AuthorityController : ABaseGetAllController<AuthoritiesInDto, AuthoritiesOutDto, Authorities, int>
    {
        public AuthorityController(IAuthoritiesService aBaseService)
            : base(aBaseService)
        {
        }

        [HttpGet("")]
        [AllowAnonymous]
        public override IActionResult GetAll(ODataQueryOptions<Authorities> aOptions)
        {
            return base.GetAll(aOptions);
        }

        /// <summary>
        /// </summary>
        /// <returns>The IActionResult</returns>
        [HttpGet("getAllProviders")]
        public virtual IActionResult GetAllProvidersNoWrap(ODataQueryOptions<Authorities> aOptions)
        {
            var result = ((IAuthoritiesService) baseService).SelectAllProvidersNoWrap(aOptions);
            return Ok(result);
        }

        /// <summary>
        /// Generate reports and roles for authority based on access in RegiX
        /// </summary>
        /// <param name="authorityId"></param>
        /// <returns></returns>
        [HttpGet("GenerateReportsAndRoleForAuth/{authorityId}")]
        [Authorize(Roles = "GLOBAL_ADMIN")]
        public IActionResult GenerateReportsAndRoleForAuth(int authorityId)
        {
            var result = ((IAuthoritiesService)baseService).GenerateReportsAndRoleForAuth(authorityId);
            return Ok(result);
        }
    }
}