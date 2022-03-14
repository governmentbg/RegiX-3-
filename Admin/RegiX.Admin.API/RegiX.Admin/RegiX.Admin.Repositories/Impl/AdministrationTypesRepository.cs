using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="AdministrationTypesRepository" />
    /// </summary>
    public class AdministrationTypesRepository : ABaseRepository<AdministrationTypes, decimal, RegiXContext>,
        IAdministrationTypesRepository
    {
        protected IUserContext UserContext { get; private set; }
        public AdministrationTypesRepository(RegiXContext aDbContext, IUserContext userContext)
            : base(aDbContext)
        {
            UserContext = userContext;
        }
    }
}