using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.ReportsForUsersView;
using TechnoLogica.RegiX.Client.Infrastructure.Models.DatabaseObjectModels;
using TechnoLogica.RegiX.Client.Services.Contracts;

namespace TechnoLogica.RegiX.Client.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/reports-for-users")] //required for default versioning
    [Route("api/v{version:apiVersion}/reports-for-users")]
    [Authorize]
    public class ReportsForUsersViewController : ABaseGetAllController<ReportsForUsersViewInDto,
        ReportsForUsersViewOutDto, ReportsForUsersView, int>
    {
        public ReportsForUsersViewController(IReportsForUsersService aBaseService)
            : base(aBaseService)
        {
        }
    }
}