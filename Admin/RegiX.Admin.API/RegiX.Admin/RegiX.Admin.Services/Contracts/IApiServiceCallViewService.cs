using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApiServiceCallView;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationsModels;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IApiServiceCallViewService : IBaseService<ApiServiceCallViewInDto, ApiServiceCallViewOutDto, ApiServiceCallViewOutput, decimal>
    {
    }
}
