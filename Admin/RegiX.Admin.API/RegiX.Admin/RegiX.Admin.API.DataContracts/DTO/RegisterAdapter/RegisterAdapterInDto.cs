namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.RegisterAdapter
{
    public class RegisterAdapterInDto
    {
        public decimal RegisterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AdapterUrl { get; set; }
        public string BindingConfigName { get; set; }
        public string Contract { get; set; }
        public string BindingType { get; set; }
        public string Assembly { get; set; }
        public string Behaviour { get; set; }
    }
}