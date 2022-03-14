using System;
using System.Collections.Generic;

namespace RegiX.Info.Infrastructure.Models
{
    public partial class ConsumerRoles
    {
        public ConsumerRoles()
        {
            CertificateConsumerRole = new HashSet<CertificateConsumerRole>();
        }

        public decimal ConsumerRoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<CertificateConsumerRole> CertificateConsumerRole { get; set; }
    }
}
