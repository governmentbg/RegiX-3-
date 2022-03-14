using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;
using TechnoLogica.RegiX.AdapterConsole.Repositories.Contracts;

namespace TechnoLogica.RegiX.AdapterConsole.Repositories.Impl
{
    public class ReturnedCallsRepository : ABaseRepository<ReturnedCalls, int, RegiXAdapterConsoleContext>,
        IReturnedCallsRepository
    {
        private readonly IOperationToUserRepository _operationToUserRepository;

        public ReturnedCallsRepository(RegiXAdapterConsoleContext aDbContext, IUserContext userContext,
            IOperationToUserRepository operationToUserRepository)
            : base(aDbContext)
        {
            _operationToUserRepository = operationToUserRepository;
            this.userContext = userContext;
        }

        protected IUserContext userContext { get; }

        /// <summary>
        ///   The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{AuditValues}" /></returns>
        public override IQueryable<ReturnedCalls> SelectAll()
        {
            var operations = _operationToUserRepository.SelectAll();
            var result =
                GetDbContext().Set<ReturnedCalls>()
                    .Include(r => r.AdapterOperation)
                    .Include(r => r.ReturnedByNavigation)
                    .AsQueryable();
            result = userContext.FilterByRoles(result, operations); //Take the reports I have access to
            result = userContext.FilterByReturnedBy(result); //Take the reports assigned to current user.

            return result;
        }

        /// <summary>
        ///   The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="int" /></param>
        /// <returns>The <see cref="ReturnedCalls" /></returns>
        public override ReturnedCalls Select(int aId)
        {
            return SelectAll()
                .SingleOrDefault(r => r.Id == aId);
        }
    }
}