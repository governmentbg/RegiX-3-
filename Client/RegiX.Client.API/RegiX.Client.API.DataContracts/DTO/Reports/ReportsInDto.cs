namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.Reports
{
    public class ReportsInDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int? AuthorityId { get; set; }
        public int AdapterOperationId { get; set; }
        public string LawReason { get; set; }
        public int? OrderNumber { get; set; }
        public string Code { get; set; }

        public int[] UserIds { get; set; }

        public int[] RoleIds { get; set; }
    }
}