namespace TechnoLogica.RegiX.Client.Infrastructure.Models
{
    public partial class UsersToRoles : BaseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual Users User { get; set; }
    }
}