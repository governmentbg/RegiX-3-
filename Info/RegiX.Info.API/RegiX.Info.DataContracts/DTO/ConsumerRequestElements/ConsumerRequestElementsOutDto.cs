using TechnoLogica.API.DataContracts;

namespace RegiX.Info.DataContracts.DTO.ConsumerRequestElements
{
    public class ConsumerRequestElementsOutDto
    {
        public decimal Id { get; set; }
        public decimal ConsumerAccessRequestId { get; set; }
        public DisplayValue RegisterObjectElement { get; set; }
    }
}
