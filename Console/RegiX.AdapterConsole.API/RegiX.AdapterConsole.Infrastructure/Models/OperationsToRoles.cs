using System;
using System.Collections.Generic;

namespace TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models
{
    public partial class OperationsToRoles
    {
        public int Id { get; set; }
        public int AdapterOperationId { get; set; }
        public int RoleId { get; set; }

        public virtual AdapterOperations AdapterOperation { get; set; }
        public virtual AspNetRoles Role { get; set; }
    }
}
