using System;
using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerProfileStatus
{
    public class ConsumerProfileStatusOutDto
    {
        public decimal Id { get; set; }
        public int OldStatus { get; set; }
        public int NewStatus { get; set; }
        public string Comment { get; set; }
        public DateTime? Date { get; set; }
        public  DisplayValue ConsumerProfile { get; set; }
    }
}