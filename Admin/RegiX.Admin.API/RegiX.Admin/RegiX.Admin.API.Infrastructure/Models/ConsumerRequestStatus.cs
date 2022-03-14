using System;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class ConsumerRequestStatus
    {
        public decimal Id { get; set; }
        public decimal ConsumerRequestId { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public int? OldStatus { get; set; }
        public int NewStatus { get; set; }

        public virtual ConsumerRequests ConsumerRequest { get; set; }
    }
}