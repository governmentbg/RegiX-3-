using System.ComponentModel.DataAnnotations;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.User
{
    public class UserEditInDto
    {
        [Required] public string UserName { get; set; }

        [Required] public string Email { get; set; }

        [Required] public string Name { get; set; }

        public decimal? AdministrationId { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsAdmin { get; set; }
    }
}