using RegiX.Info.Infrastructure.Models;
using System.Linq;
using TechnoLogica.API.Repositories.Contracts;

namespace RegiX.Info.Repositories.Contracts
{
    public interface IRegisterObjectElementsRepository : IBaseRepository<RegisterObjectElements, decimal, RegiXContext>
    {
        IQueryable<RegisterObjectElements> SelectAllByRegisterObjectId(decimal registerObjectId);
    }
}
