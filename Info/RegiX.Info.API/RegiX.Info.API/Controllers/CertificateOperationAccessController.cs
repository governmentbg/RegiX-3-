using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegiX.Info.DataContracts.DTO.CertificateOperationAccess;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Services.Contracts;
using TechnoLogica.API.Common.Controllers;

namespace RegiX.Info.API.Controllers
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