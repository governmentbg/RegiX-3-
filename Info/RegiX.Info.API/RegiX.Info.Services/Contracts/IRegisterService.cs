using RegiX.Info.DataContracts.DTO.Registers;
using RegiX.Info.Infrastructure.Models;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Contracts
{
    public interface IRegistersService : IBaseService<RegisterInDto, RegisterOutDto, Registers, decimal>
    {
    }
}