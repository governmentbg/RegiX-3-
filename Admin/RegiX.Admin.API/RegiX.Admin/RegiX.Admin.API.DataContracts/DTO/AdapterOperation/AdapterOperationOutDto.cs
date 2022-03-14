using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.BaseDtos;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AdapterOperation
{
    public class AdapterOperationOutDto : BaseOutDto
    {
        public DisplayValue RegisterAdapter { get; set; }
        public DisplayValue RegisterObject { get; set; }
    }
}