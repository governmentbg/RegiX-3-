using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.Report;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/reports")]//required for default versioning
    [Route("api/v{version:apiVersion}/reports")]
    [Authorize]
    public class ReportController : ABaseController<ReportInDto, ReportOutDto, Reports, decimal>
    {
        public ReportController(IReportService aBaseService) 
            : base(aBaseService)
        {
        }
    }
}
