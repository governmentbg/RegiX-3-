using RegiX.Info.DataContracts.DTO.RegisterAdapter;
using RegiX.Info.Infrastructure.Models;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Contracts
{
    public interface
        IRegisterAdapterService : IBaseService<RegisterAdapterInDto, RegisterAdapterOutDto, RegisterAdapters, decimal>
    {
    }
}