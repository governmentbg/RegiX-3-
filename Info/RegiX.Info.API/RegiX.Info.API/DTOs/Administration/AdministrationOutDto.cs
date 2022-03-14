namespace RegiX.Info.API.DTOs.Administration
{
    public class AdministrationOutDto
    {
        public string Name { get; set; }

        public int RegistersCount { get; set; }

        public int AdaptersCount { get; set; }

        public int OperationsCount { get; set; }

        public string Acronym { get; set; }
    }
}