using System;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.BaseDtos;

namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditUserActions
{
    public class AuditUserActionsOutDto : ABaseOutDto
    {
        public DisplayValue Authority { get; set; }

        public DateTime UserActionTime { get; set; }

        public string UserActionText { get; set; }

        public string UserActionType { get; set; }

        public string UserName { get; set; }

        public DisplayValue User { get; set; }

        public string Controller { get; set; }

        public string ActionMethod { get; set; }

        public string ExecuteStatus { get; set; }

        public string Params { get; set; }

        public string Url { get; set; }

        public string ChangedTables { get; set; }
    }
}