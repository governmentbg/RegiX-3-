using System.Collections.Generic;

namespace TechnoLogica.RegiX.Client.Infrastructure.Models
{
    public partial class Registers : BaseModel
    {
        public Registers()
        {
            AdapterOperations = new HashSet<AdapterOperations>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorityId { get; set; }
        public string Code { get; set; }
        public string ClientName { get; set; }
        public string BindingName { get; set; }
        public string Version { get; set; }

        public virtual Authorities Authority { get; set; }
        public virtual ICollection<AdapterOperations> AdapterOperations { get; set; }
    }
}