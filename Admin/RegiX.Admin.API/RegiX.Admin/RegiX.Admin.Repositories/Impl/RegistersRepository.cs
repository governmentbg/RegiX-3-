using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="RegistersRepository" />
    /// </summary>
    public class RegistersRepository : ABaseRepository<Registers, decimal, RegiXContext>, IRegistersRepository
    {
        protected IUserContext UserContext { get; private set; }

        public RegistersRepository(RegiXContext aDbContext, IUserContext userContext)
            : base(aDbContext)
        {
            UserContext = userContext;
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{Registers}" /></returns>
        public override IQueryable<Registers> SelectAll()
        {
            var result = GetDbContext().Set<Registers>()
                 .Include(r => r.Administration)
                 .AsQueryable();


            result = this.UserContext.FilterByAdministration(result);

            return result;
        }

        /// <summary>
        ///     The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <returns>The <see cref="Registers" /></returns>
        public override Registers Select(decimal aId)
        {
            return this.SelectAll()
                .SingleOrDefault(x => x.RegisterId == aId);
        }
    }
}