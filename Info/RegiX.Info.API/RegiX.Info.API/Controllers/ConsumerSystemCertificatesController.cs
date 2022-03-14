using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegiX.Info.DataContracts.DTO.ConsumerSystemCertificates;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Services.Contracts;
using TechnoLogica.API.Common.Controllers;

namespace RegiX.Info.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/consumer-system-certificates")]//required for default versioning
    [Route("api/v{version:apiVersion}/consumer-system-certificates")]
    [Authorize]
    public class ConsumerSystemCertificatesController : ABaseGetAllController<ConsumerSystemCertificatesInDto, ConsumerSystemCertificatesOutDto, ConsumerSystemCertificates, decimal>
    {
        public ConsumerSystemCertificatesController(IConsumerSystemCertificatesService aBaseService)
            : base(aBaseService)
        {
        }
    }
}
