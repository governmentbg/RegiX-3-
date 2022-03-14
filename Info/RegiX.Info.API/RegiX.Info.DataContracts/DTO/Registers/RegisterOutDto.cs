using TechnoLogica.API.DataContracts;

namespace RegiX.Info.DataContracts.DTO.Registers
{
    public class RegisterOutDto :BaseOutDto
    {
        public DisplayValue Administration { get; set; }

        public string Code { get; set; }
    }
}