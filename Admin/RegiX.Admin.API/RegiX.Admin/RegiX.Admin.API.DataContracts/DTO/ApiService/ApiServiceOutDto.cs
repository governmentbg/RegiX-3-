using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.BaseDtos;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApiService
{
    public class ApiServiceOutDto : BaseOutDto
    {
        public string ServiceUrl { get; set; }
        public string Contract { get; set; }
        public bool IsComplex { get; set; }
        public string Assembly { get; set; }
        public bool? Enabled { get; set; }
        public string ControlerName { get; set; }
        public string Code { get; set; }
        public DisplayValue Administration { get; set; }
    }
}