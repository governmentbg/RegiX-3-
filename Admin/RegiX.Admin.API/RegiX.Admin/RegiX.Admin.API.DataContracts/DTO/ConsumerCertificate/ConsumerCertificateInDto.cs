using System.ComponentModel.DataAnnotations;
using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerCertificate
{
    public class ConsumerCertificateInDto
    {
        [Required] public string Name { get; set; }

        [Required] public string Description { get; set; }

        [Required] public byte[] Content { get; set; }

        [Required] public decimal? ApiServiceConsumerId { get; set; }

        [Required] public bool? Active { get; set; }

        [Required] public string Oid { get; set; }
        
        [Required] public DisplayValue[] consumerRoleIds { get; set; }
    }
}