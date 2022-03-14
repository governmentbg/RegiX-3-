namespace TechnoLogica.RegiX.Client.Infrastructure.Models
{
    public partial class RolesToReports : BaseModel
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public int RoleId { get; set; }

        public virtual Reports Report { get; set; }
        public virtual Roles Role { get; set; }
    }
}