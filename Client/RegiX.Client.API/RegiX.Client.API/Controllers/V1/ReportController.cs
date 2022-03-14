using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.Reports;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Services.Contracts;

namespace TechnoLogica.RegiX.Client.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/reports")] //required for default versioning
    [Route("api/v{version:apiVersion}/reports")]
    [Authorize]
    public class ReportController : ABaseGetAllController<ReportsInDto, ReportsOutDto, Reports, int>
    {
        public ReportController(IReportService aBaseService)
            : base(aBaseService)
        {
        }
    }
}