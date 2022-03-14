using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;

namespace TechnoLogica.RegiX.Client.Repositories.Impl
{
    public class AuthoritiesRepository : ABaseRepository<Authorities, int,RegiXClientContext>, IAuthoritiesRepository
    {
        protected readonly RegiXClientContext _dbContext;

        public AuthoritiesRepository(RegiXClientContext aDbContext)
            : base(aDbContext)
        {
            _dbContext = aDbContext;
        }

        public override IQueryable<Authorities> SelectAll()
        {
            return GetDbContext().Set<Authorities>().AsNoTracking()
                .Include(x => x.ParentAuthority)
                .AsQueryable();
        }

        public override Authorities Select(int aId)
        {
            return SelectAll()
                .SingleOrDefault(r => r.Id == aId);
        }

        public Authorities SelectByCode(string code)
        {
            return SelectAll()
                .FirstOrDefault(r => r.Code == code);
        }


        public int GenerateReportsAndRoleForAuth(int authorityId)
        {
            int affectedRows = _dbContext.Database.ExecuteSqlRaw($"SP_GENERATE_REPORTS_AND_ROLE_FOR_AUTH {authorityId}");
            _dbContext.SaveChanges();
            return affectedRows;
        }
    }
}