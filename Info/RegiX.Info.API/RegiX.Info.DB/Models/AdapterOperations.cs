using System;
using System.Collections.Generic;
using System.Text;

namespace RegiX.Info.Infrastructure.Models
{
    public partial class AdapterOperations
    {
        public AdapterOperations()
        {
            CertificateOperationAccess = new HashSet<CertificateOperationAccess>();
            ConsumerAccessRequests = new HashSet<ConsumerAccessRequests>();
        }

        public decimal AdapterOperationId { get; set; }
        public decimal RegisterAdapterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? RegisterObjectId { get; set; }

        public virtual RegisterAdapters RegisterAdapter { get; set; }
        public virtual RegisterObjects RegisterObject { get; set; }
        public virtual ICollection<CertificateOperationAccess> CertificateOperationAccess { get; set; }
        public virtual ICollection<ConsumerAccessRequests> ConsumerAccessRequests { get; set; }
    }
}
