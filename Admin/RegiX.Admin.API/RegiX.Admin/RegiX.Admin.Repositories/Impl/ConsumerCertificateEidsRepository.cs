using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="ConsumerCertificateEidsRepository" />
    /// </summary>
    public class ConsumerCertificateEidsRepository : ABaseRepository<ConsumerCertificateEids, decimal, RegiXContext>,
        IConsumerCertificateEidsRepository
    {
        public ConsumerCertificateEidsRepository(RegiXContext aDbContext)
            : base(aDbContext)
        {
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{ConsumerCertificateEids}" /></returns>
        public override IQueryable<ConsumerCertificateEids> SelectAll()
        {
            return GetDbContext().Set<ConsumerCertificateEids>()
                .Include(r => r.ConsumerCertificate)
                .AsQueryable();
        }

        /// <summary>
        ///     The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <returns>The <see cref="ConsumerCertificateEids" /></returns>
        public override ConsumerCertificateEids Select(decimal aId)
        {
            return GetDbContext().Set<ConsumerCertificateEids>()
                .Include(r => r.ConsumerCertificate)
                .SingleOrDefault(r => r.ConsumerCertificateEidId == aId);
        }
    }
}