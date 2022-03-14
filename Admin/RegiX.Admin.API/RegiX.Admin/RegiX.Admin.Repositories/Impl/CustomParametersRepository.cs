using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="CustomParametersRepository" />
    /// </summary>
    public class CustomParametersRepository : ABaseRepository<CustomParameters, decimal, RegiXContext>,
        ICustomParametersRepository
    {
        public CustomParametersRepository(RegiXContext aDbContext)
            : base(aDbContext)
        {
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{CustomParameters}" /></returns>
        public override IQueryable<CustomParameters> SelectAll()
        {
            return GetDbContext().Set<CustomParameters>()
                .Include(r => r.OperationParameter)
                .Include(r => r.Report)
                .AsQueryable();
        }

        /// <summary>
        ///     The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <returns>The <see cref="CustomParameters" /></returns>
        public override CustomParameters Select(decimal aId)
        {
            return GetDbContext().Set<CustomParameters>()
                .Include(r => r.OperationParameter)
                .Include(r => r.Report)
                .SingleOrDefault(r => r.Id == aId);
        }
    }
}