using System.Collections.Generic;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class AdapterOperations : BaseModel
    {
        public AdapterOperations()
        {
            AdapterOperationLog = new HashSet<AdapterOperationLog>();
            ApiServiceAdapterOperations = new HashSet<ApiServiceAdapterOperations>();
            CertificateAccessComments = new HashSet<CertificateAccessComments>();
            CertificateOperationAccess = new HashSet<CertificateOperationAccess>();
            OperationsErrorLog = new HashSet<OperationsErrorLog>();
            ConsumerRoleOperationAccess = new HashSet<ConsumerRoleOperationAccess>();
            ConsumerAccessRequests = new HashSet<ConsumerAccessRequests>();
        }

        public decimal AdapterOperationId { get; set; }
        public decimal RegisterAdapterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? RegisterObjectId { get; set; }

        public virtual RegisterAdapters RegisterAdapter { get; set; }
        public virtual RegisterObjects RegisterObject { get; set; }
        public virtual ICollection<AdapterOperationLog> AdapterOperationLog { get; set; }
        public virtual ICollection<ApiServiceAdapterOperations> ApiServiceAdapterOperations { get; set; }
        public virtual ICollection<CertificateAccessComments> CertificateAccessComments { get; set; }
        public virtual ICollection<CertificateOperationAccess> CertificateOperationAccess { get; set; }
        public virtual ICollection<OperationsErrorLog> OperationsErrorLog { get; set; }
        public virtual ICollection<ConsumerRoleOperationAccess> ConsumerRoleOperationAccess { get; set; }
        public virtual ICollection<ConsumerAccessRequests> ConsumerAccessRequests { get; set; }
    }
}