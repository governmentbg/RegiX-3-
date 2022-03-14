using System.ComponentModel.DataAnnotations;

namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.MyProfileDtos
{
    public class MyProfileInDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Name { get; set; }

        public string Email { get; set; }

        public string Position { get; set; }

        public UsersEauthDto UsersEauth { get; set; }
    }
}