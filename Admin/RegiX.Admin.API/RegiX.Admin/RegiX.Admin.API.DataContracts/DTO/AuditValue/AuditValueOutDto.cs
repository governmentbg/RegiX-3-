using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AuditValue
{
    public class AuditValueOutDto
    {
        public decimal Id { get; set; }
        public decimal AuditTableId { get; set; }
        public string ColumnName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }

        public virtual DisplayValue AuditTable { get; set; }
    }
}