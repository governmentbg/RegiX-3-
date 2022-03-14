using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AccessReportFilter;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationsModels;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1.DatabaseOperationsControllers
{
    [ApiVersion("1.0")]
    [Route("api/access-report-filter")]//required for default versioning
    [Route("api/v{version:apiVersion}/access-report-filter")]
    [Authorize]
    public class AccessReportFilterController : ABaseGetAllController<AccessReportFilterInDto, AccessReportFilterOutDto, AccessReportFilterView, decimal>
    {
        public AccessReportFilterController(IAccessReportFilterService aBaseService) 
            : base(aBaseService)
        {
        }

        
    }
}
