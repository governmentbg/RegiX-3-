using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Repositories.Contracts
{
    public interface IAuthoritiesRepository : IBaseRepository<Authorities, int, RegiXClientContext>
    {
        Authorities SelectByCode(string code);
        int GenerateReportsAndRoleForAuth(int authorityId);
    }
}