using System;
using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AdapterPingResult
{
    public class AdapterPingResultOutDto
    {
        public decimal Id { get; set; }
        public DateTime ExecuteTime { get; set; }
        public decimal? ReplyTime { get; set; }
        public decimal Timeout { get; set; }

        public string IpAddress { get; set; }
        public string AppName { get; set; }
        public string CreatedBy { get; set; }
        public DisplayValue RegisterAdapter { get; set; }
    }
}