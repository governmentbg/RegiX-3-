using TechnoLogica.RegiX.Client.API.DataContracts.DTO.BaseDtos;

namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.Register
{
    public class RegisterOutDto : ABaseOutDto
    {
        public string Name { get; set; }
        public DisplayValue Authority { get; set; }
        public string Code { get; set; }
        public string ClientName { get; set; }
        public string BindingName { get; set; }
    }
}