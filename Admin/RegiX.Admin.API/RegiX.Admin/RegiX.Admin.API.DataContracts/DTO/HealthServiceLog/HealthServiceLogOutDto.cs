using System;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.HealthServiceLog
{
    public class HealthServiceLogOutDto
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
        public string ServiceName { get; set; }
    }
}