using System;

namespace RegiX.Info.Infrastructure.Models
{
    public partial class CertificateOperationAccess
    {
        public decimal Id { get; set; }
        public decimal ConsumerCertificateId { get; set; }
        public decimal AdapterOperationId { get; set; }
        public bool HasAccess { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ConsumerCertificates ConsumerCertificate { get; set; }
        public virtual AdapterOperations AdapterOperation { get; set; }
    }
}
