namespace TechnoLogica.RegiX.AdapterConsole.DataContracts.Users
{
    public class UsersInDto
    {
        public string Name { get; set; }

        public string UserName { get; set; }

        public bool isActive { get; set; }

        public int[] RoleIds { get; set; }
    }
}