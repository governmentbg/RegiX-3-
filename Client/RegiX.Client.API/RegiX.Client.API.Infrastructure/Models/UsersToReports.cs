namespace TechnoLogica.RegiX.Client.Infrastructure.Models
{
    public partial class UsersToReports : BaseModel
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public int UserId { get; set; }

        //TODO : Add AuthorityID ? 

        public virtual Users User { get; set; }
        public virtual Reports Report { get; set; }
    }
}