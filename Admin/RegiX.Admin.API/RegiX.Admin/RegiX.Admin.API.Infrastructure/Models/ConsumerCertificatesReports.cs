namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class ConsumerCertificatesReports
    {
        public decimal ConsumerCertificateReportId { get; set; }
        public decimal? ConsumerCertificateId { get; set; }
        public decimal? ReportId { get; set; }

        public virtual ConsumerCertificates ConsumerCertificate { get; set; }
        public virtual Reports Report { get; set; }
    }
}