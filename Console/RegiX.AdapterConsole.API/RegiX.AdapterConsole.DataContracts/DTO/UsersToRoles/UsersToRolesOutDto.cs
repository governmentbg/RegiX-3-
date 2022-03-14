using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.AdapterConsole.DataContracts.UsersToRoles
{
    public class UsersToRolesOutDto
    {
        public int Id { get; set; }
        public DisplayValue User { get; set; }
        public DisplayValue Role { get; set; }
    }
}