using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="ParameterTypesRepository" />
    /// </summary>
    public class ParameterTypesRepository : ABaseRepository<ParameterTypes, decimal, RegiXContext>,
        IParameterTypesRepository
    {
        public ParameterTypesRepository(RegiXContext aDbContext)
            : base(aDbContext)
        {
        }
    }
}