using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerProfiles
{
    public class ConsumerProfilesInDto
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Identifier { get; set; }
        public int IdentifierType { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
        public string Comment { get; set; }
        public bool AcceptedEula { get; set; }
        public string SecurityStamp { get; set; }
        public string DocumentNumber { get; set; }
        public DisplayValue Administration { get; set; }
    }
}