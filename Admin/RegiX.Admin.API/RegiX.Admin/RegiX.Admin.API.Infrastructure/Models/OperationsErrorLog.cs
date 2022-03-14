using System;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class OperationsErrorLog
    {
        public decimal OperationsErrorLogId { get; set; }
        public DateTime LogTime { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorContent { get; set; }
        public decimal? AdapterOperationId { get; set; }
        public decimal? ApiServiceOperationId { get; set; }
        public decimal? ApiServiceCallId { get; set; }

        public virtual AdapterOperations AdapterOperation { get; set; }
        public virtual ApiServiceCalls ApiServiceCall { get; set; }
        public virtual ApiServiceOperations ApiServiceOperation { get; set; }
    }
}