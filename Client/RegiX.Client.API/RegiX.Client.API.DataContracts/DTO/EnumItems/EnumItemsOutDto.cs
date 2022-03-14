using TechnoLogica.RegiX.Client.API.DataContracts.DTO.BaseDtos;

namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.EnumItems
{
    public class EnumItemsOutDto : ABaseOutDto
    {
        public string EnumValue { get; set; }
        public string EnumDisplayText { get; set; }
        public byte? IdentifierType { get; set; }
    }
}