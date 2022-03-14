using System;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class ConsumerCertificateEids
    {
        public decimal ConsumerCertificateEidId { get; set; }
        public string Spin { get; set; }
        public decimal ConsumerCertificateId { get; set; }
        public string GivenName { get; set; }
        public string MiddleName { get; set; }
        public string FamilyName { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool Active { get; set; }

        public virtual ConsumerCertificates ConsumerCertificate { get; set; }
    }
}