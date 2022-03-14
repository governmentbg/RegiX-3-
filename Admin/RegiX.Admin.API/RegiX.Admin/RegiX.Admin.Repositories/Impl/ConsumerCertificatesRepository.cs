using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="ConsumerCertificatesRepository" />
    /// </summary>
    public class ConsumerCertificatesRepository : ABaseRepository<ConsumerCertificates, decimal, RegiXContext>,
        IConsumerCertificatesRepository
    {
        public ConsumerCertificatesRepository(RegiXContext aDbContext)
            : base(aDbContext)
        {
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{ConsumerCertificates}" /></returns>
        public override IQueryable<ConsumerCertificates> SelectAll()
        {
            return GetDbContext().Set<ConsumerCertificates>()
                .Include(r => r.ApiServiceConsumer)
                .Include(r => r.CertificateOperationAccess)
                .AsQueryable();
        }

        /// <summary>
        ///     The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <returns>The <see cref="ConsumerCertificates" /></returns>
        public override ConsumerCertificates Select(decimal aId)
        {
            return GetDbContext().Set<ConsumerCertificates>()
                .Include(r => r.ApiServiceConsumer)
                .Include(r => r.CertificateOperationAccess)
                .SingleOrDefault(r => r.ConsumerCertificateId == aId);
        }

        public override ConsumerCertificates Delete(decimal aId)
        {
            var repoObj = GetDbContext().Set<ConsumerCertificates>()
                .Include(ur => ur.CertificateConsumerRole)
                .Where(u => u.ConsumerCertificateId == aId)
                .FirstOrDefault();
            if (repoObj == null)
            {
                throw new Exception("Object with id [" + aId + "] not found!");
            }
            GetDbContext().Remove(repoObj);
            return repoObj;
        }
    }
}