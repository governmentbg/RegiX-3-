using System;
using System.Collections.Generic;

namespace RegiX.Info.Infrastructure.Models
{
    public partial class ConsumerSystemCertificates 
    {
        public ConsumerSystemCertificates()
        {
            ConsumerAccessRequests = new HashSet<ConsumerAccessRequests>();
        }

        public decimal ConsumerSystemCertificateId { get; set; }
        public decimal ConsumerSystemId { get; set; }
        public decimal? ConsumerCertificateId { get; set; }
        public byte[] Csr { get; set; }
        public byte[] Content { get; set; }
        public DateTime RequestDate { get; set; }
        public string Environment { get; set; }
        public string Name { get; set; }

        public virtual ConsumerCertificates ConsumerCertificate { get; set; }
        public virtual ConsumerSystems ConsumerSystem { get; set; }
        public virtual ICollection<ConsumerAccessRequests> ConsumerAccessRequests { get; set; }
    }
}
