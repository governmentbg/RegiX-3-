using System.Collections.Generic;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class Reports
    {
        public Reports()
        {
            ConsumerCertificatesReports = new HashSet<ConsumerCertificatesReports>();
            CustomParameters = new HashSet<CustomParameters>();
        }

        public decimal ReportId { get; set; }
        public decimal? ApiServiceConsumerId { get; set; }
        public decimal? ApiServiceOperationId { get; set; }
        public string Name { get; set; }
        public string LawReason { get; set; }
        public string Claim { get; set; }
        public string Xslt { get; set; }
        public int? OrderNumber { get; set; }

        public virtual ApiServiceConsumers ApiServiceConsumer { get; set; }
        public virtual ApiServiceOperations ApiServiceOperation { get; set; }
        public virtual ICollection<ConsumerCertificatesReports> ConsumerCertificatesReports { get; set; }
        public virtual ICollection<CustomParameters> CustomParameters { get; set; }
    }
}