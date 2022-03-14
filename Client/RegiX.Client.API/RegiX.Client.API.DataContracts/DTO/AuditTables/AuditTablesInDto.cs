namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditTables
{
    public class AuditTablesInDto
    {
        public string Action { get; set; }

        public string TableName { get; set; }

        public int AuthorityId { get; set; }

        public int? UserId { get; set; }

        public int TableId { get; set; }
    }
}