using System.Collections.Generic;

namespace TechnoLogica.RegiX.Client.Infrastructure.Models
{
    public partial class Roles : BaseModel
    {
        public Roles()
        {
            RolesToReports = new HashSet<RolesToReports>();
            UsersToRoles = new HashSet<UsersToRoles>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int RoleType { get; set; }
        public int? AuthorityId { get; set; }

        public virtual Authorities Authority { get; set; }
        public virtual ICollection<RolesToReports> RolesToReports { get; set; }
        public virtual ICollection<UsersToRoles> UsersToRoles { get; set; }
        
    }
}