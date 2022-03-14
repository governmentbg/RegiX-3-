using System;
using System.Collections.Generic;

namespace RegiX.Info.Infrastructure.Models
{
    public partial class ConsumerCertificates
    {
        public ConsumerCertificates()
        {
            CertificateConsumerRole = new HashSet<CertificateConsumerRole>();
            CertificateElementAccess = new HashSet<CertificateElementAccess>();
            CertificateOperationAccess = new HashSet<CertificateOperationAccess>();
            ConsumerSystemCertificates = new HashSet<ConsumerSystemCertificates>();
        }

        public decimal ConsumerCertificateId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Thumbprint { get; set; }
        public byte[] Content { get; set; }
        public string IssuedFrom { get; set; }
        public string IssuedTo { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public decimal ApiServiceConsumerId { get; set; }
        public bool? Active { get; set; }
        public string Oid { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ApiServiceConsumers ApiServiceConsumer { get; set; }
        public virtual ICollection<CertificateConsumerRole> CertificateConsumerRole { get; set; }
        public virtual ICollection<CertificateElementAccess> CertificateElementAccess { get; set; }
        public virtual ICollection<CertificateOperationAccess> CertificateOperationAccess { get; set; }
        public virtual ICollection<ConsumerSystemCertificates> ConsumerSystemCertificates { get; set; }
    }
}
