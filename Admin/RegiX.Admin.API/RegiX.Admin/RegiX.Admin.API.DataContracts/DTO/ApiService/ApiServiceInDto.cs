namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApiService
{
    public class ApiServiceInDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ServiceUrl { get; set; }
        public string Contract { get; set; }
        public bool IsComplex { get; set; }
        public decimal AdministrationId { get; set; }
        public string Assembly { get; set; }
        public bool? Enabled { get; set; }
        public string ControlerName { get; set; }
        public string Code { get; set; }
    }
}