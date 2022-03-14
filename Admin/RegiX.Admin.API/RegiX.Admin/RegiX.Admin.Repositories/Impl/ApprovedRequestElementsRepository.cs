using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    public class ApprovedRequestElementsRepository : ABaseRepository<ApprovedRequestElements, decimal, RegiXContext>, IApprovedRequestElementsRepository
    {
        public ApprovedRequestElementsRepository(RegiXContext aDbContext)
            : base(aDbContext)
        {
        }

        public override IQueryable<ApprovedRequestElements> SelectAll()
        {
            var result = GetDbContext().Set<ApprovedRequestElements>()
                .Include(r => r.RegisterObjectElement)
                .AsQueryable();

            return result;
        }

        public override ApprovedRequestElements Select(decimal aId)
        {
            return this.SelectAll().SingleOrDefault(x => x.Id == aId);
        }
    }
}