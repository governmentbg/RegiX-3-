namespace TechnoLogica.RegiX.Client.Infrastructure.Models
{
    public partial class LocalUsers
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public bool IsPasswordMigrated { get; set; }

        public virtual FederationUsers IdNavigation { get; set; }
    }
}