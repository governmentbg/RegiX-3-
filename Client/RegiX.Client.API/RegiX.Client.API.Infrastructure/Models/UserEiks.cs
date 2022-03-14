namespace TechnoLogica.RegiX.Client.Infrastructure.Models
{
    public partial class UserEiks : BaseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Eik { get; set; }

        public virtual PublicUsers User { get; set; }
    }
}