using System;
using System.ComponentModel.Composition;
using System.IdentityModel.Claims;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using TechnoLogica.RegiX.Core.Helpers.Interfaces;

namespace TechnoLogica.RegiX.Core.Helpers
{
    /// <summary>
    /// Помощен клас за работа със сертификати
    /// </summary>
    [Export(typeof(ICertificateHelper))]
    public class CertificateHelper : ICertificateHelper
    {
        /// <summary>
        /// Logger
        /// </summary>
        private static readonly log4net.ILog Logger =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Извлича thumbprint на сертификат
        /// </summary>
        /// <param name="expectedSSLCertificatePlace">Място, където се очаква да бъде thumbprint-а на сертификата</param>
        /// <returns>Извлеченият thumbprint на сертификат</returns>
        public string ResolveCertificateThumbprint(ExpectedSSLCertificatePlace expectedSSLCertificatePlace)
        {
            switch (expectedSSLCertificatePlace)
            {
                case ExpectedSSLCertificatePlace.HeaderRequest:
                {
                    string certThumb = ExtractCertificateThumbprintFromHeader();
                    if (string.IsNullOrEmpty(certThumb))
                    {
                        certThumb = ExtractCertificateThumbprintFromRequest();
                    }
                    return certThumb;
                }
                case ExpectedSSLCertificatePlace.RequestHeader:
                {
                    string certThumb = ExtractCertificateThumbprintFromRequest();
                    if (string.IsNullOrEmpty(certThumb))
                    {
                        certThumb = ExtractCertificateThumbprintFromHeader();
                    }
                    return certThumb;
                }
                case ExpectedSSLCertificatePlace.HeaderOnly:
                {
                    return ExtractCertificateThumbprintFromHeader();
                }
                case ExpectedSSLCertificatePlace.RequestOnly:
                {
                    return ExtractCertificateThumbprintFromRequest();
                }
                case ExpectedSSLCertificatePlace.ThumbprintFromHeader:
                {
                    return ExtractThumbprintFromHeader();
                }
                case ExpectedSSLCertificatePlace.Nowhere:
                default:
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Retrieves client certificate thumbprint from request's header
        /// </summary>
        /// <returns>Retrieved thumbprint</returns>
        private string ExtractThumbprintFromHeader()
        {
            try
            {
                HttpRequestMessageProperty requestProperty = (HttpRequestMessageProperty)OperationContext.Current.IncomingMessageProperties[HttpRequestMessageProperty.Name];
                string value = requestProperty.Headers["cert_hash"];
                return value;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return string.Empty;
            }
        }

        /// <summary>
        /// Извлича thumbprint на сертификат от текущия ServiceSecurityContext
        /// </summary>
        /// <returns>Извлеченият thumbprint на сертификат</returns>
        private string ExtractCertificateThumbprintFromRequest()
        {
            string result = string.Empty;
            if (OperationContext.Current?.ServiceSecurityContext?.AuthorizationContext?.ClaimSets?.Count > 0)
            {
                try
                {
                    result = ((X509CertificateClaimSet)OperationContext.Current.ServiceSecurityContext.AuthorizationContext.ClaimSets[0]).X509Certificate.Thumbprint;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                }
            }
            return result;
        }

        /// <summary>
        /// Извлича thumbprint на сертификат от Header на заявка
        /// </summary>
        /// <returns>Извлеченият thumbprint на сертификат</returns>
        private string ExtractCertificateThumbprintFromHeader()
        {
            try
            {
                HttpRequestMessageProperty requestProperty = (HttpRequestMessageProperty)OperationContext.Current.IncomingMessageProperties[HttpRequestMessageProperty.Name];
                string value = requestProperty.Headers["SSL_CLIENT_CERT"];
                value = value.Replace("-----BEGIN CERTIFICATE----- ", "");
                value = value.Replace(" -----END CERTIFICATE-----", "");
                value = value.Replace(" ", "");
                byte[] array = Convert.FromBase64String(value);
                X509Certificate2 cert = new X509Certificate2(array);
                string certThumb = cert.Thumbprint;
                return certThumb;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return string.Empty;
            }
        }
    }
}
