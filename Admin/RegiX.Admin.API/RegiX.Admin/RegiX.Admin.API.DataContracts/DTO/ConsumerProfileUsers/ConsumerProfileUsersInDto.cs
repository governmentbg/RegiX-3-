using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerProfileUsers
{
    public class ConsumerProfileUsersInDto
    {
        public decimal Id { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Identifier { get; set; }
        public int IdentifierType { get; set; }

    }
}