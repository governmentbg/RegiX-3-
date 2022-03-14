namespace TechnoLogica.RegiX.Client.Infrastructure.Models.DatabaseObjectModels
{
    public class ReportsForUsersView : IUserIDFilter
    {
        public long Id { get; set; }
        public int AuthorityId { get; set; }
        public string AuthorityAcronym { get; set; }
        public string AuthorityName { get; set; }
        public int RegisterId { get; set; }
        public string RegisterName { get; set; }
        public int OperationId { get; set; }
        public string OperationName { get; set; }
        public int ReportId { get; set; }
        public string ReportName { get; set; }
        public bool Favourite { get; set; }
        public int? UserId { get; set; }
    }
}