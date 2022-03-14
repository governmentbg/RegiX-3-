using System.Linq;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Repositories.Contracts
{
    public interface IConsumerRoleElementAccessRepository :  IBaseRepository<ConsumerRoleElementAccess, decimal, RegiXContext>
    {
        IQueryable<ConsumerRoleElementAccess> SelectAllByConsumerRole(decimal consumerRoleId);
    }
}