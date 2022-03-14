using RegiX.Info.Infrastructure.Filters;
using System.Collections.Generic;

namespace RegiX.Info.Infrastructure.Models
{
    public partial class ConsumerSystems : IConsumerIDFilter
    {
        public ConsumerSystems()
        {
            ConsumerSystemCertificates = new HashSet<ConsumerSystemCertificates>();
            ConsumerRequests = new HashSet<ConsumerRequests>();
        }

        public decimal ConsumerSystemId { get; set; }
        public decimal ConsumerProfileId { get; set; }
        public string Name { get; set; }
        public string StaticIP { get; set; }
        public string Description { get; set; }
        public decimal? ApiServiceConsumerId { get; set; }

        public virtual ApiServiceConsumers ApiServiceConsumer { get; set; }
        public virtual ConsumerProfiles ConsumerProfile { get; set; }
        public virtual ICollection<ConsumerSystemCertificates> ConsumerSystemCertificates { get; set; }
        public virtual ICollection<ConsumerRequests> ConsumerRequests { get; set; }
    }
}
