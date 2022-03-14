using System.Collections.Generic;
using System.Text;

namespace TechnoLogica.RegiX.Client.Repositories
{
    public interface IUserContext
    {
        int? UserId { get; }
        string UserName { get; }
        int? AdministrationID { get; } // TODO : Is nullable ? 
        string[] Role { get; }
        string PublicUserIdentifier { get; }
        string PublicUserIdentifierType { get; }
        int[] RoleID { get; }
        bool IsPublic { get; }
        bool IsGlobalAdmin { get; }
        bool IsAdmin { get; }
    }
}
