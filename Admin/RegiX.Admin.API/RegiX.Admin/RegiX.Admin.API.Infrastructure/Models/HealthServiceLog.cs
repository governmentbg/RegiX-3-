using System;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class HealthServiceLog
    {
        public int HealthServiceLogId { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
        public string ServiceName { get; set; }
    }
}