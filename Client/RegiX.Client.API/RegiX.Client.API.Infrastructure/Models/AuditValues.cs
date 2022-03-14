namespace TechnoLogica.RegiX.Client.Infrastructure.Models
{
    public partial class AuditValues : BaseModel
    {
        public int Id { get; set; }
        public int AuditTableId { get; set; }
        public string ColumnName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }

        public virtual AuditTables AuditTable { get; set; }
    }
}