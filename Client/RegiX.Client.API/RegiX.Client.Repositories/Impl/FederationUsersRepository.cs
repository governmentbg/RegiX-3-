using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;

namespace TechnoLogica.RegiX.Client.Repositories.Impl
{
    public class FederationUsersRepository : ABaseRepository<FederationUsers, int,RegiXClientContext>, IFederationUsersRepository
    {
        public FederationUsersRepository(RegiXClientContext aDbContext) : base(aDbContext)
        {
        }
    }
}