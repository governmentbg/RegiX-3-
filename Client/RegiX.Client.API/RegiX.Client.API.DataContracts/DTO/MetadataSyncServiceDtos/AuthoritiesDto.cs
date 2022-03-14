namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.MetadataSyncServiceDtos
{
    public class AuthoritiesDto
    {
        public string Acronym { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string OID { get; set; }
        public RegisterDto[] Registers { get; set; }
    }
}
