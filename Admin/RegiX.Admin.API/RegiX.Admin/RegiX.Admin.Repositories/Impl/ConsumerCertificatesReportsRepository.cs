using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl
{
    /// <summary>
    ///     Defines the <see cref="ConsumerCertificatesReportsRepository" />
    /// </summary>
    public class ConsumerCertificatesReportsRepository :
        ABaseRepository<ConsumerCertificatesReports, decimal, RegiXContext>,
        IConsumerCertificatesReportsRepository
    {
        public ConsumerCertificatesReportsRepository(RegiXContext aDbContext)
            : base(aDbContext)
        {
        }

        /// <summary>
        ///     The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{ConsumerCertificatesReports}" /></returns>
        public override IQueryable<ConsumerCertificatesReports> SelectAll()
        {
            return GetDbContext().Set<ConsumerCertificatesReports>()
                .Include(r => r.ConsumerCertificate)
                .Include(r => r.Report)
                .AsQueryable();
        }

        /// <summary>
        ///     The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <returns>The <see cref="ConsumerCertificatesReports" /></returns>
        public override ConsumerCertificatesReports Select(decimal aId)
        {
            return GetDbContext().Set<ConsumerCertificatesReports>()
                .Include(r => r.ConsumerCertificate)
                .Include(r => r.Report)
                .SingleOrDefault(r => r.ConsumerCertificateReportId == aId);
        }
    }
}