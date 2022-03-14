using System;
using System.Collections.Generic;

namespace TechnoLogica.RegiX.Client.Infrastructure.Models
{
    public partial class PublicUsers
    {
        public PublicUsers()
        {
            UserEiks = new HashSet<UserEiks>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public byte PersonIdentifierType { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string TokenId { get; set; }

        public virtual Users IdNavigation { get; set; }
        public virtual ICollection<UserEiks> UserEiks { get; set; }
    }
}