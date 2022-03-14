using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerRequestElements
{
    public class ConsumerRequestElementsOutDto
    {
        public decimal Id { get; set; }
        public decimal ConsumerAccessRequestId { get; set; }
        public DisplayValue RegisterObjectElement { get; set; }
    }
}