using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.UserToRole;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Services.Contracts
{
    public interface IUserToRoleService : IBaseService<UserToRoleInDto, UserToRoleOutDto, UsersToRoles, int>
    {
    }
}