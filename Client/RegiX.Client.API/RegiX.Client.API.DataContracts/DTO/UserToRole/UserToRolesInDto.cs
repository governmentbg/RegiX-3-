using System;

namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.UserToRole
{
    public class UserToRoleInDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}