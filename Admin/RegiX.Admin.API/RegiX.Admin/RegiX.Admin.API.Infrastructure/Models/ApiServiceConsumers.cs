using System.Collections.Generic;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class ApiServiceConsumers : BaseModel
    {
        public ApiServiceConsumers()
        {
            ConsumerCertificates = new HashSet<ConsumerCertificates>();
            ConsumerSystems = new HashSet<ConsumerSystems>();
            Reports = new HashSet<Reports>();
        }

        public decimal ApiServiceConsumerId { get; set; }
        public string Name { get; set; }
        public decimal? AdministrationId { get; set; }
        public string Description { get; set; }
        public string Oid { get; set; }
        public virtual Administrations Administration { get; set; }
        public virtual ICollection<ConsumerCertificates> ConsumerCertificates { get; set; }
        public virtual ICollection<ConsumerSystems> ConsumerSystems { get; set; }
        public virtual ICollection<Reports> Reports { get; set; }
    }
}