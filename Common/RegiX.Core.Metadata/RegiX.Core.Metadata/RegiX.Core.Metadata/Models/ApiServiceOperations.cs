using System.Collections.Generic;

namespace RegiX.Core.Metadata.Models
{
    public class ApiServiceOperations : BaseModel
    {
        public ApiServiceOperations()
        {
            ApiServiceAdapterOperations = new HashSet<ApiServiceAdapterOperations>();
        }

        public decimal ApiServiceOperationId { get; set; }
        public decimal ApiServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ResourceName { get; set; }
        public string Code { get; set; }

        public virtual ApiServices ApiServices { get; set; }
        public virtual ICollection<ApiServiceAdapterOperations> ApiServiceAdapterOperations { get; set; }
    }
}