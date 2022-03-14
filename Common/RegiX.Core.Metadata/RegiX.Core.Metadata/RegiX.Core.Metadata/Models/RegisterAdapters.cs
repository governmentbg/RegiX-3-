using System.Collections.Generic;

namespace RegiX.Core.Metadata.Models
{
    public class RegisterAdapters : BaseModel
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
        public string AdapterUrl { get; set; }
        public string BindingConfigName { get; set; }
        public string Contract { get; set; }
        public string BindingType { get; set; }
        public string Assembly { get; set; }
        public string Behaviour { get; set; }

        public virtual ICollection<AdapterOperations> AdapterOperations { get; set; }
        public virtual ICollection<RegisterObjects> RegisterObjects { get; set; }
        public virtual Registers Registers { get; set; }
    }
}