using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.OperationParameter
{
    public class OperationParameterOutDto
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public bool? IsRequired { get; set; }
        public string RegexExpression { get; set; }
        public string Code { get; set; }
        public int? Order { get; set; }
        public DisplayValue ParameterType { get; set; }
        public DisplayValue ServiceOperation { get; set; }
    }
}