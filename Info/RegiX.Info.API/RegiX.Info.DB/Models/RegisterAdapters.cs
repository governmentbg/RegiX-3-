using System;
using System.Collections.Generic;
using System.Text;

namespace RegiX.Info.Infrastructure.Models
{
    public partial class RegisterAdapters
    {
        public RegisterAdapters()
        {
            AdapterOperations = new HashSet<AdapterOperations>();
            RegisterObjects = new HashSet<RegisterObjects>();
        }

        public decimal RegisterAdapterId { get; set; }
        public decimal RegisterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Contract { get; set; }

        public virtual Registers Register { get; set; }
        public virtual ICollection<AdapterOperations> AdapterOperations { get; set; }
        public virtual ICollection<RegisterObjects> RegisterObjects { get; set; }
    }
}
