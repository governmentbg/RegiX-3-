namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditValues
{
    public class AuditValuesInDto
    {
        public int AuditTableId { get; set; }
        public string ColumnName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
}