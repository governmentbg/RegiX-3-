using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ElementConsumers;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace RegiX.Admin.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/certificate-operation-access-extended")]//required for default versioning
    [Route("api/v{version:apiVersion}/certificate-operation-access-extended")]
    [Authorize]
    public class CertificateOperationAccessExtendedController : ABaseController<CertificateOperationAccessExtendedInDto, CertificateOperationAccessExtendedOutDto, CertificateOperationAccessExtended, decimal>
    {
        public CertificateOperationAccessExtendedController(ICertificateOperationAccessExtendedService aBaseService) : 
            base(aBaseService)
        {
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut("{aId}")]
        public override IActionResult Put(decimal aId, [FromBody]CertificateOperationAccessExtendedInDto aInDto)
        {
            return StatusCode(405);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("")]
        public override IActionResult Post([FromBody]CertificateOperationAccessExtendedInDto aInDto)
        {
            return StatusCode(405);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete("{aId}")]
        public override IActionResult Delete(decimal aId)
        {
            return StatusCode(405);
        }
    }
}