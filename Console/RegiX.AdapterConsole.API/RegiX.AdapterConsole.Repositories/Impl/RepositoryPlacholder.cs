using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.AdapterConsole.Repositories.Contracts;

namespace TechnoLogica.RegiX.AdapterConsole.Repositories.Impl
{
    public class RepositoryPlacholder : ABaseRepository<object, int, DbContext>, IRepositoryPlacholder
    {
        public RepositoryPlacholder(DbContext aDbContext) : base(aDbContext)
        {
        }
    }
}