using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="AuditUserActionsRepository" />
    /// </summary>
    public class AuditUserActionsRepository : ABaseRepository<AuditUserActions, decimal, RegiXContext>,
        IAuditUserActionsRepository
    {
        public AuditUserActionsRepository(RegiXContext aDbContext)
            : base(aDbContext)
        {
        }
    }
}