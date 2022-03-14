using System.Collections.Generic;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class ConsumerProfiles
    {
        public ConsumerProfiles()
        {
            ConsumerProfileStatus = new HashSet<ConsumerProfileStatus>();
            ConsumerProfileUsers = new HashSet<ConsumerProfileUsers>();
            ConsumerSystems = new HashSet<ConsumerSystems>();
            ConsumerRequests = new HashSet<ConsumerRequests>();
        }

        public decimal ConsumerProfileId { get; set; }
        public string Name { get; set; }
        public string Identifier { get; set; }
        public int IdentifierType { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
        public decimal? AdministrationId { get; set; }
        public bool AcceptedEula { get; set; }
        public string SecurityStamp { get; set; }
        public string DocumentNumber { get; set; }

        public virtual Administrations Administration { get; set; }
        public virtual ICollection<ConsumerProfileStatus> ConsumerProfileStatus { get; set; }
        public virtual ICollection<ConsumerProfileUsers> ConsumerProfileUsers { get; set; }
        public virtual ICollection<ConsumerSystems> ConsumerSystems { get; set; }
        public virtual ICollection<ConsumerRequests> ConsumerRequests { get; set; }
    }
}
