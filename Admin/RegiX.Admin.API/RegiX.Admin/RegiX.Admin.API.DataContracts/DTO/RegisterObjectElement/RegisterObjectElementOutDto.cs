using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.BaseDtos;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.RegisterObjectElement
{
    public class RegisterObjectElementOutDto : BaseOutDto
    {
        public string PathToRoot { get; set; }
        public DisplayValue RegisterObject { get; set; }
    }
}