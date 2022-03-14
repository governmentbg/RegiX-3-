using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="RegisterObjectsLogRepository" />
    /// </summary>
    public class RegisterObjectsLogRepository : ABaseRepository<RegisterObjectsLog, decimal, RegiXContext>,
        IRegisterObjectsLogRepository
    {
        public RegisterObjectsLogRepository(RegiXContext aDbContext) : base(aDbContext)
        {
        }
    }
}