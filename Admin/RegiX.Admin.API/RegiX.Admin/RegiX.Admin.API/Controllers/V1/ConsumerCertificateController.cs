using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerCertificate;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/consumer-certificates")]//required for default versioning
    [Route("api/v{version:apiVersion}/consumer-certificates")]
    [Authorize]
    public class ConsumerCertificateController : ABaseGetAllController<ConsumerCertificateInDto, ConsumerCertificateOutDto, ConsumerCertificates, decimal>
    {
        private readonly IConsumerCertificateService aBaseService;

        public ConsumerCertificateController(IConsumerCertificateService aBaseService) 
            : base(aBaseService)
        {
            this.aBaseService = aBaseService;
        }

        [HttpGet("SwapCertificates/{sourceId}/{destinationId}")]
        public ConsumerCertificateOutDto SwapCertificates(decimal sourceId, decimal destinationId)
        {
            var result = this.aBaseService.SwapCertificates(sourceId, destinationId);
            return result;
        }
    }
}
