using System;
using System.Collections.Generic;

namespace RegiX.IdentityServer.RegiXClientUsers
{
    public partial class FederationUsers
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public int UserAuthorityId { get; set; }
        public string UserName { get; set; }

        public Users IdNavigation { get; set; }
        public LocalUsers LocalUsers { get; set; }
        public UsersEAuth UserEAuth { get; set; }
    }
}
