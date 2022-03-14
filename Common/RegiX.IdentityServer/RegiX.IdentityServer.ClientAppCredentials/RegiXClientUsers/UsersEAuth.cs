using System;
using System.Collections.Generic;
using System.Text;

namespace RegiX.IdentityServer.RegiXClientUsers
{
    public class UsersEAuth
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string IdentifierType { get; set; }

        public FederationUsers IdNavigation { get; set; }
    }
}
