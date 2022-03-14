using TechnoLogica.RegiX.Client.API.DataContracts.DTO.BaseDtos;

namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.Parameter
{
    public class ParameterOutDto : ABaseOutDto
    {
        public DisplayValue ParameterType { get; set; }
        public string ParameterName { get; set; }
        public bool IsXmlElement { get; set; }
        public string ParameterLabel { get; set; }
        public string RegexExpression { get; set; }
        public bool? IsRequired { get; set; }
        public DisplayValue ParentParameter { get; set; }
        public int? OrderNumber { get; set; }
        public string Namespace { get; set; }
        public byte? IdentifierType { get; set; }
    }
}