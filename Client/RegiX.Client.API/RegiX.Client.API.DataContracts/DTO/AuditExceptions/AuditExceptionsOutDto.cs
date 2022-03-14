using System;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.BaseDtos;

namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditExceptions
{
    public class AuditExceptionsOutDto : ABaseOutDto
    {
        public DisplayValue Authority { get; set; }

        public DateTime ExceptionTime { get; set; }

        public string ExceptionText { get; set; }

        public string Stacktrace { get; set; }

        public DisplayValue User { get; set; }

        public string UserName { get; set; }

        public string Controller { get; set; }

        public string ActionMethod { get; set; }
    }
}