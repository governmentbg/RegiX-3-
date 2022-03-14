using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="RegisterObjectElementsRepository" />
    /// </summary>
    public class RegisterObjectElementsRepository : ABaseRepository<RegisterObjectElements, decimal, RegiXContext>,
        IRegisterObjectElementsRepository
    {
        public RegisterObjectElementsRepository(RegiXContext aDbContext)
            : base(aDbContext)
        {
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{RegisterObjectElements}" /></returns>
        public override IQueryable<RegisterObjectElements> SelectAll()
        {
            return GetDbContext().Set<RegisterObjectElements>()
                .Include(r => r.RegisterObject)
                .AsQueryable();
        }

        /// <summary>
        ///     The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <returns>The <see cref="RegisterObjectElements" /></returns>
        public override RegisterObjectElements Select(decimal aId)
        {
            return GetDbContext().Set<RegisterObjectElements>()
                .Include(r => r.RegisterObject)
                .SingleOrDefault(r => r.RegisterObjectElementId == aId);
        }

        /// <summary>
        ///  Select all elemets for specific operation of the adapter 
        /// </summary>
        /// <returns></returns>
        public  IQueryable<RegisterObjectElements> SelectAllByRegisterObjectId(decimal registerObjectId)
        {
            return this.SelectAll().Where(x => x.RegisterObjectId == registerObjectId);
        }
    }
}