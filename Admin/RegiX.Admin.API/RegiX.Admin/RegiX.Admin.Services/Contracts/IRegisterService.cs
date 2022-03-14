using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.Register;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IRegisterService : IBaseService<RegisterInDto, RegisterOutDto, Registers, decimal>
    {
    }
}