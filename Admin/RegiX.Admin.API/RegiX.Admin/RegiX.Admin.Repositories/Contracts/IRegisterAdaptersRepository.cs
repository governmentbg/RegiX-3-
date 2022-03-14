using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Repositories.Contracts
{
    public interface IRegisterAdaptersRepository : IBaseRepository<RegisterAdapters, decimal, RegiXContext>
    {
        void Insert(RegisterAdapters aEntity, ApiServices apiServices);
    }
}