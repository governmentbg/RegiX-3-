using System.Collections.Generic;

namespace TechnoLogica.RegiX.Core.Data.Interfaces.Models
{
    public class AdapterInfo
    {
        public string Version { get; set; }
        public string Name { get; set; }
        public string Interface { get; set; }
        public IEnumerable<OperationInfo> Operations { get; set; }
        public string Description { get; set; }
    }
}