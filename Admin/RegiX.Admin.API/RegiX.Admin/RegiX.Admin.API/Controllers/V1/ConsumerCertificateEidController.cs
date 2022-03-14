using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerCertificateEid;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/consumer-certificate-eids")]//required for default versioning
    [Route("api/v{version:apiVersion}/consumer-certificate-eids")]
    [Authorize]
    public class ConsumerCertificateEidController : ABaseController<ConsumerCertificateEidInDto, ConsumerCertificateEidOutDto, ConsumerCertificateEids, decimal>
    {
        public ConsumerCertificateEidController(IConsumerCertificateEidService aBaseService) 
            : base(aBaseService)
        {
        }
    }
}
