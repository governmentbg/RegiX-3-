namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.MetadataSyncServiceDtos
{
    public class AdapterDto
    {
        public string Description { get; set; }
        public string Interface { get; set; }
        public string Name { get; set; }
        public OperationDto[] Operations { get; set; }
        public string Version { get; set; }
    }
}
