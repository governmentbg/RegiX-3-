namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class ConsumerRoleOperationAccess : BaseModel
    {
        public decimal Id { get; set; }
        public decimal ConsumerRoleId { get; set; }
        public decimal AdapterOperationId { get; set; }
        public bool HasAccess { get; set; }

        public virtual AdapterOperations AdapterOperation { get; set; }
        public virtual ConsumerRoles ConsumerRole { get; set; }
    }
}
