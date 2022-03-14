using TechnoLogica.RegiX.Client.API.DataContracts.DTO.BaseDtos;

namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.MyProfileDtos
{
    public class MyProfileOutDto : ABaseOutDto
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public UsersEauthDto UsersEauth { get; set; }
    }
}