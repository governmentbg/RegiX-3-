using System;

namespace TechnoLogica.RegiX.AdapterConsole.DataContracts.AspNetUserRoles
{
    public class AspNetUserOutDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LockoutEndDate { get; set; }
        public int AccessFailedCount { get; set; }
    }
}