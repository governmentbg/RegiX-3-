using System.Linq;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;

namespace TechnoLogica.RegiX.AdapterConsole.Repositories.Impl
{
    public class AdapterOperationsRepository : ABaseRepository<AdapterOperations, int, RegiXAdapterConsoleContext>,
        IAdapterOperationsRepository
    {
        public AdapterOperationsRepository(RegiXAdapterConsoleContext aDbContext)
            : base(aDbContext)
        {
        }

        /// <summary>
        ///   The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{AuditValues}" /></returns>
        public override IQueryable<AdapterOperations> SelectAll()
        {
            return GetDbContext().Set<AdapterOperations>()
                .AsQueryable();
        }

        /// <summary>
        ///   The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="int" /></param>
        /// <returns>The <see cref="AdapterOperations" /></returns>
        public override AdapterOperations Select(int aId)
        {
            return SelectAll()
                .SingleOrDefault(r => r.Id == aId);
        }

        public IQueryable<AdapterOperations> SelectByUser(int aId)
        {
            var query =
                from roles in GetDbContext().AspNetRoles
                join usersToRoles in GetDbContext().AspNetUserRoles on roles.Id equals usersToRoles.RoleId
                join operationsToRoles in GetDbContext().OperationsToRoles on roles.Id equals operationsToRoles.RoleId
                join adapterOperations in GetDbContext().AdapterOperations on operationsToRoles.AdapterOperationId
                    equals adapterOperations.Id
                where usersToRoles.UserId == aId
                select adapterOperations;

            //var queryInner = from users in GetDbContext().Users
            //                       join usersToRoles in GetDbContext().UsersToRoles on users.Id equals usersToRoles.UserId
            //                       where usersToRoles.UserId == aId
            //                       select usersToRoles.RoleId;

            //      var mainQuery = from operationsToRoles in GetDbContext().OperationsToRoles
            //                      join adapterOperations in GetDbContext().AdapterOperations on operationsToRoles.AdapterOperationId
            //                          equals adapterOperations.Id
            //                      where queryInner.Contains(operationsToRoles.RoleId)
            //                      select adapterOperations;

            return query.Distinct();
        }
    }
}