using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TechnoLogica.API.Repositories.Contracts
{
    public interface IBaseRepository<T, P, Db>
        where T : class
        where P : struct
        where Db : DbContext
    {
        IQueryable<T> SelectAll();

        T Select(P aId);

        T Insert(T aEntity);

        T Update(T aEntity);

        T Delete(P aId);

        Db GetDbContext();
    }
}
