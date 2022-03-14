using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerSystems
{
    public class ConsumerSystemsInDto
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DisplayValue ApiServiceConsumer { get; set; }
        public DisplayValue ConsumerProfile { get; set; }
    }
}