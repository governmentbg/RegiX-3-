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
    
    public partial class ADAPTER_OPERATIONS
    {
        public ADAPTER_OPERATIONS()
        {
            this.ADAPTER_OPERATION_LOG = new HashSet<ADAPTER_OPERATION_LOG>();
            this.OPERATIONS_ERROR_LOG = new HashSet<OPERATIONS_ERROR_LOG>();
            this.CERTIFICATE_OPERATION_ACCESS = new HashSet<CERTIFICATE_OPERATION_ACCESS>();
            this.API_SERVICE_ADAPTER_OPERATIONS = new HashSet<API_SERVICE_ADAPTER_OPERATIONS>();
            this.CERTIFICATE_ACCESS_COMMENTS = new HashSet<CERTIFICATE_ACCESS_COMMENTS>();
            this.CONSUMER_ROLE_OPERATION_ACCESS = new HashSet<CONSUMER_ROLE_OPERATION_ACCESS>();
        }
    
        public decimal ADAPTER_OPERATION_ID { get; set; }
        public decimal REGISTER_ADAPTER_ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public Nullable<decimal> REGISTER_OBJECT_ID { get; set; }
        public Nullable<System.DateTime> CREATED_ON { get; set; }
        public string CREATED_BY { get; set; }
        public Nullable<System.DateTime> UPDATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
    
        public virtual ICollection<ADAPTER_OPERATION_LOG> ADAPTER_OPERATION_LOG { get; set; }
        public virtual REGISTER_OBJECTS REGISTER_OBJECTS { get; set; }
        public virtual ICollection<OPERATIONS_ERROR_LOG> OPERATIONS_ERROR_LOG { get; set; }
        public virtual REGISTER_ADAPTERS REGISTER_ADAPTERS { get; set; }
        public virtual ICollection<CERTIFICATE_OPERATION_ACCESS> CERTIFICATE_OPERATION_ACCESS { get; set; }
        public virtual ICollection<API_SERVICE_ADAPTER_OPERATIONS> API_SERVICE_ADAPTER_OPERATIONS { get; set; }
        public virtual ICollection<CERTIFICATE_ACCESS_COMMENTS> CERTIFICATE_ACCESS_COMMENTS { get; set; }
        public virtual ICollection<CONSUMER_ROLE_OPERATION_ACCESS> CONSUMER_ROLE_OPERATION_ACCESS { get; set; }
    }
}
