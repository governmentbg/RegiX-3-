using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.RegisterAdapter;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface
        IRegisterAdapterService : IBaseService<RegisterAdapterInDto, RegisterAdapterOutDto, RegisterAdapters, decimal>
    {
    }
}