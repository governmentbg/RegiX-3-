using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;
using TechnoLogica.RegiX.AdapterConsole.Repositories.Contracts;

namespace TechnoLogica.RegiX.AdapterConsole.Repositories.Impl
{
    public class MyOperationCallsRepository : ABaseRepository<OperationCalls, int, RegiXAdapterConsoleContext>,
        IMyOperationCallsRepository
    {
        private readonly IOperationToUserRepository _operationToUserRepository;

        public MyOperationCallsRepository(RegiXAdapterConsoleContext aDbContext, IUserContext userContext,
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
        /// <returns>The <see cref="IQueryable" /></returns>
        public override IQueryable<OperationCalls> SelectAll()
        {
            var operations = _operationToUserRepository.SelectAll();
            var result =
                GetDbContext().Set<OperationCalls>()
                    .Include(r => r.AdapterOperation)
                    .Include(r => r.AssignedToNavigation)
                    .AsQueryable();

            result = userContext.FilterByRoles(result, operations); //Take the reports I have access to
            result = userContext.FilterByAssignedTo(result); //Take the reports assigned to current user.

            return result;
        }

        /// <summary>
        ///   The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="int" /></param>
        /// <returns>The <see cref="OperationCalls" /></returns>
        public override OperationCalls Select(int aId)
        {
            return SelectAll()
                .SingleOrDefault(r => r.Id == aId);
        }
    }
}