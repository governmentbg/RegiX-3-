using System.Collections.Generic;

namespace RegiX.Info.Infrastructure.Models
{
    public partial class AdministrationTypes
    {
        public AdministrationTypes()
        {
            Administrations = new HashSet<Administrations>();
        }

        public decimal AdministrationTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool PubliclyVisible { get; set; }

        public virtual ICollection<Administrations> Administrations { get; set; }
    }
}