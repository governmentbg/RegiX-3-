using TechnoLogica.API.Services;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.UsersToRoles;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;

namespace TechnoLogica.RegiX.AdapterConsole.Services.Contracts
{
    public interface IUsersToRolesService : IBaseService<UsersToRolesInDto, UsersToRolesOutDto, AspNetUserRoles, int
    >
    {
    }
}