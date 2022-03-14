namespace TechnoLogica.RegiX.AdapterConsole.DataContracts.AspNetUserRoles
{
    public class AspNetUserInDto
    {
        public string Name { get; set; }

        public string UserName { get; set; }

        public bool isActive { get; set; }

        public int[] ReportIds { get; set; }

        public int[] RoleIds { get; set; }
    }
}