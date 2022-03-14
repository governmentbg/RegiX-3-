namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.Parameter
{
    public class ParameterInDto
    {
        public int ParameterTypeId { get; set; }
        public string ParameterName { get; set; }
        public bool IsXmlElement { get; set; }
        public string ParameterLabel { get; set; }
        public string RegexExpression { get; set; }
        public bool? IsRequired { get; set; }
        public int? ParentParameterId { get; set; }
        public int? OrderNumber { get; set; }
        public string Namespace { get; set; }
        public byte? IdentifierType { get; set; }
    }
}