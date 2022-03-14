using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="AuditExceptionsRepository" />
    /// </summary>
    public class AuditExceptionsRepository : ABaseRepository<AuditExceptions, decimal, RegiXContext>,
        IAuditExceptionsRepository
    {
        public AuditExceptionsRepository(RegiXContext aDbContext)
            : base(aDbContext)
        {
        }
    }
}