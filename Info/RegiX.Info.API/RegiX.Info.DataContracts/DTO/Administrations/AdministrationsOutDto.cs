using RegiX.Info.DataContracts.DTO;
using TechnoLogica.API.DataContracts;

namespace RegiX.Info.API.DTOs.Administrations
{
    public class AdministrationsOutDto : BaseOutDto
    {
        public string PathToRoot { get; set; }
        public int? Depth { get; set; }
        public string Acronym { get; set; }
        public string Code { get; set; }
        public string PathToRootNames { get; set; }
        public bool? PubliclyVisible { get; set; }
    }
}