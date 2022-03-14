using TechnoLogica.API.Services;
using TechnoLogica.RegiX.AdapterConsole.DataContracts;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;

namespace TechnoLogica.RegiX.AdapterConsole.Services.Contracts
{
    public interface IRolesService : IBaseService<RolesInDto, RolesOutDto, AspNetRoles, int
    >
    {
    }
}