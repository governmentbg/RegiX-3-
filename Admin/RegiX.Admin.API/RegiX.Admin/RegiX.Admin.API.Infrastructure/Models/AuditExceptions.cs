using System;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class AuditExceptions
    {
        public decimal AuditExceptionId { get; set; }
        public DateTime? ExceptionTime { get; set; }
        public string ExceptionText { get; set; }
        public decimal? UserId { get; set; }
        public string UserName { get; set; }
        public string Controller { get; set; }
        public string ActionMethod { get; set; }
        public string IpAddress { get; set; }
    }
}