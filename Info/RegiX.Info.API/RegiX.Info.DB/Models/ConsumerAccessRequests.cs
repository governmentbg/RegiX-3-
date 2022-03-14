using System.Collections.Generic;

namespace RegiX.Info.Infrastructure.Models
{
    public partial class ConsumerAccessRequests
    {
        public ConsumerAccessRequests()
        {
            ConsumerRequestElements = new HashSet<ConsumerRequestElements>();
            ConsumerAccessRequestsStatus = new HashSet<ConsumerAccessRequestsStatus>();
        }

        public decimal ConsumerAccessRequestId { get; set; }
        public decimal ConsumerSystemCertificateId { get; set; }
        public int Status { get; set; }
        public string LawReason { get; set; }
        public string RelatedServices { get; set; }
        public string RelatedServicesCode { get; set; }
        public decimal? ConsumerRequestId { get; set; }
        public decimal? AdapterOperationId { get; set; }

        public virtual AdapterOperations AdapterOperation { get; set; }
        public virtual ConsumerRequests ConsumerRequest { get; set; }
        public virtual ConsumerSystemCertificates ConsumerSystemCertificate { get; set; }
        public virtual ICollection<ConsumerRequestElements> ConsumerRequestElements { get; set; }
        public virtual ICollection<ConsumerAccessRequestsStatus> ConsumerAccessRequestsStatus { get; set; }
    }
}
