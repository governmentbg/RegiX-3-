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
    
    public partial class CONSUMER_ROLES
    {
        public CONSUMER_ROLES()
        {
            this.CERTIFICATE_CONSUMER_ROLE = new HashSet<CERTIFICATE_CONSUMER_ROLE>();
            this.CONSUMER_ROLE_ELEMENT_ACCESS = new HashSet<CONSUMER_ROLE_ELEMENT_ACCESS>();
            this.CONSUMER_ROLE_OPERATION_ACCESS = new HashSet<CONSUMER_ROLE_OPERATION_ACCESS>();
        }
    
        public decimal CONSUMER_ROLE_ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public Nullable<System.DateTime> CREATED_ON { get; set; }
        public string CREATED_BY { get; set; }
        public Nullable<System.DateTime> UPDATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
    
        public virtual ICollection<CERTIFICATE_CONSUMER_ROLE> CERTIFICATE_CONSUMER_ROLE { get; set; }
        public virtual ICollection<CONSUMER_ROLE_ELEMENT_ACCESS> CONSUMER_ROLE_ELEMENT_ACCESS { get; set; }
        public virtual ICollection<CONSUMER_ROLE_OPERATION_ACCESS> CONSUMER_ROLE_OPERATION_ACCESS { get; set; }
    }
}