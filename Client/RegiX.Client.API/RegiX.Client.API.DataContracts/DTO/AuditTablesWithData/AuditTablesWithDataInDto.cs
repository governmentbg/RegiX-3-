namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditTablesWithData
{
    public class AuditTablesWithDataInDto
    {
        public string Action { get; set; }

        public string TableName { get; set; }

        public int AuthorityId { get; set; }

        public int? UserId { get; set; }

        public int TableId { get; set; }
    }
}