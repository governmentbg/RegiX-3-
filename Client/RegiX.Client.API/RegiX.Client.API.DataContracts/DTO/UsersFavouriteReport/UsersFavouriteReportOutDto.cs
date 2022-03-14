using TechnoLogica.RegiX.Client.API.DataContracts.DTO.BaseDtos;

namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.UserToReport
{
    public class UsersFavouriteReportOutDto : ABaseOutDto
    {
        public DisplayValue User { get; set; }
        public DisplayValue Report { get; set; }
        public DisplayValue AdapterOperation { get; set; }
        public DisplayValue Register { get; set; }
        public DisplayValue Authority { get; set; }
    }
}