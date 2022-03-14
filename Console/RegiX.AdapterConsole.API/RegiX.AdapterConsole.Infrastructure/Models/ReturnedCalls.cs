using System;
using System.Collections.Generic;

namespace TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models
{
    public partial class ReturnedCalls
    {
        public int Id { get; set; }
        public int AdapterOperationId { get; set; }
        public int ApiServiceCallId { get; set; }
        public DateTime StartTime { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public int ReturnedBy { get; set; }

        public virtual AdapterOperations AdapterOperation { get; set; }
        public virtual AspNetUsers ReturnedByNavigation { get; set; }
    }
}
