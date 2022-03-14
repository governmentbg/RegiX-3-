using System;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.HealthServiceOffline
{
    public class HealthServiceOfflineInDto
    {
        public DateTime? StartPeriod { get; set; }
        public DateTime? EndPeriod { get; set; }
        public string ServiceName { get; set; }
    }
}