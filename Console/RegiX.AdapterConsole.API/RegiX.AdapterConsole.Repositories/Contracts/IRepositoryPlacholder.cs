using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Contracts;

namespace TechnoLogica.RegiX.AdapterConsole.Repositories.Contracts
{
    public interface IRepositoryPlacholder : IBaseRepository<object, int, DbContext>
    {
    }
}