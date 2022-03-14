using System.Linq;
using RegiX.Info.Infrastructure.Models;
using TechnoLogica.API.Repositories.Contracts;

namespace RegiX.Info.Repositories.Contracts
{
    public interface IAdministrationRepository : IBaseRepository<Administrations, decimal, RegiXContext>
    {
        IQueryable<Administrations> SelectAllPrimaries();
    }
}