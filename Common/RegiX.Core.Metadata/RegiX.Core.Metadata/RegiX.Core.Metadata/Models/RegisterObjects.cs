using System.Collections.Generic;

namespace RegiX.Core.Metadata.Models
{
    public class RegisterObjects : BaseModel
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
        public decimal RegisterAdapterId { get; set; }
        public string Xslt { get; set; }

        public virtual ICollection<AdapterOperations> AdapterOperations { get; set; }
        public virtual RegisterAdapters RegisterAdapters { get; set; }
        public virtual ICollection<RegisterObjectElements> RegisterObjectElements { get; set; }
    }
}