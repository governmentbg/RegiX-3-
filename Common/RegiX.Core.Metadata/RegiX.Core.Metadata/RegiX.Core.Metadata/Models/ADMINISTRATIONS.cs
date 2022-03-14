using System.Collections.Generic;

namespace RegiX.Core.Metadata.Models
{
    public class Administrations : BaseModel
    {
        public Administrations()
        {
            ApiServices = new HashSet<ApiServices>();
            Administrations1 = new HashSet<Administrations>();
        }

        public decimal AdministrationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? ParentAuthorityId { get; set; }
        public string PathToRoot { get; set; }
        public int? Depth { get; set; }
        public string Acronym { get; set; }
        public string Code { get; set; }
        public string PathToRootNames { get; set; }
        public bool? PubliclyVisible { get; set; }
        public decimal? AdministrationTypeId { get; set; }

        public virtual ICollection<ApiServices> ApiServices { get; set; }
        public virtual ICollection<Administrations> Administrations1 { get; set; }
        public virtual Administrations Administration1 { get; set; }
    }
}