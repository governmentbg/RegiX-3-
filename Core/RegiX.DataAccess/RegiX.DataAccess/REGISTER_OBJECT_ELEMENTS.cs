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
    
    public partial class REGISTER_OBJECT_ELEMENTS
    {
        public REGISTER_OBJECT_ELEMENTS()
        {
            this.CERTIFICATE_ELEMENT_ACCESS = new HashSet<CERTIFICATE_ELEMENT_ACCESS>();
            this.CONSUMER_ROLE_ELEMENT_ACCESS = new HashSet<CONSUMER_ROLE_ELEMENT_ACCESS>();
        }
    
        public decimal REGISTER_OBJECT_ELEMENT_ID { get; set; }
        public decimal REGISTER_OBJECT_ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string PATH_TO_ROOT { get; set; }
        public Nullable<System.DateTime> CREATED_ON { get; set; }
        public string CREATED_BY { get; set; }
        public Nullable<System.DateTime> UPDATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
    
        public virtual ICollection<CERTIFICATE_ELEMENT_ACCESS> CERTIFICATE_ELEMENT_ACCESS { get; set; }
        public virtual REGISTER_OBJECTS REGISTER_OBJECTS { get; set; }
        public virtual ICollection<CONSUMER_ROLE_ELEMENT_ACCESS> CONSUMER_ROLE_ELEMENT_ACCESS { get; set; }
    }
}