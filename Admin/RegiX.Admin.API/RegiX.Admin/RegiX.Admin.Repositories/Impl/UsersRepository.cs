using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="UsersRepository" />
    /// </summary>
    public class UsersRepository : ABaseRepository<Users, decimal, RegiXContext>, IUsersRepository
    {
        protected IUserContext UserContext { get; private set; }
        /// <summary>
        ///     Initializes a new instance of the <see cref="UsersRepository" /> class.
        /// </summary>
        public UsersRepository(RegiXContext aDbContext, IUserContext userContext)
            : base(aDbContext)
        {
            UserContext = userContext;
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{Users}" /></returns>
        public override IQueryable<Users> SelectAll()
        {
            var result = GetDbContext()
                .Set<Users>().AsNoTracking()
                .Include(r => r.Administration)
                .AsQueryable();

            result = this.UserContext.FilterByAdministration(result);

            return result;
        }

        /// <summary>
        ///     The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <returns>The <see cref="Users" /></returns>
        public override Users Select(decimal aId)
        {
            return GetDbContext().Set<Users>().AsNoTracking()
                .Include(r => r.Administration)
                .SingleOrDefault(r => r.UserId == aId);
        }
    }
}