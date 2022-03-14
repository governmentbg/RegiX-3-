using System;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.HealthServicePing
{
    public class HealthServicePingInDto
    {
        public DateTime? Time { get; set; }
        public string ServiceName { get; set; }
    }
}