using IdentityModel;
using System;
using System.Linq;
using System.Security.Claims;
using TechnoLogica.RegiX.Client.Repositories;

namespace TechnoLogica.RegiX.Client.API
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
                var administrationClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "AdministrationID");
                if (administrationClaim != null)
                { 
                    AdministrationID = Convert.ToInt32(administrationClaim.Value);
                }
                var publicIdentifier = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "Identifier");
                if (publicIdentifier != null && !string.IsNullOrEmpty(publicIdentifier.Value))
                {
                    PublicUserIdentifier = publicIdentifier.Value;
                }
                var publicIdentifierType = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "IdentifierType");
                if (publicIdentifierType != null && !string.IsNullOrEmpty(publicIdentifierType.Value))
                {
                    PublicUserIdentifierType = publicIdentifierType.Value;
                }
                var roleClaims = claimsPrincipal.Claims.Where(c => c.Type == "RoleID").Select(c => c.Value);
                if (roleClaims != null)
                {
                    RoleID = roleClaims.Select(int.Parse).ToArray();
                }
                var roleTypeClaims = claimsPrincipal.Claims.Where(c => c.Type == JwtClaimTypes.Role).Select(c => c.Value);
                if (roleClaims != null)
                {
                    Role = roleTypeClaims.ToArray();
                }
                var userNameClaim = claimsPrincipal.Claims.Where(c => c.Type == "UserName").Select(c => c.Value).SingleOrDefault();
                if (userNameClaim != null)
                {
                    UserName = userNameClaim;
                }
            }
        }

        public int? AdministrationID { get; private set; }

        public string[] Role { get; private set; }

        public int? UserId { get; private set; }

        public string PublicUserIdentifier { get; private set; }

        public string PublicUserIdentifierType { get; private set; }

        public int[] RoleID { get; private set; }

        public bool IsGlobalAdmin => Role.Contains("GLOBAL_ADMIN");

        public bool IsAdmin => Role.Contains("ADMIN");

        public bool IsPublic => Role.Contains("PUBLIC");

        public string UserName { get; private set; }
    }
}
