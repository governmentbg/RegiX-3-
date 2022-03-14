using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="CertificateElementAccessRepository" />
    /// </summary>
    public class CertificateElementAccessRepository : ABaseRepository<CertificateElementAccess, decimal, RegiXContext>,
        ICertificateElementAccessRepository
    {
        public CertificateElementAccessRepository(RegiXContext aDbContext)
            : base(aDbContext)
        {
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{CertificateElementAccess}" /></returns>
        public override IQueryable<CertificateElementAccess> SelectAll()
        {
            return GetDbContext().Set<CertificateElementAccess>()
                .Include(r => r.ConsumerCertificate)
                .Include(r => r.RegisterObjectElement)
                .AsQueryable();
        }

        /// <summary>
        ///     The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <returns>The <see cref="CertificateElementAccess" /></returns>
        public override CertificateElementAccess Select(decimal aId)
        {
            return GetDbContext().Set<CertificateElementAccess>()
                .Include(r => r.ConsumerCertificate)
                .Include(r => r.RegisterObjectElement)
                .SingleOrDefault(r => r.Id == aId);
        }


        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{CertificateElementAccess}" /></returns>
        public  IQueryable<CertificateElementAccess> SelectAllByCertificateId(decimal certificateId)
        {
            return GetDbContext().Set<CertificateElementAccess>()
                .Include(r => r.ConsumerCertificate)
                .Include(r => r.RegisterObjectElement)
                .Where(x => x.ConsumerCertificateId == certificateId)
                .AsQueryable();
        }

    }
}