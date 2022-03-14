using System;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class HealthServiceOffline
    {
        public int HealthServiceOfflineId { get; set; }
        public DateTime StartPeriod { get; set; }
        public DateTime EndPeriod { get; set; }
        public string ServiceName { get; set; }
    }
}