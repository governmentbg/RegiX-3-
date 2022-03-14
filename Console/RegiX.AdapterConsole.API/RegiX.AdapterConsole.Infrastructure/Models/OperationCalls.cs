using System;
using System.Collections.Generic;

namespace TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models
{
    public partial class OperationCalls
    {
        public int Id { get; set; }
        public int AdapterOperationId { get; set; }
        public int ApiServiceCallId { get; set; }
        public DateTime StartTime { get; set; }
        public string RequestXML { get; set; }
        public string ResponseXML { get; set; }
        public int? AssignedTo { get; set; }

        public virtual AdapterOperations AdapterOperation { get; set; }
        public virtual AspNetUsers AssignedToNavigation { get; set; }
    }
}
