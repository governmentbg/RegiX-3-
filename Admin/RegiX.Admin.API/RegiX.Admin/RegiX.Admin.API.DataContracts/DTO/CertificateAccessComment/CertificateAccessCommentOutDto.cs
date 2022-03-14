using System;
using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.CertificateAccessComment
{
    public class CertificateAccessCommentOutDto
    {
        public decimal Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public string EditAccessComment { get; set; }
        public DisplayValue AdapterOperation { get; set; }
        public DisplayValue ConsumerCertificate { get; set; }
        public DisplayValue User { get; set; }
    }
}