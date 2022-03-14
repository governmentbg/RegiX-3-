using System.Collections.Generic;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class ConsumerRoles : BaseModel
    {
        public ConsumerRoles()
        {
            CertificateConsumerRole = new HashSet<CertificateConsumerRole>();
            ConsumerRoleElementAccess = new HashSet<ConsumerRoleElementAccess>();
            ConsumerRoleOperationAccess = new HashSet<ConsumerRoleOperationAccess>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<CertificateConsumerRole> CertificateConsumerRole { get; set; }
        public virtual ICollection<ConsumerRoleElementAccess> ConsumerRoleElementAccess { get; set; }
        public virtual ICollection<ConsumerRoleOperationAccess> ConsumerRoleOperationAccess { get; set; }
    }
}
