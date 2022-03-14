using System.Collections.Generic;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.Users;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;

namespace TechnoLogica.RegiX.AdapterConsole.Services.Contracts
{
    public interface IUsersService : IBaseService<UsersInDto, UsersOutDto, AspNetUsers, int
    >
    {
        IList<UsersOutDto> GetUsersByOperation(int aId);
    }
}