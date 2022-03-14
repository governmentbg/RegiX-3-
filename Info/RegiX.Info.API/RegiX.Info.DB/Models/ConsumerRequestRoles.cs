using System;
using System.Collections.Generic;

namespace RegiX.Info.Infrastructure.Models
{
    public partial class ConsumerRequestRoles
    {
        public decimal Id { get; set; }
        public decimal ConsumerAccessRequestId { get; set; }
        public decimal ConsumerRoleId { get; set; }

        public virtual ConsumerAccessRequests ConsumerAccessRequest { get; set; }
    }
}
