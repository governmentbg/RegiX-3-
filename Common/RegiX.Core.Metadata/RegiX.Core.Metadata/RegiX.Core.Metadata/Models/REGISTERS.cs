using System.Collections.Generic;

namespace RegiX.Core.Metadata.Models
{
    public class Registers : BaseModel
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

        public virtual Administrations Administrations { get; set; }
        public virtual ICollection<RegisterAdapters> RegisterAdapters { get; set; }
    }
}