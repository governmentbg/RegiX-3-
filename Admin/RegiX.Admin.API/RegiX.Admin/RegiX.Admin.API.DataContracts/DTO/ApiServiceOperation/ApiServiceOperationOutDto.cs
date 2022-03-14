using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.BaseDtos;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApiServiceOperation
{
    public class ApiServiceOperationOutDto : BaseOutDto
    {
        public string ResourceName { get; set; }
        public string Code { get; set; }
        public DisplayValue ApiService { get; set; }
    }
}