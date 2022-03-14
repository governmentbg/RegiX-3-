using System;

namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditExceptions
{
    public class AuditExceptionsInDto
    {
        public int AuthorityId { get; set; }

        public DateTime ExceptionTime { get; set; }

        public string ExceptionText { get; set; }

        public string Stacktrace { get; set; }

        public int? UserId { get; set; }

        public string UserName { get; set; }

        public string Controller { get; set; }

        public string ActionMethod { get; set; }
    }
}