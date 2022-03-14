using IdentityModel;
using System.Linq;
using System.Security.Claims;
using TechnoLogica.RegiX.AdapterConsole.Repositories;

namespace TechnoLogica.RegiX.AdapterConsole.API
{

    public class UserContext : IUserContext
    {
        public UserContext(ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal != null)
            {
                var subjectClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == JwtClaimTypes.Subject);
                if (subjectClaim != null)
                {
                    UserId = int.Parse(subjectClaim.Value);
                }
                var mainRole = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == JwtClaimTypes.Role)?.Value.ToString();
                if (mainRole != null)
                {
                    MainRole = mainRole;
                }
                var roleTypeClaims = claimsPrincipal.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
                if (roleTypeClaims != null)
                {
                    Roles = roleTypeClaims.ToArray();
                }
            }
        }

        public int? UserId { get; private set; }

        public string[] Roles { get; private set; }

        public string MainRole  { get; private set; }
}
}
