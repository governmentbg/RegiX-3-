using IdentityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TechnoLogica.RegiX.Admin.Infrastructure;
using TechnoLogica.RegiX.Admin.Repositories;

namespace TechnoLogica.RegiX.Admin.API
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
                var roleTypeClaims = claimsPrincipal.Claims.Where(c => c.Type == JwtClaimTypes.Role).FirstOrDefault();
                if (roleTypeClaims != null)
                {
                    Role = roleTypeClaims.Value;
                }
                this.UserName = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "UserName")?.Value;
            }
        }

        public int? UserId { get; private set; }

        public decimal? AdministrationID { get; private set; }

        public string Role { get; private set; }

        public string UserName { get; private set; }
    }
}
