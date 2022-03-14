using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.DaeuReportsAdapter.AdapterService
{
    public class APIServiceCall
    {
        public decimal ApiServiceCallId { get; set; }
        public DateTime StartTime { get; set; }
        public string Identifier { get; set; }
        public string IdentifierType { get; set; }
        public bool Hidden { get; set; }
        public string ConsumerAdministration { get; set; }
        public string Consumer { get; set; }
        public string ProducerAdministration { get; set; }
        public string Producer { get; set; }
        public string ContextLawReason { get; set; }
        public string ReportName { get; set; }
    }
}
