using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RegiX.Info.DataContracts.DTO.CertificateElementAccess;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Services.Contracts;
using TechnoLogica.API.Common.Controllers;

namespace RegiX.Info.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/certificate-element-access")]//required for default versioning
    [Route("api/v{version:apiVersion}/certificate-element-access")]
    //[Authorize]
    public class CertificateElementAccessController : ABaseGetAllController<CertificateElementAccessInDto, CertificateElementAccessOutDto, CertificateElementAccess, decimal>
    {
        private readonly ICertificateElementAccessService aBaseService;

        public CertificateElementAccessController(ICertificateElementAccessService aBaseService)
            : base(aBaseService)
        {
            this.aBaseService = aBaseService;
        }

        [HttpPost("GetCertificateElementAccess/{consumerSystemCertificateId}/{adapterOperationId}")]
        public IEnumerable<CertificateElementAccessOutDto> GetNames(int consumerSystemCertificateId,int adapterOperationId)
        {
           return this.aBaseService.GetElementsByAdapterOperation(consumerSystemCertificateId, adapterOperationId);
        }
    }
}