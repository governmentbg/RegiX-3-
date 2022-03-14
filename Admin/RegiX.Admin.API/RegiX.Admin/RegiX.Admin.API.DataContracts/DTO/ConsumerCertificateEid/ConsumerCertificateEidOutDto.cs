using System;
using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerCertificateEid
{
    public class ConsumerCertificateEidOutDto
    {
        public decimal Id { get; set; }
        public string Spin { get; set; }

        public string GivenName { get; set; }
        public string MiddleName { get; set; }
        public string FamilyName { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool Active { get; set; }
        public DisplayValue ConsumerCertificate { get; set; }
    }
}