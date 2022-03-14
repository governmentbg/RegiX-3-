using System;
using System.Collections.Generic;
using System.Text;

namespace RegiX.Info.Infrastructure.Models
{
    public partial class ConsumerAccessRequestsStatus
    {
        public decimal Id { get; set; }
        public decimal ConsumerAccessRequestId { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public int? OldStatus { get; set; }
        public int NewStatus { get; set; }

        public virtual ConsumerAccessRequests ConsumerAccessRequest { get; set; }
    }
}
