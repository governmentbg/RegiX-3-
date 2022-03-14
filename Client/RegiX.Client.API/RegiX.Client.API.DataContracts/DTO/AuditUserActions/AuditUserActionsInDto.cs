using System;

namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditUserActions
{
    public class AuditUserActionsInDto
    {
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
    }
}