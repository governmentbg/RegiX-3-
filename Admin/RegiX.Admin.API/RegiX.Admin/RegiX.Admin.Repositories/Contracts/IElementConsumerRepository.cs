using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationService;

namespace TechnoLogica.RegiX.Admin.Repositories.Contracts
{
    public interface IElementConsumerRepository : IBaseRepository<GetElementConsumersViewOutput, decimal, RegiXContext>
    {
    }
}
