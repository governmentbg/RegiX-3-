using System;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class ApiServiceOperationLog
    {
        public decimal ApiServiceOperationLogId { get; set; }
        public decimal ServiceCallId { get; set; }
        public decimal ApiServiceOperationId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public virtual ApiServiceOperations ApiServiceOperation { get; set; }
    }
}