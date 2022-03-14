using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="OperationParametersRepository" />
    /// </summary>
    public class OperationParametersRepository : ABaseRepository<OperationParameters, decimal, RegiXContext>,
        IOperationParametersRepository
    {
        public OperationParametersRepository(RegiXContext aDbContext)
            : base(aDbContext)
        {
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{OperationParameters}" /></returns>
        public override IQueryable<OperationParameters> SelectAll()
        {
            return GetDbContext().Set<OperationParameters>()
                .Include(r => r.ParameterType)
                .Include(r => r.ServiceOperation)
                .AsQueryable();
        }

        /// <summary>
        ///     The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <returns>The <see cref="OperationParameters" /></returns>
        public override OperationParameters Select(decimal aId)
        {
            return this.SelectAll()
                .SingleOrDefault(r => r.Id == aId);
        }
    }
}