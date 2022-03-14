using IdentityModel;
using RegiX.Info.Repositories;
using System;
using System.Linq;
using System.Security.Claims;

namespace RegiX.Info.API
{
    public class ConsumerContext : IConsumerContext
    {
        public ConsumerContext(ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal != null)
            {
                var subjectClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == JwtClaimTypes.Subject);
                if (subjectClaim != null)
                {
                    UserId = int.Parse(subjectClaim.Value);
                }
                var consumerProfileClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "ConsumerProfileId");
                if (consumerProfileClaim != null)
                {
                    ConsumerProfileID = Convert.ToInt32(consumerProfileClaim.Value);
                }
            }
        }
        public int? UserId { get; private set; }

        public decimal? ConsumerProfileID { get; private set; }
    }
}
