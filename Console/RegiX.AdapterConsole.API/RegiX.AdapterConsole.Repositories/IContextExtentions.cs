using System.Linq;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Filters;

namespace TechnoLogica.RegiX.AdapterConsole.Repositories
{
    public static class IAssignedToContextExtentions
    {
        public static IQueryable<T> FilterByAssignedTo<T>(this IUserContext context, IQueryable<T> queryable)
            where T : IAssignedToFilter
        {
            return queryable.Where(t => t.AssignedTo == context.UserId);
        }

        public static IQueryable<T> FilterByAssignedTo<T>(this IUserContext context, IQueryable<T> queryable,
            int? selector)
            where T : IAssignedToFilter
        {
            if (context.MainRole == "Admin") return queryable;
            return queryable.Where(t => t.AssignedTo == selector);
        }
    }
}