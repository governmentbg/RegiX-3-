using System;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class CertificateAccessComments
    {
        public decimal Id { get; set; }
        public decimal ConsumerCertificateId { get; set; }
        public decimal AdapterOperationId { get; set; }
        public DateTime CreatedTime { get; set; }
        public string EditAccessComment { get; set; }
        public decimal UserId { get; set; }

        public virtual AdapterOperations AdapterOperation { get; set; }
        public virtual ConsumerCertificates ConsumerCertificate { get; set; }
        public virtual Users User { get; set; }
    }
}