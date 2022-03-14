using System;
using System.Collections.Generic;

namespace RegiX.IdentityServer.RegiXClientUsers
{
    public partial class UsersToRoles
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public Users User { get; set; }
        public Roles Role { get; set; }
    }
}
