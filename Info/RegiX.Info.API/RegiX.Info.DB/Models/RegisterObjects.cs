using System;
using System.Collections.Generic;
using System.Text;

namespace RegiX.Info.Infrastructure.Models
{
    public partial class RegisterObjects
    {
        public RegisterObjects()
        {
            AdapterOperations = new HashSet<AdapterOperations>();
            RegisterObjectElements = new HashSet<RegisterObjectElements>();
        }

        public decimal RegisterObjectId { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public byte[] Content { get; set; }
        public string Xslt { get; set; }
        public decimal RegisterAdapterId { get; set; }

        public virtual RegisterAdapters RegisterAdapter { get; set; }
        public virtual ICollection<AdapterOperations> AdapterOperations { get; set; }
        public virtual ICollection<RegisterObjectElements> RegisterObjectElements { get; set; }
    }
}
