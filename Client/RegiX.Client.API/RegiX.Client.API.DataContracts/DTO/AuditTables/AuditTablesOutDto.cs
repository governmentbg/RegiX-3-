using TechnoLogica.RegiX.Client.API.DataContracts.DTO.BaseDtos;

namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditTables
{
    public class AuditTablesOutDto : ABaseOutDto
    {
        public string Action { get; set; }
        public string TableName { get; set; }
        public DisplayValue Authority { get; set; }
        public DisplayValue User { get; set; }
        public int TableId { get; set; }
    }
}