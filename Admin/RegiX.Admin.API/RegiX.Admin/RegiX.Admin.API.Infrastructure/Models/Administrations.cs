using System.Collections.Generic;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class Administrations : BaseModel
    {
        public Administrations()
        {
            ApiServiceConsumers = new HashSet<ApiServiceConsumers>();
            ApiServices = new HashSet<ApiServices>();
            InverseParentAuthority = new HashSet<Administrations>();
            Registers = new HashSet<Registers>();
            Users = new HashSet<Users>();
            ConsumerProfiles = new HashSet<ConsumerProfiles>();
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
        public string Oid { get; set; }

        public virtual AdministrationTypes AdministrationType { get; set; }
        public virtual Administrations ParentAuthority { get; set; }
        public virtual ICollection<ApiServiceConsumers> ApiServiceConsumers { get; set; }
        public virtual ICollection<ApiServices> ApiServices { get; set; }
        public virtual ICollection<Administrations> InverseParentAuthority { get; set; }
        public virtual ICollection<Registers> Registers { get; set; }
        public virtual ICollection<Users> Users { get; set; }
        public virtual ICollection<ConsumerProfiles> ConsumerProfiles { get; set; }
    }
}