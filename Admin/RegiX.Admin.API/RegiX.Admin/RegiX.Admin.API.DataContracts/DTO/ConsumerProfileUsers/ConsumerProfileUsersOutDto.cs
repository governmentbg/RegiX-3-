using System;
using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerProfileUsers
{
    public class ConsumerProfileUsersOutDto
    {
        public decimal Id { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Identifier { get; set; }
        public int IdentifierType { get; set; }

        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }

        public virtual DisplayValue ConsumerProfile { get; set; }
    }
}