using TechnoLogica.RegiX.Client.API.DataContracts.DTO.BaseDtos;

namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.ReportsForUsersView
{
    public class ReportsForUsersViewOutDto : BaseOutDto
    {
        public int AuthorityId { get; set; }
        public string AuthorityName { get; set; }
        public string AuthorityAcronym { get; set; }
        public int RegisterId { get; set; }
        public string RegisterName { get; set; }
        public int OperationId { get; set; }
        public string OperationName { get; set; }
        public int ReportId { get; set; }
        public string ReportName { get; set; }
        public bool Favourite { get; set; }
        public int UserId { get; set; }
    }
}