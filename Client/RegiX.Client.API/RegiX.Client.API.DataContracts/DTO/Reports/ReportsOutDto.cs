using TechnoLogica.RegiX.Client.API.DataContracts.DTO.BaseDtos;

namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.Reports
{
    public class ReportsOutDto : ABaseOutDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DisplayValue AdapterOperation { get; set; }
        public DisplayValue Register { get; set; }
        public DisplayValue RegisterAuthority { get; set; }
        public string LawReason { get; set; }
        public int? OrderNumber { get; set; }
        public string Code { get; set; }
        public DisplayValue Authority { get; set; }
    }
}