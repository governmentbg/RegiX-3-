using System;
using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AdapterOperationLog
{
    public class AdapterOperationLogOutDto
    {
        public decimal Id { get; set; }

        public decimal ApiServiceCallId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DisplayValue AdapterOperation { get; set; }
    }
}