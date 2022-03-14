using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TechnoLogica.Authentication.EAuth
{
    public class EAuthOptions : RemoteAuthenticationOptions
    {
        /// <summary>
        /// Gets or sets the URI where the client will be redirected to authenticate.
        /// </summary>
        public string AuthorizationEndpoint { get; set; }

        public string InformationSystemName { get; set; }

        public string SystemProviderOID { get; set; }

        public string RequestServiceOID { get; set; }

        public X509Certificate2 ClientSystemCertificate { get; set; }

        public X509Certificate2 EAuthSystemCertificate { get; set; }


        /// <summary>
        ///  ?
        /// </summary>
        public string RedirectConsumerServiceURL { get; set; }

        public string RedirectErrorURL { get; set; }

        public EAuthOptions()
        {
            CallbackPath = "/EAuthCallback";
            AuthorizationEndpoint = EAuthDefaults.AuthorizationEndpoint;
            RequestServiceOID = EAuthDefaults.RequestServiceOID;
            SystemProviderOID = EAuthDefaults.SystemProviderOID;
            RedirectErrorURL = EAuthDefaults.RedirectErrorURL;
            Events = new RemoteAuthenticationEvents()
            { 
                OnRemoteFailure =
                    async (failureContext) => {
                        var redirectWithQuery = QueryHelpers.AddQueryString(RedirectErrorURL, failureContext.Properties.Items);
                        failureContext.Response.Redirect(redirectWithQuery);
                        failureContext.HandleResponse();
                    }
            };
        }
    }
}
