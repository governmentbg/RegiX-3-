using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.BaseDtos;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.RegisterAdapter
{
    public class RegisterAdapterOutDto : BaseOutDto
    {
        public string AdapterUrl { get; set; }
        public string BindingConfigName { get; set; }
        public string Contract { get; set; }
        public string BindingType { get; set; }
        public string Assembly { get; set; }
        public string Behaviour { get; set; }
        public bool HostAvailability { get; set; }

        public DisplayValue Register { get; set; }
    }
}