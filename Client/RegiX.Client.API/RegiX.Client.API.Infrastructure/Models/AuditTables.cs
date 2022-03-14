using System.Collections.Generic;

namespace TechnoLogica.RegiX.Client.Infrastructure.Models
{
    public partial class AuditTables : BaseModel
    {
        public AuditTables()
        {
            AuditValues = new HashSet<AuditValues>();
        }

        public int Id { get; set; }
        public string Action { get; set; }
        public string TableName { get; set; }
        public int AuthorityId { get; set; }
        public int? UserId { get; set; }
        public int TableId { get; set; }

        public virtual Authorities Authority { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<AuditValues> AuditValues { get; set; }
    }
}