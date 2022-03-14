using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerCertificate
{
    //used in CertificateOperationAccessOutDto insted of DisplayValue beacause we need to display more info
    public class ConsumerCertificateDto : DisplayValue
    {
        public string Description { get; set; }
    }
}