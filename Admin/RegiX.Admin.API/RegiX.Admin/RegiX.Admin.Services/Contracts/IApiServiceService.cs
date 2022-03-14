using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApiService;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IApiServiceService : IBaseService<ApiServiceInDto, ApiServiceOutDto, ApiServices, decimal>
    {
    }
}