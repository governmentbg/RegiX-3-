using System;
using System.Collections.Generic;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class AuditTables
    {
        public AuditTables()
        {
            AuditValues = new HashSet<AuditValues>();
        }

        public decimal Id { get; set; }
        public decimal? UserId { get; set; }
        public string UserName { get; set; }
        public DateTime AuditDate { get; set; }
        public string Action { get; set; }
        public string TableName { get; set; }
        public decimal TableId { get; set; }
        public string IpAddress { get; set; }
        public string AppName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<AuditValues> AuditValues { get; set; }
    }
}