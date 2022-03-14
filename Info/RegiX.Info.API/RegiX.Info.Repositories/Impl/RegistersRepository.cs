using System.Linq;
using Microsoft.EntityFrameworkCore;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;
using TechnoLogica.API.Repositories.Impl;

namespace RegiX.Info.Repositories.Impl
{
    public class RegistersRepository : ABaseRepository<Registers, decimal, RegiXContext>, IRegistersRepository
    {
        public RegistersRepository(RegiXContext aDbContext) 
            : base(aDbContext)
        {
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable" /></returns>
        public override IQueryable<Registers> SelectAll()
        {
            var result = GetDbContext().Set<Registers>()
                .Include(r => r.Administration)
                .AsQueryable();

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