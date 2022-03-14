using System;
using System.Collections.Generic;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class ConsumerFilterView
    {
        public decimal AdministrationId { get; set; }
        public string AdministrationName { get; set; }
        public decimal ConsumerId { get; set; }
        public string ConsumerName { get; set; }
        public decimal ConsumerCertificateId { get; set; }
        public string ConsumerCertificateName { get; set; }
    }
}
