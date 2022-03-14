//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TechnoLogica.RegiX.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class REGISTER_ADAPTERS
    {
        public REGISTER_ADAPTERS()
        {
            this.ADAPTER_HEALTH_FUNCTIONS = new HashSet<ADAPTER_HEALTH_FUNCTIONS>();
            this.ADAPTER_HEALTH_RESULTS = new HashSet<ADAPTER_HEALTH_RESULTS>();
            this.ADAPTER_OPERATIONS = new HashSet<ADAPTER_OPERATIONS>();
            this.ADAPTER_PING_RESULTS = new HashSet<ADAPTER_PING_RESULTS>();
            this.REGISTER_OBJECTS = new HashSet<REGISTER_OBJECTS>();
            this.PARAMETERS_VALUES_LOG = new HashSet<PARAMETERS_VALUES_LOG>();
        }
    
        public decimal REGISTER_ADAPTER_ID { get; set; }
        public decimal REGISTER_ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string ADAPTER_URL { get; set; }
        public string BINDING_CONFIG_NAME { get; set; }
        public string CONTRACT { get; set; }
        public string BINDING_TYPE { get; set; }
        public string ASSEMBLY { get; set; }
        public string BEHAVIOUR { get; set; }
        public Nullable<System.DateTime> CREATED_ON { get; set; }
        public string CREATED_BY { get; set; }
        public Nullable<System.DateTime> UPDATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public string VERSION { get; set; }
    
        public virtual ICollection<ADAPTER_HEALTH_FUNCTIONS> ADAPTER_HEALTH_FUNCTIONS { get; set; }
        public virtual ICollection<ADAPTER_HEALTH_RESULTS> ADAPTER_HEALTH_RESULTS { get; set; }
        public virtual ICollection<ADAPTER_OPERATIONS> ADAPTER_OPERATIONS { get; set; }
        public virtual ICollection<ADAPTER_PING_RESULTS> ADAPTER_PING_RESULTS { get; set; }
        public virtual ICollection<REGISTER_OBJECTS> REGISTER_OBJECTS { get; set; }
        public virtual REGISTERS REGISTERS { get; set; }
        public virtual ICollection<PARAMETERS_VALUES_LOG> PARAMETERS_VALUES_LOG { get; set; }
    }
}
