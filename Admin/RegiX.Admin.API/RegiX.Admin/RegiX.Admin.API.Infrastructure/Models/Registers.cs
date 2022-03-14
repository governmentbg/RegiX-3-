using System.Collections.Generic;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class Registers : BaseModel
    {
        public Registers()
        {
            RegisterAdapters = new HashSet<RegisterAdapters>();
        }

        public decimal RegisterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal AdministrationId { get; set; }
        public string Code { get; set; }

        public virtual Administrations Administration { get; set; }
        public virtual ICollection<RegisterAdapters> RegisterAdapters { get; set; }
    }
}