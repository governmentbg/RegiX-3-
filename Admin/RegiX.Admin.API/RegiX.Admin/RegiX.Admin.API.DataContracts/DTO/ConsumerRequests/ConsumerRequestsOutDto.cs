using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerRequests
{
    public class ConsumerRequestsOutDto
    {
        public decimal Id { get; set; }
        public DisplayValue ConsumerProfile { get; set; }
        public string Status { get; set; }
        public string DocumentNumber { get; set; }
        public string OutDocumentNumber { get; set; }
        public string Name { get; set; }
    }
}