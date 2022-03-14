using System;
using System.Collections.Generic;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class RegisterObjectElements : BaseModel
    {
        public RegisterObjectElements()
        {
            CertificateElementAccess = new HashSet<CertificateElementAccess>();
            ConsumerRequestElements = new HashSet<ConsumerRequestElements>();
            ConsumerRoleElementAccess = new HashSet<ConsumerRoleElementAccess>();
            ApprovedRequestElements = new HashSet<ApprovedRequestElements>();
        }

        public decimal RegisterObjectElementId { get; set; }
        public decimal RegisterObjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PathToRoot { get; set; }

        public virtual RegisterObjects RegisterObject { get; set; }
        public virtual ICollection<CertificateElementAccess> CertificateElementAccess { get; set; }
        public virtual ICollection<ConsumerRequestElements> ConsumerRequestElements { get; set; }
        public virtual ICollection<ApprovedRequestElements> ApprovedRequestElements { get; set; }
        public virtual ICollection<ConsumerRoleElementAccess> ConsumerRoleElementAccess { get; set; }
    }
}