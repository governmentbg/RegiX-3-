using System;
using System.Collections.Generic;

namespace TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models
{
    public partial class IdentityRole
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}
