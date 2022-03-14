using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class ConsumerCertificates : BaseModel
    {
        public ConsumerCertificates()
        {
            ApiServiceCalls = new HashSet<ApiServiceCalls>();
            CertificateAccessComments = new HashSet<CertificateAccessComments>();
            CertificateConsumerRole = new HashSet<CertificateConsumerRole>();
            CertificateElementAccess = new HashSet<CertificateElementAccess>();
            CertificateOperationAccess = new HashSet<CertificateOperationAccess>();
            ConsumerCertificateEids = new HashSet<ConsumerCertificateEids>();
            ConsumerCertificatesReports = new HashSet<ConsumerCertificatesReports>();
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

        public virtual ApiServiceConsumers ApiServiceConsumer { get; set; }
        public virtual ICollection<ApiServiceCalls> ApiServiceCalls { get; set; }
        public virtual ICollection<CertificateAccessComments> CertificateAccessComments { get; set; }
        public virtual ICollection<CertificateConsumerRole> CertificateConsumerRole { get; set; }
        public virtual ICollection<CertificateElementAccess> CertificateElementAccess { get; set; }
        public virtual ICollection<CertificateOperationAccess> CertificateOperationAccess { get; set; }
        public virtual ICollection<ConsumerCertificateEids> ConsumerCertificateEids { get; set; }
        public virtual ICollection<ConsumerCertificatesReports> ConsumerCertificatesReports { get; set; }
        public virtual ICollection<ConsumerSystemCertificates> ConsumerSystemCertificates { get; set; }
    }
}