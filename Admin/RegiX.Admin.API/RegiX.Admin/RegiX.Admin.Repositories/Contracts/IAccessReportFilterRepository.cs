using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationsModels;

namespace TechnoLogica.RegiX.Admin.Repositories.Contracts
{
    public interface IAccessReportFilterRepository : IBaseRepository<AccessReportFilterView, decimal, RegiXContext>
    {
    }
}
