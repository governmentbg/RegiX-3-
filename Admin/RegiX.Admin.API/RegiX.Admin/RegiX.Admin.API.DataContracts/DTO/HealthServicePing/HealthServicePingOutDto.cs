using System;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.HealthServicePing
{
    public class HealthServicePingOutDto
    {
        public int Id { get; set; }
        public DateTime? Time { get; set; }
        public string ServiceName { get; set; }
    }
}