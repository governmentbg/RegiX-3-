namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class AuditValues
    {
        public decimal Id { get; set; }
        public decimal AuditTableId { get; set; }
        public string ColumnName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }

        public virtual AuditTables AuditTable { get; set; }
    }
}