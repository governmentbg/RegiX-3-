namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ParameterType
{
    public class ParameterTypeOutDto
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public bool IsEnum { get; set; }
        public string Code { get; set; }
        public string EnumValues { get; set; }
    }
}