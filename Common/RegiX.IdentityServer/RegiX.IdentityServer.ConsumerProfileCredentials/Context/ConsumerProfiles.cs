using System;
using System.Collections.Generic;

namespace RegiX.IdentityServer.ConsumerProfileCredentials.Context
{
    public partial class ConsumerProfiles
    {
        public ConsumerProfiles()
        {
            ConsumerProfileStatus = new HashSet<ConsumerProfileStatus>();
            ConsumerProfileUsers = new HashSet<ConsumerProfileUsers>();
        }

        public decimal ConsumerProfileId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Identifier { get; set; }
        public int IdentifierType { get; set; }
        public int Status { get; set; }
        public decimal? AdministrationId { get; set; }
        public bool AcceptedEula { get; set; }
        public string SecurityStamp { get; set; }
        public string DocumentNumber { get; set; }

        public virtual ICollection<ConsumerProfileStatus> ConsumerProfileStatus { get; set; }
        public virtual ICollection<ConsumerProfileUsers> ConsumerProfileUsers { get; set; }
    }
}
