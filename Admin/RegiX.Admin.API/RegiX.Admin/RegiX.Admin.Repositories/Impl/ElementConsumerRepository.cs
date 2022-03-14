using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationService;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    public class ElementConsumerRepository : ABaseRepository<GetElementConsumersViewOutput, decimal, RegiXContext>,
        IElementConsumerRepository
    {
        private IUserContext UserContext { get; set; }
        public ElementConsumerRepository(RegiXContext aDbContext, IUserContext userContext) 
            : base(aDbContext)
        {
            UserContext = userContext;
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{ConsumerCertificates}" /></returns>
        public override IQueryable<GetElementConsumersViewOutput> SelectAll()
        {
            var result = GetDbContext()
                .Query<GetElementConsumersViewOutput>()
                .AsNoTracking()
                .AsQueryable();
            return UserContext.FilterByAdministration(result, r => r.AdministrationId.Value);
        }
    }
}
