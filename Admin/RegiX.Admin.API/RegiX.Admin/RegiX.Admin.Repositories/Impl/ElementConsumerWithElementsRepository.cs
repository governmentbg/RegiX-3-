using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationService;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    public class ElementConsumerWithElementsRepository : ABaseRepository<GetElementConsumersElementsViewOutput, decimal, RegiXContext>,
        IElementConsumerWithElementsRepository
    {
        private IUserContext UserContext { get; set; }
        public ElementConsumerWithElementsRepository(RegiXContext aDbContext, IUserContext userContext)
            : base(aDbContext)
        {
            UserContext = userContext;
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{ConsumerCertificates}" /></returns>
        public override IQueryable<GetElementConsumersElementsViewOutput> SelectAll()
        {
            var result = GetDbContext()
                .Query<GetElementConsumersElementsViewOutput>()
                .AsNoTracking()
                .AsQueryable();
            return UserContext.FilterByAdministration(result, r => r.AdministrationId.Value);
        }
    }
}
