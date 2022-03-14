using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Repositories.Contracts
{
    public interface IApiServicesRepository : IBaseRepository<ApiServices, decimal, RegiXContext>
    {
    }
}