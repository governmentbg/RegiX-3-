using TechnoLogica.RegiX.Client.API.DataContracts.DTO.BaseDtos;

namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.RoleToReport
{
    public class RoleToReportOutDto : ABaseOutDto
    {
        public DisplayValueAuthority Report { get; set; }
        public DisplayValue Role { get; set; }
    }
}