using System;
using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AdapterHealthResult
{
    public class AdapterHealthResultOutDto
    {
        public decimal Id { get; set; }

        public DateTime ExecuteTime { get; set; }
        public string HealthResult { get; set; }
        public string HealthError { get; set; }
        public string IpAddress { get; set; }
        public string AppName { get; set; }
        public string CreatedBy { get; set; }
        public DisplayValue AdapterHealthFunction { get; set; }
        public DisplayValue RegisterAdapter { get; set; }
    }
}