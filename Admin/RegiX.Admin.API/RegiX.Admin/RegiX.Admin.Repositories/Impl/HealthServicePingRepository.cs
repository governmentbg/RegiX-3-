using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="HealthServicePingRepository" />
    /// </summary>
    public class HealthServicePingRepository : ABaseRepository<HealthServicePing, decimal, RegiXContext>,
        IHealthServicePingRepository
    {
        public HealthServicePingRepository(RegiXContext aDbContext)
            : base(aDbContext)
        {
        }
    }
}