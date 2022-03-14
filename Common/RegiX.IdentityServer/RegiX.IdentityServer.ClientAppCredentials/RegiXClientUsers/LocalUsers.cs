using System;
using System.Collections.Generic;

namespace RegiX.IdentityServer.RegiXClientUsers
{
    public partial class LocalUsers
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public bool IsPasswordMigrated { get; set; }

        public FederationUsers IdNavigation { get; set; }
    }
}
