using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    public class UsersEauthRepository : ABaseRepository<UsersEAuth, decimal, RegiXContext>, IUsersEauthRepository
    {
        public UsersEauthRepository(RegiXContext aDbContext) : base(aDbContext)
        {
        }

        public override UsersEAuth Select(decimal aId)
        {
            return GetDbContext().Set<UsersEAuth>().AsNoTracking()
                .SingleOrDefault(r => r.UserId == aId);
        }
    }
}
