using TechnoLogica.RegiX.Client.API.DataContracts.DTO.BaseDtos;

namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.UserToReport
{
    public class UserToReportOutDto : ABaseOutDto
    {
        public DisplayValueAuthority User { get; set; }
        public DisplayValue Report { get; set; }
    }
}