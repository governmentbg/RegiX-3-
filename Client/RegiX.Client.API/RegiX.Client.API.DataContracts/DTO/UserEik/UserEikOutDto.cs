using TechnoLogica.RegiX.Client.API.DataContracts.DTO.BaseDtos;

namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.UserEik
{
    public class UserEikOutDto : ABaseOutDto
    {
        public DisplayValue User { get; set; }
        public string Eik { get; set; }
    }
}