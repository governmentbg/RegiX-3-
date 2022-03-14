using RegiX.Info.Infrastructure.Filters;
using System.Collections.Generic;

namespace RegiX.Info.Infrastructure.Models
{
    public partial class ConsumerRequests : IConsumerIDFilter
    {
        public ConsumerRequests()
        {
            ConsumerAccessRequests = new HashSet<ConsumerAccessRequests>();
            ConsumerRequestStatus = new HashSet<ConsumerRequestStatus>();
        }

        public decimal Id { get; set; }
        public decimal ConsumerProfileId { get; set; }
        public decimal? ConsumerSystemId { get; set; }
        public int Status { get; set; }
        public string DocumentNumber { get; set; }
        public string OutDocumentNumber { get; set; }
        public string Name { get; set; }

        public virtual ConsumerProfiles ConsumerProfile { get; set; }
        public virtual ConsumerSystems ConsumerSystem { get; set; }
        public virtual ICollection<ConsumerAccessRequests> ConsumerAccessRequests { get; set; }
        public virtual ICollection<ConsumerRequestStatus> ConsumerRequestStatus { get; set; }
    }
}
