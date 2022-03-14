using System;
using System.Collections.Generic;

namespace RegiX.Info.Infrastructure.Models
{
    public partial class CertificateConsumerRole
    {
        public decimal Id { get; set; }
        public decimal ConsumerCertificateId { get; set; }
        public decimal ConsumerRoleId { get; set; }
        public DateTime CreatedTime { get; set; }
        public string EditAccessComment { get; set; }
        public decimal UserId { get; set; }

        public virtual ConsumerCertificates ConsumerCertificate { get; set; }
        public virtual ConsumerRoles ConsumerRole { get; set; }
    }
}
