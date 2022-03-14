namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class ConsumerRoleElementAccess
    {
        public decimal Id { get; set; }
        public decimal ConsumerRoleId { get; set; }
        public decimal RegisterObjectElementId { get; set; }
        public bool HasAccess { get; set; }

        public virtual ConsumerRoles ConsumerRole { get; set; }
        public virtual RegisterObjectElements RegisterObjectElement { get; set; }
    }
}
