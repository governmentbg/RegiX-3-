namespace RegiX.Core.Metadata.Models
{
    public class RegisterObjectElements : BaseModel
    {
        public decimal RegisterObjectElementId { get; set; }
        public decimal RegisterObjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PathToRoot { get; set; }

        public virtual RegisterObjects RegisterObjects { get; set; }
    }
}