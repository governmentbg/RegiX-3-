using System;
using System.Collections.Generic;

namespace RegiX.Info.Infrastructure.Models
{
    public partial class RegisterObjectElements
    {
        public RegisterObjectElements()
        {
            CertificateElementAccess = new HashSet<CertificateElementAccess>();
            ConsumerRequestElements = new HashSet<ConsumerRequestElements>();
        }

        public decimal RegisterObjectElementId { get; set; }
        public decimal RegisterObjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PathToRoot { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public virtual RegisterObjects RegisterObject { get; set; }
        public virtual ICollection<CertificateElementAccess> CertificateElementAccess { get; set; }
        public virtual ICollection<ConsumerRequestElements> ConsumerRequestElements { get; set; }
    }
}
