using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.CustomParameter
{
    public class CustomParameterOutDto
    {
        public int Id { get; set; }

        public string Label { get; set; }
        public bool? IsRequired { get; set; }
        public string RegexExpression { get; set; }
        public string Code { get; set; }
        public int? Order { get; set; }

        public DisplayValue Report { get; set; }
        public DisplayValue OperationParameter { get; set; }
    }
}