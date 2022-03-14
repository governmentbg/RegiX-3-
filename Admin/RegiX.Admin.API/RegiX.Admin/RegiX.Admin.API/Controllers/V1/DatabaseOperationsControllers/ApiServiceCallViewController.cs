using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApiServiceCallView;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationsModels;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/api-service-calls-view")]//required for default versioning
    [Route("api/v{version:apiVersion}/api-service-calls-view")]
    [Authorize]
    public class ApiServiceCallViewController : ABaseGetAllController<ApiServiceCallViewInDto, ApiServiceCallViewOutDto, ApiServiceCallViewOutput, decimal>
    {
        public ApiServiceCallViewController(IApiServiceCallViewService aBaseService)
            : base(aBaseService)
        {
        }
    }
}

