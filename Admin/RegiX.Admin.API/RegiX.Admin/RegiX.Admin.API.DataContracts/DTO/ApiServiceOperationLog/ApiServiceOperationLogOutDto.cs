using System;
using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApiServiceOperationLog
{
    public class ApiServiceOperationLogOutDto
    {
        public decimal Id { get; set; }
        public decimal ServiceCallId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DisplayValue ApiServiceOperation { get; set; }
    }
}