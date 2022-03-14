using RegiX.Core.STSIntegration.Properties;
using System;
using System.ComponentModel.Composition;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.Net.Security;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text.RegularExpressions;
using System.Xml;
using TechnoLogica.RegiX.Core.Helpers.Interfaces;

namespace TechnoLogica.RegiX.Core.Helpers
{
    /// <summary>
    /// Помощен клас за връзка с STS-а на еАвт-а.
    /// </summary>
    [Export(typeof(ISTSHelper))]
    public class STSHelper : ISTSHelper
    {
        /// <summary>
        /// Logger
        /// </summary>
        private static readonly log4net.ILog Logger =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly string SecurityHeaderName = "Security";
        private static readonly string SecurityHeaderNamespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401wss-wssecurity-secext-1.0.xsd";
        private static readonly string WSValidateRequestType = "http://docs.oasis-open.org/ws-sx/ws-trust/200512/Validate";
        private static readonly string WSTokenType = "http://docs.oasis-open.org/ws-sx/ws-trust/200512/RSTR/Status";
        private static readonly string WSValidStatusCode = "http://docs.oasis-open.org/ws-sx/ws-trust/200512/status/valid";
        private static readonly string Saml2Name = "saml2";
        private static readonly string Saml2NameSpace = "urn:oasis:names:tc:SAML:2.0:assertion";

        /// <summary>
        /// Извличане на OID от SAML токен
        /// </summary>
        /// <returns>Извлеченият OID</returns>
        public string ExtractOIDFromSAML()
        {
            int headerExists = -1;
            XmlElement samlAssertion = null;
            GenericXmlSecurityToken token = null;
            bool isValidToken = true;
            string oid = string.Empty;
            try
            {
                headerExists =
                       OperationContext.Current.IncomingMessageHeaders.FindHeader(
                           SecurityHeaderName,
                           SecurityHeaderNamespace
                       );
                if (headerExists != -1)
                {
                    samlAssertion =
                       OperationContext.Current.IncomingMessageHeaders.GetHeader<XmlElement>(
                           SecurityHeaderName,
                           SecurityHeaderNamespace
                       );

                    token = new GenericXmlSecurityToken(samlAssertion, null, DateTime.Now, DateTime.Now.AddMinutes(10), null, null, null);


                    if (Settings.Default.STSValidationEnable)
                    {
                        var validationResult = ValidateToken(token);
                        isValidToken = validationResult.Status.Code == WSValidStatusCode;
                    }
                    if (isValidToken)
                    {
                        XmlNamespaceManager nsmgr = new XmlNamespaceManager(token.TokenXml.OwnerDocument.NameTable);
                        nsmgr.AddNamespace(Saml2Name, Saml2NameSpace);
                        var nameID = token.TokenXml.SelectNodes("//saml2:Subject//saml2:NameID", nsmgr);///saml2:Assertion
                        if (nameID.Count == 1)
                        {
                            string nameIDValue = nameID[0].InnerText;
                            Match match = Regex.Match(nameIDValue, "OID:(.[^,]*)");
                            oid = match.Groups[1].Value;
                            return oid;

                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Logger.Error(
                   new
                   {
                       OperationName = "Exception in ExtractOIDFromSAML",
                       HeaderExists = headerExists,
                       SamlAssertionOuterXml = samlAssertion.OuterXml,
                       SamlAssertionInnterXml = samlAssertion.InnerXml,
                       Token = token,
                       IsValidToken = isValidToken,
                       Oid = oid,
                       STSValidationEnable = Settings.Default.STSValidationEnable
                   }, ex);
                return null;
            }
        }

        /// <summary>
        /// Вализиране на токен
        /// </summary>
        /// <param name="token">Токен за валидация</param>
        /// <returns>Резултат от валидацията</returns>
        private RequestSecurityTokenResponse ValidateToken(GenericXmlSecurityToken token)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
             (se, cert, chain, sslerror) =>
             {
                 //Trust all certificates
                 return true;
             };

            //CustomBinding binding = new CustomBinding("STS_Binding");

            BasicHttpBinding binding = new BasicHttpBinding("Validate_Binding");

            var endpointAddress =
                new EndpointAddress(
                    new Uri(Settings.Default.STSAddress),
                    EndpointIdentity.CreateDnsIdentity(Settings.Default.STSIdentity)
                );

            WSTrustChannelFactory trustChannelFactory = new WSTrustChannelFactory(binding, endpointAddress);
            if (Settings.Default.STSProtectionLevel == "Sign")
            {
                trustChannelFactory.Endpoint.Contract.ProtectionLevel = ProtectionLevel.Sign;
            }

            trustChannelFactory.Credentials.ServiceCertificate.SetDefaultCertificate(
                Settings.Default.STSServiceCertificateStoreLocation,
                Settings.Default.STSServiceCertificateStoreName,
                Settings.Default.STSServiceCertificateX509FindType,
                Settings.Default.STSServiceCertificateValue
            );

            trustChannelFactory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;

            if (Settings.Default.STSClientCertificateValue != "NoCertificate")
            {
                trustChannelFactory.Credentials.ClientCertificate.SetCertificate(
                    Settings.Default.STSClientCertificateStoreLocation,
                    Settings.Default.STSClientCertificateStoreName,
                    Settings.Default.STSClientCertificateX509FindType,
                    Settings.Default.STSClientCertificateValue
                );
            }

            trustChannelFactory.TrustVersion = TrustVersion.WSTrust13;

            WSTrustChannel channel = (WSTrustChannel)trustChannelFactory.CreateChannel();

            var validationResult =
                   channel.Validate(
                           new RequestSecurityToken()
                           {
                               RequestType = WSValidateRequestType,
                               TokenType = WSTokenType,
                               ValidateTarget = new SecurityTokenElement(token)
                           }
                   );
            return validationResult;
        }
    }
}
