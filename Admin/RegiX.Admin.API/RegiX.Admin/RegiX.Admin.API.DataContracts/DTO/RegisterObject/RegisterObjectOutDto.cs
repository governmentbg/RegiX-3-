using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.BaseDtos;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.RegisterObject
{
    public class RegisterObjectOutDto : BaseOutDto
    {
        public string FullName { get; set; }

        public byte[] Content { get; set; }

        public string Xslt { get; set; }

        public DisplayValue RegisterAdapter { get; set; }
    }
}