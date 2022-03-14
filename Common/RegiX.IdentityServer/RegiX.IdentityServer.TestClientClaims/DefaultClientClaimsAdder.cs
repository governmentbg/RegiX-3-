using IdentityServer4.Validation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel.Composition;
using System.Security.Claims;
using System.Threading.Tasks;
using TechnoLogica.Authentication.Common;

namespace RegiX.IdentityServer.TestClientClaims
{

    /// <summary>
    /// For Test purposes
    /// </summary>
    [Export(typeof(IAuthenticationProfile))]
    public class DefaultClientClaimsAdder : ICustomTokenRequestValidator, IAuthenticationProfile
    {
        public void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICustomTokenRequestValidator, DefaultClientClaimsAdder>();
        }

        public Task ValidateAsync(CustomTokenRequestValidationContext context)
        {
            switch (context.Result.ValidatedRequest.Client.ClientId)
            {
                case "testc-lient-globaladmin":
                    {
                        context.Result.ValidatedRequest.Client.AlwaysSendClientClaims = true;
                        context.Result.ValidatedRequest.ClientClaims.Add(new Claim("role", "GLOBAL_ADMIN"));
                        context.Result.ValidatedRequest.ClientClaims.Add(new Claim("AdministrationID", "0"));
                        context.Result.ValidatedRequest.ClientClaims.Add(new Claim("RoleID", "50"));
                        context.Result.ValidatedRequest.ClientClaims.Add(new Claim("sub", "1061"));
                        break;
                    }
                case "test-client-admin":
                    {
                        context.Result.ValidatedRequest.Client.AlwaysSendClientClaims = true;
                        context.Result.ValidatedRequest.ClientClaims.Add(new Claim("role", "ADMIN"));
                        context.Result.ValidatedRequest.ClientClaims.Add(new Claim("AdministrationID", "34"));
                        context.Result.ValidatedRequest.ClientClaims.Add(new Claim("RoleID", "1111"));
                        context.Result.ValidatedRequest.ClientClaims.Add(new Claim("sub", "34"));
                        break;
                    }
                case "test-client-public":
                    {
                        break;
                    }
                case "test-client-basic":
                    {
                        context.Result.ValidatedRequest.Client.AlwaysSendClientClaims = true;
                        context.Result.ValidatedRequest.ClientClaims.Add(new Claim("sub", "1063"));
                        context.Result.ValidatedRequest.ClientClaims.Add(new Claim("role", "BASIC"));
                        context.Result.ValidatedRequest.ClientClaims.Add(new Claim("RoleID", "74"));
                        context.Result.ValidatedRequest.ClientClaims.Add(new Claim("AdministrationID", "34"));
                        break;
                    }
                case "test-client-basicadmin":
                    {
                        context.Result.ValidatedRequest.Client.AlwaysSendClientClaims = true;
                        context.Result.ValidatedRequest.ClientClaims.Add(new Claim("role", "ADMIN"));
                        context.Result.ValidatedRequest.ClientClaims.Add(new Claim("role", "BASIC"));
                        context.Result.ValidatedRequest.ClientClaims.Add(new Claim("RoleID", "51"));
                        context.Result.ValidatedRequest.ClientClaims.Add(new Claim("RoleID", "74"));
                        context.Result.ValidatedRequest.ClientClaims.Add(new Claim("AdministrationID", "34"));
                        context.Result.ValidatedRequest.ClientClaims.Add(new Claim("sub", "1062"));
                        break;
                    }
                case "test-admin-admin":
                    {
                        context.Result.ValidatedRequest.Client.AlwaysSendClientClaims = true;
                        context.Result.ValidatedRequest.ClientClaims.Add(new Claim("role", "ADMIN"));
                        context.Result.ValidatedRequest.ClientClaims.Add(new Claim("AdministrationID", "10072"));
                        context.Result.ValidatedRequest.ClientClaims.Add(new Claim("sub", "3"));
                        break;
                    }
                case "test-admin-globaladmin":
                    {
                        context.Result.ValidatedRequest.Client.AlwaysSendClientClaims = true;
                        context.Result.ValidatedRequest.ClientClaims.Add(new Claim("role", "GLOBAL_ADMIN"));
                        context.Result.ValidatedRequest.ClientClaims.Add(new Claim("sub", "2"));
                        break;
                    }
            }
            return Task.FromResult(0);
        }
    }
}
