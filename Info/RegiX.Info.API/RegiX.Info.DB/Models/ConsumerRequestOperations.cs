using System;
using System.Collections.Generic;

namespace RegiX.Info.Infrastructure.Models
{
    public partial class ConsumerRequestOperations
    {
        public decimal Id { get; set; }
        public decimal ConsumerAccessRequestId { get; set; }
        public decimal AdapterOperationId { get; set; }
        public bool HasAccess { get; set; }

        public virtual ConsumerCertificates AdapterOperation { get; set; }
        public virtual ConsumerAccessRequests ConsumerAccessRequest { get; set; }
    }
}
