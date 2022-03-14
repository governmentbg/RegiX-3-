namespace TechnoLogica.RegiX.Admin.Infrastructure
{
    public interface IUserContext
    {
        int? UserId { get; }
        decimal? AdministrationID { get; } 
        string Role { get; }
        string UserName { get; }
    }
}