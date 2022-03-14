namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.UserToReport
{
    public class UsersFavouriteReportInDto
    {
        // TODO this should be removed and retrived from the identity
        public int UserId { get; set; }
        public int[] ReportIds { get; set; }
    }
}