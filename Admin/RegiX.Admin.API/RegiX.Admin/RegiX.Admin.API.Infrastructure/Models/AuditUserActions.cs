using System;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class AuditUserActions
    {
        public decimal AuditUserActionId { get; set; }
        public DateTime? UserActionTime { get; set; }
        public string UserActionText { get; set; }
        public string UserActionType { get; set; }
        public decimal? UserId { get; set; }
        public string UserName { get; set; }
        public string Controller { get; set; }
        public string ActionMethod { get; set; }
        public string ExecuteStatus { get; set; }
        public string Params { get; set; }
        public string Url { get; set; }
        public string ChangedTables { get; set; }
        public string IpAddress { get; set; }
    }
}