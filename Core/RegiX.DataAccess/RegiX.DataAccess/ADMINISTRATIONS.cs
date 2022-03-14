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
    
    public partial class ADMINISTRATIONS
    {
        public ADMINISTRATIONS()
        {
            this.REGISTERS = new HashSet<REGISTERS>();
            this.API_SERVICES = new HashSet<API_SERVICES>();
            this.USERS = new HashSet<USERS>();
            this.ADMINISTRATIONS1 = new HashSet<ADMINISTRATIONS>();
            this.API_SERVICE_CONSUMERS = new HashSet<API_SERVICE_CONSUMERS>();
        }
    
        public decimal ADMINISTRATION_ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public Nullable<decimal> PARENT_AUTHORITY_ID { get; set; }
        public string PATH_TO_ROOT { get; set; }
        public Nullable<int> DEPTH { get; set; }
        public string ACRONYM { get; set; }
        public string CODE { get; set; }
        public string PATH_TO_ROOT_NAMES { get; set; }
        public Nullable<System.DateTime> CREATED_ON { get; set; }
        public string CREATED_BY { get; set; }
        public Nullable<System.DateTime> UPDATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public Nullable<bool> PUBLICLY_VISIBLE { get; set; }
        public Nullable<decimal> ADMINISTRATION_TYPE_ID { get; set; }
        public string OID { get; set; }
    
        public virtual ICollection<REGISTERS> REGISTERS { get; set; }
        public virtual ICollection<API_SERVICES> API_SERVICES { get; set; }
        public virtual ICollection<USERS> USERS { get; set; }
        public virtual ICollection<ADMINISTRATIONS> ADMINISTRATIONS1 { get; set; }
        public virtual ADMINISTRATIONS ADMINISTRATION1 { get; set; }
        public virtual ICollection<API_SERVICE_CONSUMERS> API_SERVICE_CONSUMERS { get; set; }
        public virtual ADMINISTRATION_TYPES ADMINISTRATION_TYPES { get; set; }
    }
}