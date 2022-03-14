using System;
using System.Collections.Generic;

namespace TechnoLogica.RegiX.Client.Infrastructure.Models
{
    public partial class AsyncReportExecutions
    {
        public AsyncReportExecutions()
        {
        }

        public int Id { get; set; }
        public decimal ApiServiceCallId { get; set; }
        public int AdapterOperationId { get; set; }
        public int? UserId { get; set; }
        public DateTime  SubmittedOn { get; set; }
        public DateTime? ReceivedOn { get; set; }
        public string Result { get; set; }
        public string VerificationCode { get; set; }

        public virtual Users User { get; set; }
        public virtual AdapterOperations AdapterOperation { get; set; }
    }
}