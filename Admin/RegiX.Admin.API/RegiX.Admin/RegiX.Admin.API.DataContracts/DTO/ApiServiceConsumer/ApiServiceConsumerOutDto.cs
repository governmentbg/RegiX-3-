using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.BaseDtos;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApiServiceConsumer
{
    public class ApiServiceConsumerOutDto : BaseOutDto
    {
        public string Oid { get; set; }

        public DisplayValue Administration { get; set; }
    }
}