namespace TechnoLogica.RegiX.AdapterConsole.Repositories
{
    public interface IUserContext
    {
        int? UserId { get; }
        string MainRole { get; }
        string[] Roles { get; }
    }
}