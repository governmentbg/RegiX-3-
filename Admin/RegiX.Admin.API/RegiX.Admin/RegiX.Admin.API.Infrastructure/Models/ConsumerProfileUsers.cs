using System;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class ConsumerProfileUsers
    {
        public decimal ConsumerProfileUserId { get; set; }
        public decimal ConsumerProfileId { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Identifier { get; set; }
        public int IdentifierType { get; set; }

        public virtual ConsumerProfiles ConsumerProfile { get; set; }
    }
}
