using System;
using System.Collections.Generic;
using System.Text;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public class UsersEAuth
    {
        public decimal UserId { get; set; }
        public string Identifier { get; set; }
        public string IdentifierType { get; set; }

        public virtual Users IdNavigation { get; set; }
    }
}
