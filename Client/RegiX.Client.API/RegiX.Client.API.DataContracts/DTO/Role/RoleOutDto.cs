using TechnoLogica.RegiX.Client.API.DataContracts.DTO.BaseDtos;

namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.Role
{
    public class RoleOutDto : ABaseOutDto
    {
        public string Name { get; set; }

        public int RoleType { get; set; }

        public DisplayValue Authority { get; set; }
    }
}