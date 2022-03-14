namespace TechnoLogica.RegiX.AdapterConsole.DataContracts.AdapterOperation
{
    public class AdapterOperationsOutDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Contract { get; set; }
        public string MetadataRequestXml { get; set; }
        public string MetadataResponseXml { get; set; }
    }
}