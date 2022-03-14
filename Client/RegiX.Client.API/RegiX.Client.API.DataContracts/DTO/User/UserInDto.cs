using System.ComponentModel.DataAnnotations;

namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.User
{
    public class UserInDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Name { get; set; }

        public string Email { get; set; }

        public int AuthorityId { get; set; }
        public string Position { get; set; }
        public bool IsActive { get; set; }

        public int[] ReportIds { get; set; }

        public int[] RoleIds { get; set; }
    }
}