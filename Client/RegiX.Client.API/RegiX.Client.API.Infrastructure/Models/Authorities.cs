using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace TechnoLogica.RegiX.Client.Infrastructure.Models
{
    public partial class Authorities : BaseModel
    {
        public Authorities()
        {
            AuditExceptions = new HashSet<AuditExceptions>();
            AuditReportExecutions = new HashSet<AuditReportExecutions>();
            AuditTables = new HashSet<AuditTables>();
            AuditUserActions = new HashSet<AuditUserActions>();
            FederationUsers = new HashSet<FederationUsers>();
            InverseParentAuthority = new HashSet<Authorities>();
            Registers = new HashSet<Registers>();
            Reports = new HashSet<Reports>();
            Roles = new HashSet<Roles>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int? ParentAuthorityId { get; set; }
        public string Acronym { get; set; }
        public string Code { get; set; }
        public string Oid { get; set; }
        public string CertificateThumbprint { get; set; }
        public StoreName? CertificateStore { get; set; }
        public bool IsMultitenantAuthority { get; set; }

        public virtual Authorities ParentAuthority { get; set; }
        public virtual ICollection<AuditExceptions> AuditExceptions { get; set; }
        public virtual ICollection<AuditReportExecutions> AuditReportExecutions { get; set; }
        public virtual ICollection<AuditTables> AuditTables { get; set; }
        public virtual ICollection<AuditUserActions> AuditUserActions { get; set; }
        public virtual ICollection<FederationUsers> FederationUsers { get; set; }
        public virtual ICollection<Authorities> InverseParentAuthority { get; set; }
        public virtual ICollection<Registers> Registers { get; set; }
        public virtual ICollection<Reports> Reports { get; set; }
        public virtual ICollection<Roles> Roles { get; set; }
    }
}