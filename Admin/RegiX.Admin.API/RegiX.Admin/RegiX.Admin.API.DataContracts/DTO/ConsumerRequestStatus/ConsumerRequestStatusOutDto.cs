using System;
using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerRequestStatus
{
    public class ConsumerRequestStatusOutDto
    {
        public decimal Id { get; set; }
        public DisplayValue ConsumerRequest { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public int? OldStatus { get; set; }
        public int NewStatus { get; set; }
    }
}