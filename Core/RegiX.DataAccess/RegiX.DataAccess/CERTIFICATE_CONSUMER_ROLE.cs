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
    
    public partial class CERTIFICATE_CONSUMER_ROLE
    {
        public decimal ID { get; set; }
        public decimal CONSUMER_CERTIFICATE_ID { get; set; }
        public decimal CONSUMER_ROLE_ID { get; set; }
        public System.DateTime CREATED_TIME { get; set; }
        public string EDIT_ACCESS_COMMENT { get; set; }
        public decimal USER_ID { get; set; }
    
        public virtual CONSUMER_CERTIFICATES CONSUMER_CERTIFICATES { get; set; }
        public virtual CONSUMER_ROLES CONSUMER_ROLES { get; set; }
        public virtual USERS USER { get; set; }
    }
}