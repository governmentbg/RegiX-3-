using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApiServiceCall;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface
        IApiServiceCallService : IBaseService<ApiServiceCallInDto, ApiServiceCallOutDto, ApiServiceCalls, decimal>
    {
    }
}