using System;
using System.Collections.Generic;
using System.Text;

namespace TechnoLogica.RegiX.Processors.AsyncAdapterConsole.DB.Entities
{
    public partial class ReturnedCalls
    {
        public int Id { get; set; }
        public int ApiServiceCallId { get; set; }
        public DateTime StartTime { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }

        public virtual AdapterOperations AdapterOperation { get; set; }
        public int ReturnedBy { get; set; }
        public int AdapterOperationId { get; set; }
    }
}
