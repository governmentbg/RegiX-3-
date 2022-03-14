using System.Linq;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Filters;

namespace TechnoLogica.RegiX.AdapterConsole.Repositories
{
    public static class IReturnedByContextExtentions
    {
        public static IQueryable<T> FilterByReturnedBy<T>(this IUserContext context, IQueryable<T> queryable)
            where T : IReturnedByFilter
        {
            if (context.MainRole == "Admin") return queryable;
            return queryable.Where(t => t.ReturnedBy == context.UserId);
        }
    }
}