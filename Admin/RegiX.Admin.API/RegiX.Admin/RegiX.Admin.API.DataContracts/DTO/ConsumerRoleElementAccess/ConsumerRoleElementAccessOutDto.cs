using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerRoleElementAccess
{
    public class ConsumerRoleElementAccessOutDto
    {
        public decimal Id { get; set; }
        public DisplayValue ConsumerRole { get; set; }
        public DisplayValue RegisterObjectElement { get; set; }
        public bool HasAccess { get; set; }
    }
}