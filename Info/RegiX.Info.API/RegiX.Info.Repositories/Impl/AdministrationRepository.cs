using System.Linq;
using Microsoft.EntityFrameworkCore;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;
using TechnoLogica.API.Repositories.Impl;

namespace RegiX.Info.Repositories.Impl
{
    public class AdministrationRepository : ABaseRepository<Administrations, decimal, RegiXContext>, IAdministrationRepository
    {
        public AdministrationRepository(RegiXContext aDbContext) 
            : base(aDbContext)
        {
        }

        public IQueryable<Administrations> SelectAllPrimaries()
        {
            var result =
                GetDbContext()
                    .Set<Administrations>()
                    .Include(r => r.ParentAuthority)
                    .Include(r => r.Registers)
                    .Where(a => a.Registers.Count > 0);

            return result;
        }
    }
}