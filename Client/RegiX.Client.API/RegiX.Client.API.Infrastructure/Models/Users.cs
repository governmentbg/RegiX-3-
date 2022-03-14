using System;
using System.Collections.Generic;

namespace TechnoLogica.RegiX.Client.Infrastructure.Models
{
    public partial class Users : BaseModel
    {
        public Users()
        {
            AuditExceptions = new HashSet<AuditExceptions>();
            AuditReportExecutions = new HashSet<AuditReportExecutions>();
            AuditTables = new HashSet<AuditTables>();
            AuditUserActions = new HashSet<AuditUserActions>();
            UsersToRoles = new HashSet<UsersToRoles>();
            UsersFavouriteReports = new HashSet<UsersFavouriteReports>();
            UsersToReports = new HashSet<UsersToReports>();
            AsyncReportExecutions = new HashSet<AsyncReportExecutions>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LockoutEndDate { get; set; }
        public int AccessFailedCount { get; set; }
        public int UserType { get; set; }

        public virtual FederationUsers FederationUsers { get; set; }
        public virtual PublicUsers PublicUsers { get; set; }
        public virtual ICollection<AuditExceptions> AuditExceptions { get; set; }
        public virtual ICollection<AuditReportExecutions> AuditReportExecutions { get; set; }
        public virtual ICollection<AuditTables> AuditTables { get; set; }
        public virtual ICollection<AuditUserActions> AuditUserActions { get; set; }
        public virtual ICollection<UsersToRoles> UsersToRoles { get; set; }
        public virtual ICollection<UsersFavouriteReports> UsersFavouriteReports { get; set; }
        public virtual ICollection<UsersToReports> UsersToReports { get; set; }
        public virtual ICollection<AsyncReportExecutions> AsyncReportExecutions { get; set; }
    }
}