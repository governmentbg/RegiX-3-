using System.Security.Cryptography.X509Certificates;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.BaseDtos;

namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.Authorities
{
    public class AuthoritiesOutDto : ABaseOutDto
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public DisplayValue ParentAuthority { get; set; }

        public string Acronym { get; set; }

        public string Code { get; set; }

        public string Oid { get; set; }

        public string CertificateThumbprint { get; set; }

        public StoreName? CertificateStore { get; set; }

        public bool IsMultitenantAuthority { get; set; }
    }
}