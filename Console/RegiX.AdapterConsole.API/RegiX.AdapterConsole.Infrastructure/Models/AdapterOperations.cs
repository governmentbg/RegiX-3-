using System;
using System.Collections.Generic;

namespace TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models
{
    public partial class AdapterOperations
    {
        public AdapterOperations()
        {
            OperationCalls = new HashSet<OperationCalls>();
            OperationsPersistance = new HashSet<OperationsPersistance>();
            OperationsToRoles = new HashSet<OperationsToRoles>();
            ReturnedCalls = new HashSet<ReturnedCalls>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Contract { get; set; }
        public string MetadataRequestXml { get; set; }
        public string MetadataResponseXml { get; set; }

        public virtual ICollection<OperationCalls> OperationCalls { get; set; }
        public virtual ICollection<OperationsPersistance> OperationsPersistance { get; set; }
        public virtual ICollection<OperationsToRoles> OperationsToRoles { get; set; }
        public virtual ICollection<ReturnedCalls> ReturnedCalls { get; set; }
    }
}
