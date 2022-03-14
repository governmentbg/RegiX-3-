using System;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerAccessRequestsStatus
{
    public class ConsumerAccessRequestsStatusOutDto
    {
        public decimal Id { get; set; }
        public decimal ConsumerAccessRequestId { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public int? OldStatus { get; set; }
        public int NewStatus { get; set; }
    }
}