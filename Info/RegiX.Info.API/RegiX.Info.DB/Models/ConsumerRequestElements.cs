using System;
using System.Collections.Generic;

namespace RegiX.Info.Infrastructure.Models
{
    public partial class ConsumerRequestElements
    {
        public decimal Id { get; set; }
        public decimal ConsumerAccessRequestId { get; set; }
        public decimal RegisterObjectElementId { get; set; }

        public virtual ConsumerAccessRequests ConsumerAccessRequest { get; set; }
        public virtual RegisterObjectElements RegisterObjectElement { get; set; }
    }
}
