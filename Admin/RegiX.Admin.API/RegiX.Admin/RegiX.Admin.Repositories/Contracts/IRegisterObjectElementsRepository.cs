using System.Linq;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Repositories.Contracts
{
    public interface IRegisterObjectElementsRepository : IBaseRepository<RegisterObjectElements, decimal, RegiXContext>
    {
        IQueryable<RegisterObjectElements> SelectAllByRegisterObjectId(decimal registerObjectId);
    }
}