using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="AuditTablesRepository" />
    /// </summary>
    public class AuditTablesRepository : ABaseRepository<AuditTables, decimal, RegiXContext>, IAuditTablesRepository
    {
        public AuditTablesRepository(RegiXContext aDbContext)
            : base(aDbContext)
        {
        }
    }
}