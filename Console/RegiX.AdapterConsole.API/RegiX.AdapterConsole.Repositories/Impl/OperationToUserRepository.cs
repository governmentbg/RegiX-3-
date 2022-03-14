using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;
using TechnoLogica.RegiX.AdapterConsole.Repositories.Contracts;

namespace TechnoLogica.RegiX.AdapterConsole.Repositories.Impl
{
    public class OperationToUserRepository : ABaseRepository<OperationsToUsers, int, RegiXAdapterConsoleContext>,
        IOperationToUserRepository
    {
        public OperationToUserRepository(RegiXAdapterConsoleContext aDbContext, IUserContext userContext)
            : base(aDbContext)
        {
            UserContext = userContext;
        }

        protected IUserContext UserContext { get; }

        /// <summary>
        ///   The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable" /></returns>
        public override IQueryable<OperationsToUsers> SelectAll()
        {
            var result = GetDbContext().Query<OperationsToUsers>()
                .AsNoTracking()
                .AsQueryable();

            return result;
        }

        public override OperationsToUsers Select(int aId)
        {
            var result = GetDbContext().Query<OperationsToUsers>()
                .AsNoTracking()
                .AsQueryable();

            return result.SingleOrDefault(x => x.Id == aId);
        }
    }
}