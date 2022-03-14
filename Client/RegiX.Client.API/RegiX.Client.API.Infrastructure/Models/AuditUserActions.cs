using System;

namespace TechnoLogica.RegiX.Client.Infrastructure.Models
{
    public partial class AuditUserActions : BaseModel
    {
        public int Id { get; set; }

        public int AuthorityId { get; set; }
        public DateTime UserActionTime { get; set; }
        public string UserActionText { get; set; }
        public string UserActionType { get; set; }
        public string UserName { get; set; }
        public int? UserId { get; set; }
        public string Controller { get; set; }
        public string ActionMethod { get; set; }
        public string ExecuteStatus { get; set; }
        public string Params { get; set; }
        public string Url { get; set; }
        public string ChangedTables { get; set; }


        public virtual Authorities Authority { get; set; }

        public virtual Users User { get; set; }
    }
}