using TechnoLogica.API.DataContracts;

namespace RegiX.Info.DataContracts.DTO.ConsumerSystems
{
    public class ConsumerSystemsOutDto
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string StaticIP { get; set; }
        public string Description { get; set; }
        public DisplayValue ApiServiceConsumer { get; set; }
        public DisplayValue ConsumerProfile { get; set; }
    }
}
