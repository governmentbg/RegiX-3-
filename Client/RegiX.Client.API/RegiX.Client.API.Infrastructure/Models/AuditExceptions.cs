using System;

namespace TechnoLogica.RegiX.Client.Infrastructure.Models
{
    public partial class AuditExceptions : BaseModel
    {
        public int Id { get; set; }
        public int AuthorityId { get; set; }
        public DateTime ExceptionTime { get; set; }
        public string ExceptionText { get; set; }
        public string Stacktrace { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string Controller { get; set; }
        public string ActionMethod { get; set; }

        public virtual Authorities Authority { get; set; }
        public virtual Users User { get; set; }
    }
}