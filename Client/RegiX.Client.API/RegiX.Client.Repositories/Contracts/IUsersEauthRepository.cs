using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Repositories.Contracts
{
    public interface IUsersEauthRepository : IBaseRepository<UsersEauth, int, RegiXClientContext>
    {
    }
}