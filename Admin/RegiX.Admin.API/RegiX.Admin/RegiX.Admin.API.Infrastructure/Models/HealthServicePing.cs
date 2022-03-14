using System;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class HealthServicePing
    {
        public int HealthServicePingId { get; set; }
        public DateTime Time { get; set; }
        public string ServiceName { get; set; }
    }
}