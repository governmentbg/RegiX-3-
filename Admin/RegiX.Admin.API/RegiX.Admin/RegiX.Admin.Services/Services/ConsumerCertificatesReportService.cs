using System;
using System.Collections.Generic;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerCertificatesReport;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    /// <summary>
    ///     Defines the <see cref="ConsumerCertificatesReportService" />
    /// </summary>
    public class ConsumerCertificatesReportService :
        ABaseService<ConsumerCertificatesReportInDto, ConsumerCertificatesReportOutDto, ConsumerCertificatesReports,
            decimal, RegiXContext>, IConsumerCertificatesReportService
    {
        public ConsumerCertificatesReportService(
            IConsumerCertificatesReportsRepository aBaseRepository) : base(aBaseRepository)
        {
        }

        /// <summary>
        ///     The PopulateDtoToEntityFieldsMapping
        /// </summary>
        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("consumerCertificate.id", "ConsumerCertificate/ConsumerCertificateId");
            dtoFieldsToEntityFields.Add("consumerCertificate.displayName", "ConsumerCertificate/Name");
            dtoFieldsToEntityFields.Add("report.id", "Report/ReportId");
            dtoFieldsToEntityFields.Add("report.displayName", "Report/Name");
            dtoFieldsToEntityFields.Add("id", "ConsumerCertificateReportId");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            throw new NotImplementedException();
        }
    }
}