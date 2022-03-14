using TechnoLogica.RegiX.Client.API.DataContracts.DTO.BaseDtos;

namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.UserToRole
{
    public class UserToRoleOutDto : BaseOutDto
    {
        public DisplayValueAuthority User { get; set; }
        public DisplayValue Role { get; set; }
    }
}