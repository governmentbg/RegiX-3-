using TechnoLogica.API.Services;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.OperationsToRoles;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;

namespace TechnoLogica.RegiX.AdapterConsole.Services.Contracts
{
    public interface IOperationsToRolesService : IBaseService<OperationsToRolesInDto, OperationsToRolesOutDto,
        OperationsToRoles, int
    >
    {
    }
}