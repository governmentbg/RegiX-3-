using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AccessReportFilterConsumer;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationsModels;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1.DatabaseOperationsControllers
{
    [ApiVersion("1.0")]
    [Route("api/access-report-filter-consumer")]//required for default versioning
    [Route("api/v{version:apiVersion}/access-report-filter-consumer")]
    [Authorize]
    public class AccessReportFilterConsumerController : ABaseGetAllController<AccessReportFilterConsumerInDto, AccessReportFilterConsumerOutDto, AccessReportFilterConsumerView, decimal>
    {
        public AccessReportFilterConsumerController(IAccessReportFilterConsumerService aBaseService)
            : base(aBaseService)
        {
        }
    }
}

