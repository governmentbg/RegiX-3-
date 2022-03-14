namespace TechnoLogica.RegiX.Client.Infrastructure.Models
{
    public class UsersEauth
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string IdentifierType { get; set; }

        public virtual FederationUsers IdNavigation { get; set; }
    }
}