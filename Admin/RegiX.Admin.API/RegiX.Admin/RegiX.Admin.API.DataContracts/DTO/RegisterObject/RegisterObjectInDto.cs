namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.RegisterObject
{
    public class RegisterObjectInDto
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public byte[] Content { get; set; }

        public string Xslt { get; set; }

        public decimal? RegisterAdapterId { get; set; }
    }
}