using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="AdministrationsRepository" />
    /// </summary>
    public class AdministrationsRepository : ABaseRepository<Administrations, decimal, RegiXContext>,
        IAdministrationsRepository
    {
        protected IUserContext UserContext { get; private set; }
        public AdministrationsRepository(RegiXContext aDbContext, IUserContext userContext)
            : base(aDbContext)
        {
            UserContext = userContext;
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{Administrations}" /></returns>
        public override IQueryable<Administrations> SelectAll()
        {
            var result = GetDbContext().Set<Administrations>()
               .Include(r => r.AdministrationType)
               .Include(r => r.ParentAuthority)
               .AsQueryable();

            return result;
        }

        /// <summary>
        ///     The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <returns>The <see cref="Administrations" /></returns>
        public override Administrations Select(decimal aId)
        {
            return GetDbContext().Set<Administrations>()
                .Include(r => r.AdministrationType)
                .Include(r => r.ParentAuthority)
                .SingleOrDefault(r => r.AdministrationId == aId);
        }

        public IQueryable<Administrations> SelectAllPrimaries()
        {
            var result =
              GetDbContext()
                .Set<Administrations>()
                .Include(r => r.AdministrationType)
                .Include(r => r.ParentAuthority)
                .Include(r => r.Registers)
                .Where(a => a.Registers.Count > 0);

            result = this.UserContext.FilterByAdministration(result, r => r.AdministrationId);

            return result;
        }
        public IQueryable<Administrations> SelectAllPrimariesAnonymous()
        {
            var result =
                GetDbContext()
                .Set<Administrations>()
                .Include(r => r.AdministrationType)
                .Include(r => r.ParentAuthority)
                .Include(r => r.Registers)
                .Where(a => a.Registers.Count > 0);

            return result;
        }
    }
}