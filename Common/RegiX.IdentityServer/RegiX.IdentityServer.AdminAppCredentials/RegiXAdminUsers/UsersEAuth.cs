using RegiX.IdentityServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegiX.IdentityServer
{
    public class UsersEAuth
    {
        public decimal UserId { get; set; }
        public string Identifier { get; set; }
        public string IdentifierType { get; set; }

        public Users IdNavigation { get; set; }
    }
}
