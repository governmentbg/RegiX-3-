using System;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.BaseDtos;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerCertificate
{
    public class ServiceConsumerInfo : DisplayValue
    {
        public string Oid { get; set; }
    }

    public class ConsumerCertificateOutDto : BaseOutDto
    {
        public string Thumbprint { get; set; }
        public byte[] Content { get; set; }
        public string IssuedFrom { get; set; }
        public string IssuedTo { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public bool? Active { get; set; }
        public string Oid { get; set; }
        public ServiceConsumerInfo ApiServiceConsumer { get; set; }
    }
}