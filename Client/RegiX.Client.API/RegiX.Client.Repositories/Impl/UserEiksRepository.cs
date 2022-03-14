using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;

namespace TechnoLogica.RegiX.Client.Repositories.Impl
{
    public class UserEiksRepository : ABaseRepository<UserEiks, int,RegiXClientContext>, IUserEiksRepository
    {
        public override IQueryable<UserEiks> SelectAll()
        {
            return GetDbContext().Set<UserEiks>()
                .Include(ue => ue.User)
                .AsQueryable();
        }

        public override UserEiks Select(int aId)
        {
            return GetDbContext().Set<UserEiks>()
                .Include(ue => ue.User)
                .SingleOrDefault(ue => ue.Id == aId);
        }

        public UserEiksRepository(RegiXClientContext aDbContext) : base(aDbContext)
        {
        }
    }
}