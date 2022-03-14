using System;
using System.Collections.Generic;
using System.Text;

namespace TechnoLogica.RegiX.Processors.AsyncAdapterConsole.DB.Entities
{
    public partial class OperationsPersistance
    {
        public int Id { get; set; }
        public int ApiServiceCallId { get; set; }
        public int? AdapterOperationId { get; set; }
        public string VerificationCode { get; set; }
        public string RawRequst { get; set; }
        public string RawUnsignedResult { get; set; }
        public string RawResult { get; set; }
        public string CallbackUrl { get; set; }
        public bool? Acknowledged { get; set; }
        public int? RetryCount { get; set; }
        public DateTime? NextRetry { get; set; }

        public virtual AdapterOperations AdapterOperation { get; set; }
    }
}
