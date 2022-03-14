using Microsoft.AspNetCore.Identity;

namespace RegiX.IdentityServer.ConsumerProfileCredentials.Context
{
    public partial class ConsumerProfileUsers : IdentityUser<decimal>
    {
        public decimal ConsumerProfileId { get; set; }
        public string Position { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Identifier { get; set; }
        public int IdentifierType { get; set; }

        public virtual ConsumerProfiles ConsumerProfile { get; set; }
    }
}
