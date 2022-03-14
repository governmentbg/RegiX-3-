using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.CertificateConsumerRole;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/certificate-consumer-role")]
    [Route("api/v{version:apiVersion}/certificate-consumer-role")]
    [Authorize]
    public class CertificateConsumerRoleController : ABaseGetAllController<CertificateConsumerRoleInDto, CertificateConsumerRoleOutDto, CertificateConsumerRole, decimal>
    {
        public CertificateConsumerRoleController(ICertificateConsumerRoleService aBaseService)
            : base(aBaseService)
        {
        }
    }
}