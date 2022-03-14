using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    public class MyProfileRepository : ABaseRepository<Users, decimal, RegiXContext>, IMyProfileRepository
    {
        private IUserContext UserContext { get; set; }

        public MyProfileRepository(RegiXContext aDbContext, IUserContext userContext) : base(aDbContext)
        {
            UserContext = userContext;
        }

        public override IQueryable<Users> SelectAll()
        {
            var result =
                GetDbContext().Set<Users>().AsNoTracking()
                    .Include(r => r.UserEAuth)
                    .AsQueryable();
            return result;
        }

        public override Users Select(decimal aId)
        {
            return SelectAll()
                .SingleOrDefault(r => r.UserId == aId);
        }
    }
}
