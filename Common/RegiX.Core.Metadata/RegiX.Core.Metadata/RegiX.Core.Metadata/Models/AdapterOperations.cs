using System.Collections.Generic;

namespace RegiX.Core.Metadata.Models
{
    public class AdapterOperations : BaseModel
    {
        public AdapterOperations()
        {
            ApiServiceAdapterOperations = new HashSet<ApiServiceAdapterOperations>();
        }

        public decimal AdapterOperationId { get; set; }
        public decimal RegisterAdapterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? RegisterObjectId { get; set; }

        public virtual RegisterObjects RegisterObjects { get; set; }
        public virtual RegisterAdapters RegisterAdapters { get; set; }
        public virtual ICollection<ApiServiceAdapterOperations> ApiServiceAdapterOperations { get; set; }
    }
}