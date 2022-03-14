using System.Collections.Generic;

namespace TechnoLogica.RegiX.Core.Data.Interfaces.Models
{
    public class Register
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string AuthorityId { get; set; }
        public string BindingName { get; set; }
        public string ClientName { get; set; }
        public IEnumerable<AdapterInfo> Adapters { get; set; }
    }
}