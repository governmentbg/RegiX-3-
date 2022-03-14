namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.MetadataSyncServiceDtos
{
    public class RegisterDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public AdapterDto[] Adapters { get; set; }
    }
}