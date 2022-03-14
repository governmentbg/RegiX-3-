using System;
using System.Collections.Generic;
using System.Text;

namespace TechnoLogica.RegiX.Processors.AsyncAdapterConsole.DB.Entities
{
    public partial class AdapterOperations
    {
        public AdapterOperations()
        {
            OperationCalls = new HashSet<OperationCalls>();
            ReturnedCalls = new HashSet<ReturnedCalls>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Contract { get; set; }
        public string MetadataRequestXml { get; set; }
        public string MetadataResponseXml { get; set; }

        public virtual ICollection<OperationCalls> OperationCalls { get; set; }
        public virtual ICollection<ReturnedCalls> ReturnedCalls { get; set; }        
        public virtual ICollection<OperationsPersistance> OperationsPersistances { get; set; }
    }
}
