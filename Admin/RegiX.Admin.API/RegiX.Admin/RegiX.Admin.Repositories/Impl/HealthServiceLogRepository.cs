using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="HealthServiceLogRepository" />
    /// </summary>
    public class HealthServiceLogRepository : ABaseRepository<HealthServiceLog, decimal, RegiXContext>,
        IHealthServiceLogRepository
    {
        public HealthServiceLogRepository(RegiXContext aDbContext)
            : base(aDbContext)
        {
        }
    }
}