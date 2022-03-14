using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;

namespace TechnoLogica.RegiX.Client.Repositories.Impl
{
    public class UsersEauthRepository : ABaseRepository<UsersEauth, int,RegiXClientContext>, IUsersEauthRepository
    {
        public UsersEauthRepository(RegiXClientContext aDbContext) : base(aDbContext)
        {
        }
    }
}