using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    public class ConsumerProfilesRepository : ABaseRepository<ConsumerProfiles, decimal, RegiXContext>, IConsumerProfilesRepository
    {
        private readonly IUserContext userContext;

        public ConsumerProfilesRepository(RegiXContext aDbContext, IUserContext userContext)
            : base(aDbContext)
        {
            this.userContext = userContext;
        }

        public override IQueryable<ConsumerProfiles> SelectAll()
        {
            var result = GetDbContext().Set<ConsumerProfiles>()
                .Include(r => r.Administration)
                .Include(r => r.ConsumerProfileStatus)
                .AsQueryable();

            result = this.userContext.FilterByAdministration(result, r => (decimal)r.AdministrationId);

            return result;
        }

        public override ConsumerProfiles Select(decimal aId)
        {
            return this.SelectAll().SingleOrDefault(x => x.ConsumerProfileId == aId);
        }
    }
}