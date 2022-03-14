using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.AdapterConsole.DataContracts.OperationsToRoles
{
    public class OperationsToRolesOutDto
    {
        public int Id { get; set; }
        public DisplayValue AdapterOperation { get; set; }
        public DisplayValue Role { get; set; }
    }
}