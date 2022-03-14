using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApprovedRequestElements
{
    public class ApprovedRequestElementsOutDto
    {
        public decimal Id { get; set; }
        public decimal ConsumerAccessRequestId { get; set; }
        public DisplayValue RegisterObjectElement { get; set; }
    }
}