using System;
using System.Collections.Generic;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class RegisterAdapters : BaseModel
    {
        public RegisterAdapters()
        {
            AdapterHealthFunctions = new HashSet<AdapterHealthFunctions>();
            AdapterHealthResults = new HashSet<AdapterHealthResults>();
            AdapterOperations = new HashSet<AdapterOperations>();
            AdapterPingResults = new HashSet<AdapterPingResults>();
            ParametersValuesLog = new HashSet<ParametersValuesLog>();
            RegisterObjects = new HashSet<RegisterObjects>();
        }

        public decimal RegisterAdapterId { get; set; }
        public decimal RegisterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AdapterUrl { get; set; }
        public string BindingConfigName { get; set; }
        public string Contract { get; set; }
        public string BindingType { get; set; }
        public string Assembly { get; set; }
        public string Behaviour { get; set; }
        public string Version { get; set; }

        public virtual Registers Register { get; set; }
        public virtual ICollection<AdapterHealthFunctions> AdapterHealthFunctions { get; set; }
        public virtual ICollection<AdapterHealthResults> AdapterHealthResults { get; set; }
        public virtual ICollection<AdapterOperations> AdapterOperations { get; set; }
        public virtual ICollection<AdapterPingResults> AdapterPingResults { get; set; }
        public virtual ICollection<ParametersValuesLog> ParametersValuesLog { get; set; }
        public virtual ICollection<RegisterObjects> RegisterObjects { get; set; }
    }
}