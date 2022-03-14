using TechnoLogica.API.Services;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.DTO.UserToReports;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;

namespace TechnoLogica.RegiX.AdapterConsole.Services.Contracts
{
    public interface IOperationToUserService : IBaseService<OperationToUserInDto, OperationToUserOutDto,
        OperationsToUsers, int
    >
    {
    }
}