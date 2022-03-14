using System;
using System.Collections.Generic;
using TechnoLogica.RegiX.IdentityServer.ClientAppCredentials;

namespace RegiX.IdentityServer.RegiXClientUsers
{
    public partial class Users
    {
        public Users()
        {
            UsersToRoles = new HashSet<UsersToRoles>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LockoutEndDate { get; set; }
        public int AccessFailedCount { get; set; }
        public UserTypeEnum UserType { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Email { get; set; }
        public string PswdVerificationToken { get; set; }
        public DateTime? PswdVerTokenExpirationDate { get; set; }

        public FederationUsers FederationUsers { get; set; }
        public ICollection<UsersToRoles> UsersToRoles { get; set; }
    }
}
