using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerCertificatesReport;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/consumer-certificates-reports")]//required for default versioning
    [Route("api/v{version:apiVersion}/consumer-certificates-reports")]
    [Authorize]
    public class ConsumerCertificatesReportController : ABaseController<ConsumerCertificatesReportInDto, ConsumerCertificatesReportOutDto, ConsumerCertificatesReports, decimal>
    {
        public ConsumerCertificatesReportController(IConsumerCertificatesReportService aBaseService) 
            : base(aBaseService)
        {
        }
    }
}
