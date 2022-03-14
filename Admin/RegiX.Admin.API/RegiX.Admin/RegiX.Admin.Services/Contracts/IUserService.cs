using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IUserService : IBaseService<UserInDto, UserOutDto, Users, decimal>
    {
    }
}