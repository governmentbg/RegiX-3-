using System.Collections.Generic;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class ApiServiceOperations : BaseModel
    {
        public ApiServiceOperations()
        {
            ApiServiceAdapterOperations = new HashSet<ApiServiceAdapterOperations>();
            ApiServiceCalls = new HashSet<ApiServiceCalls>();
            ApiServiceOperationLog = new HashSet<ApiServiceOperationLog>();
            OperationParameters = new HashSet<OperationParameters>();
            OperationsErrorLog = new HashSet<OperationsErrorLog>();
            Reports = new HashSet<Reports>();
        }

        public decimal ApiServiceOperationId { get; set; }
        public decimal ApiServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ResourceName { get; set; }
        public string Code { get; set; }

        public virtual ApiServices ApiService { get; set; }
        public virtual ICollection<ApiServiceAdapterOperations> ApiServiceAdapterOperations { get; set; }
        public virtual ICollection<ApiServiceCalls> ApiServiceCalls { get; set; }
        public virtual ICollection<ApiServiceOperationLog> ApiServiceOperationLog { get; set; }
        public virtual ICollection<OperationParameters> OperationParameters { get; set; }
        public virtual ICollection<OperationsErrorLog> OperationsErrorLog { get; set; }
        public virtual ICollection<Reports> Reports { get; set; }
    }
}