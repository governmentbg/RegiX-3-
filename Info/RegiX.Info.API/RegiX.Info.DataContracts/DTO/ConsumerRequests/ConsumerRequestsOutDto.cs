using TechnoLogica.API.DataContracts;

namespace RegiX.Info.DataContracts.DTO.ConsumerRequests
{
    public class ConsumerRequestsOutDto
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public  DisplayValue ConsumerSystem { get; set; }
    }
}
