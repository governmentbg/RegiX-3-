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
    
    public partial class ADAPTER_HEALTH_RESULTS
    {
        public decimal ADAPTER_HEALTH_RESULT_ID { get; set; }
        public decimal REGISTER_ADAPTER_ID { get; set; }
        public decimal ADAPTER_HEALTH_FUNCTION_ID { get; set; }
        public System.DateTime EXECUTE_TIME { get; set; }
        public string HEALTH_RESULT { get; set; }
        public string HEALTH_ERROR { get; set; }
        public string CREATED_BY { get; set; }
        public string IP_ADDRESS { get; set; }
        public string APP_NAME { get; set; }
    
        public virtual ADAPTER_HEALTH_FUNCTIONS ADAPTER_HEALTH_FUNCTIONS { get; set; }
        public virtual REGISTER_ADAPTERS REGISTER_ADAPTERS { get; set; }
    }
}