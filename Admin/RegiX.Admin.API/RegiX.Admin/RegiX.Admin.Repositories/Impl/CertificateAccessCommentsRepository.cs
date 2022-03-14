using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="CertificateAccessCommentsRepository" />
    /// </summary>
    public class CertificateAccessCommentsRepository :
        ABaseRepository<CertificateAccessComments, decimal, RegiXContext>,
        ICertificateAccessCommentsRepository
    {
        protected IUserContext UserContext { get; private set; }
        public CertificateAccessCommentsRepository(RegiXContext aDbContext, IUserContext userContext)
            : base(aDbContext)
        {
            UserContext = userContext;
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{CertificateAccessComments}" /></returns>
        public override IQueryable<CertificateAccessComments> SelectAll()
        {
            var result = 
             GetDbContext().Set<CertificateAccessComments>()
                .Include(r => r.AdapterOperation)
                .Include(r => r.ConsumerCertificate)
                .Include(r => r.User)
                .AsQueryable();

            result = UserContext.FilterByAdministration(result,
                (r) => r.AdapterOperation.RegisterAdapter.Register.AdministrationId);

            return result;
        }

        /// <summary>
        ///     The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <returns>The <see cref="CertificateAccessComments" /></returns>
        public override CertificateAccessComments Select(decimal aId)
        {
            return this.SelectAll()
                .SingleOrDefault(r => r.ConsumerCertificateId == aId);
        }
    }
}