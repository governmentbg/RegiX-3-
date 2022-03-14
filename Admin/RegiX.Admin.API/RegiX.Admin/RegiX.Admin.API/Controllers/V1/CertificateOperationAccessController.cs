using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.CertificateOperationAccess;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/certificate-operation-access")]//required for default versioning
    [Route("api/v{version:apiVersion}/certificate-operation-access")]
    [Authorize]
    public class CertificateOperationAccessController : ABaseGetAllController<CertificateOperationAccessInDto, CertificateOperationAccessOutDto, CertificateOperationAccess, decimal>
    {
        public CertificateOperationAccessController(ICertificateOperationAccessService aBaseService) 
            : base(aBaseService)
        {
        }
    }
}
