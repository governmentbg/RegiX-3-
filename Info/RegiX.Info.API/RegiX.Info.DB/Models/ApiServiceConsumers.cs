using System;
using System.Collections.Generic;

namespace RegiX.Info.Infrastructure.Models
{
    public partial class ApiServiceConsumers
    {
        public ApiServiceConsumers()
        {
            ConsumerCertificates = new HashSet<ConsumerCertificates>();
            ConsumerSystems = new HashSet<ConsumerSystems>();
        }

        public decimal ApiServiceConsumerId { get; set; }
        public string Name { get; set; }
        public decimal? AdministrationId { get; set; }
        public string Description { get; set; }
        public string Oid { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }


        public virtual Administrations Administration { get; set; }
        public virtual ICollection<ConsumerCertificates> ConsumerCertificates { get; set; }
        public virtual ICollection<ConsumerSystems> ConsumerSystems { get; set; }
    }
}
