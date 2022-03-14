using System.Linq;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Filters;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;

namespace TechnoLogica.RegiX.AdapterConsole.Repositories
{
    public static class IRolesContextExtentions
    {
        public static IQueryable<T> FilterByRoles<T>(this IUserContext context, IQueryable<T> queryable,
            IQueryable<OperationsToUsers> operationsToUsers)
            where T : IRoleFilter
        {
            if (context.MainRole != "Admin")
                return queryable.Where(t => operationsToUsers.Select(o => o.Id).Contains(t.AdapterOperationId));
            return queryable; // Only Admins can access all data.
        }
    }
}