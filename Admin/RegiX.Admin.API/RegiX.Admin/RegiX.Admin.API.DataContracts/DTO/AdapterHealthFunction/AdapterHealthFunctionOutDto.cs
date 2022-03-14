using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AdapterHealthFunction
{
    public class AdapterHealthFunctionOutDto
    {
        public decimal Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DisplayValue RegisterAdapter { get; set; }
    }
}