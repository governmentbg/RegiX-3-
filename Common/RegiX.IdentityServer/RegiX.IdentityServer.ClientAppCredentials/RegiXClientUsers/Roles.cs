using RegiX.IdentityServer.RegiXClientUsers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegiX.IdentityServer.RegiXClientUsers
{
    public partial class Roles
    {
        public Roles()
        {
            UsersToRoles = new HashSet<UsersToRoles>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int RoleType { get; set; }
        public int? AuthorityId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<UsersToRoles> UsersToRoles { get; set; }
    }
}
