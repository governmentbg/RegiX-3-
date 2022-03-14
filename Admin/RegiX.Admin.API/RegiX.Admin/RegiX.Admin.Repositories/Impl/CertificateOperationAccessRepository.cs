using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="CertificateOperationAccessRepository" />
    /// </summary>
    public class CertificateOperationAccessRepository :
        ABaseRepository<CertificateOperationAccess, decimal, RegiXContext>,
        ICertificateOperationAccessRepository
    {
        public CertificateOperationAccessRepository(RegiXContext aDbContext) : base(aDbContext)
        {
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{CertificateOperationAccess}" /></returns>
        public override IQueryable<CertificateOperationAccess> SelectAll()
        {
            var result =  GetDbContext().Set<CertificateOperationAccess>()
                .Include(r => r.AdapterOperation)
                .Include(r => r.AdapterOperation.CertificateAccessComments)
                .Include(r => r.AdapterOperation.RegisterAdapter)
                .Include(r => r.ConsumerCertificate)
                .AsQueryable();

            return result;
        }

        /// <summary>
        ///     The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <returns>The <see cref="CertificateOperationAccess" /></returns>
        public override CertificateOperationAccess Select(decimal aId)
        {
            return this.SelectAll()
                .SingleOrDefault(r => r.Id == aId);
        }
    }
}