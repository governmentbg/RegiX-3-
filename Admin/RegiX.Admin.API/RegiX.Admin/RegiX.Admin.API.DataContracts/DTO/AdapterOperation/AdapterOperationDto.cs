using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AdapterOperation
{
    //used in CertificateOperationAccessOutDto insted of DisplayValue beacause we need to display more info
    public class AdapterOperationDto : DisplayValue
    {
        public string Description { get; set; }
    }
}