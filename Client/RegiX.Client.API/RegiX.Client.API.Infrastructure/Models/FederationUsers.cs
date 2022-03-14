namespace TechnoLogica.RegiX.Client.Infrastructure.Models
{
    public partial class FederationUsers
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public int UserAuthorityId { get; set; }
        public string UserName { get; set; }

        public virtual Users IdNavigation { get; set; }
        public virtual UsersEauth UsersEauth { get; set; }
        public virtual Authorities UserAuthority { get; set; }
        public virtual LocalUsers LocalUsers { get; set; }
    }
}