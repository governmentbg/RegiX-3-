using System.Collections.Generic;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class ApiServices : BaseModel
    {
        public ApiServices()
        {
            ApiServiceOperations = new HashSet<ApiServiceOperations>();
        }

        public decimal ApiServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ServiceUrl { get; set; }
        public string Contract { get; set; }
        public bool IsComplex { get; set; }
        public decimal AdministrationId { get; set; }
        public string Assembly { get; set; }
        public bool? Enabled { get; set; }
        public string ControlerName { get; set; }
        public string Code { get; set; }

        public virtual Administrations Administration { get; set; }
        public virtual ICollection<ApiServiceOperations> ApiServiceOperations { get; set; }
    }
}