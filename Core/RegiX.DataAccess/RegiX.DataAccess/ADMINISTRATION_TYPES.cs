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
    
    public partial class ADMINISTRATION_TYPES
    {
        public ADMINISTRATION_TYPES()
        {
            this.ADMINISTRATIONS = new HashSet<ADMINISTRATIONS>();
        }
    
        public decimal ADMINISTRATION_TYPE_ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public Nullable<bool> PUBLICLY_VISIBLE { get; set; }
    
        public virtual ICollection<ADMINISTRATIONS> ADMINISTRATIONS { get; set; }
    }
}
