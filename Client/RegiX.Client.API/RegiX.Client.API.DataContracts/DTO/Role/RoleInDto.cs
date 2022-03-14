namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.Role
{
    public class RoleInDto
    {
        public string Name { get; set; }

        public int RoleType { get; set; }

        public int? AuthorityId { get; set; }

        public int[] ReportIds { get; set; }
        public int[] UserIds { get; set; }
    }
}