using System.Linq;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Repositories.Contracts
{
    public interface IAdministrationsRepository : IBaseRepository<Administrations, decimal, RegiXContext>
    {
        IQueryable<Administrations> SelectAllPrimariesAnonymous();
        IQueryable<Administrations> SelectAllPrimaries();
    }
}