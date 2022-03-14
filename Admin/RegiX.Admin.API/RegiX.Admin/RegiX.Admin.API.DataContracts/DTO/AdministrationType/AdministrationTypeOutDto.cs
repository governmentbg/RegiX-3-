namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AdministrationType
{
    public class AdministrationTypeOutDto
    {
        public decimal Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool? PubliclyVisible { get; set; }
    }
}