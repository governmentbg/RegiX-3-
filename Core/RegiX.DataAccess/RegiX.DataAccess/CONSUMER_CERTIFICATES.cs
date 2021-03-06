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
    
    public partial class CONSUMER_CERTIFICATES
    {
        public CONSUMER_CERTIFICATES()
        {
            this.CERTIFICATE_ELEMENT_ACCESS = new HashSet<CERTIFICATE_ELEMENT_ACCESS>();
            this.CERTIFICATE_OPERATION_ACCESS = new HashSet<CERTIFICATE_OPERATION_ACCESS>();
            this.CONSUMER_CERTIFICATE_EIDS = new HashSet<CONSUMER_CERTIFICATE_EIDS>();
            this.CONSUMER_CERTIFICATES_REPORTS = new HashSet<CONSUMER_CERTIFICATES_REPORTS>();
            this.API_SERVICE_CALLS = new HashSet<API_SERVICE_CALLS>();
            this.CERTIFICATE_ACCESS_COMMENTS = new HashSet<CERTIFICATE_ACCESS_COMMENTS>();
            this.CERTIFICATE_CONSUMER_ROLE = new HashSet<CERTIFICATE_CONSUMER_ROLE>();
        }
    
        public decimal CONSUMER_CERTIFICATE_ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string THUMBPRINT { get; set; }
        public byte[] CONTENT { get; set; }
        public string ISSUED_FROM { get; set; }
        public string ISSUED_TO { get; set; }
        public Nullable<System.DateTime> VALID_FROM { get; set; }
        public Nullable<System.DateTime> VALID_TO { get; set; }
        public decimal API_SERVICE_CONSUMER_ID { get; set; }
        public bool ACTIVE { get; set; }
        public string OID { get; set; }
        public Nullable<System.DateTime> CREATED_ON { get; set; }
        public string CREATED_BY { get; set; }
        public Nullable<System.DateTime> UPDATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
    
        public virtual API_SERVICE_CONSUMERS API_SERVICE_CONSUMERS { get; set; }
        public virtual ICollection<CERTIFICATE_ELEMENT_ACCESS> CERTIFICATE_ELEMENT_ACCESS { get; set; }
        public virtual ICollection<CERTIFICATE_OPERATION_ACCESS> CERTIFICATE_OPERATION_ACCESS { get; set; }
        public virtual ICollection<CONSUMER_CERTIFICATE_EIDS> CONSUMER_CERTIFICATE_EIDS { get; set; }
        public virtual ICollection<CONSUMER_CERTIFICATES_REPORTS> CONSUMER_CERTIFICATES_REPORTS { get; set; }
        public virtual ICollection<API_SERVICE_CALLS> API_SERVICE_CALLS { get; set; }
        public virtual ICollection<CERTIFICATE_ACCESS_COMMENTS> CERTIFICATE_ACCESS_COMMENTS { get; set; }
        public virtual ICollection<CERTIFICATE_CONSUMER_ROLE> CERTIFICATE_CONSUMER_ROLE { get; set; }
    }
}
