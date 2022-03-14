using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="HealthServiceOfflineRepository" />
    /// </summary>
    public class HealthServiceOfflineRepository : ABaseRepository<HealthServiceOffline, decimal, RegiXContext>,
        IHealthServiceOfflineRepository
    {
        public HealthServiceOfflineRepository(RegiXContext aDbContext)
            : base(aDbContext)
        {
        }
    }
}