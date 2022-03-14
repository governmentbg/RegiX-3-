using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationsModels;

namespace TechnoLogica.RegiX.Admin.Repositories.Contracts.DatabaseOperationsRepositoriesInterfaces
{
    public interface IApiServiceCallViewRepository : IBaseRepository<ApiServiceCallViewOutput, decimal, RegiXContext>
    {
    }
}
