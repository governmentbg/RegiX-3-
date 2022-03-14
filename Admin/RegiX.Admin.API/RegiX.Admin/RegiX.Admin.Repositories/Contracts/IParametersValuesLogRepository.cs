using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Repositories.Contracts
{
    public interface IParametersValuesLogRepository : IBaseRepository<ParametersValuesLog, decimal, RegiXContext>
    {
    }
}