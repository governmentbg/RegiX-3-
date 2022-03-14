namespace TechnoLogica.RegiX.Client.Infrastructure.Models
{
    public partial class UsersFavouriteReports : BaseModel
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public int UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual Reports Report { get; set; }
        
    }
}