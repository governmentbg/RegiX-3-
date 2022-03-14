using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.BaseDtos;
namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.Register
{
    public class RegisterOutDto : BaseOutDto
    {
        public DisplayValue Administration { get; set; }

        public string Code { get; set; }
    }
}