using System;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class AdapterOperationLog
    {
        public decimal AdapterOperationLogId { get; set; }
        public decimal AdapterOperationId { get; set; }
        public decimal ApiServiceCallId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public virtual AdapterOperations AdapterOperation { get; set; }
    }
}