using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using TechnoLogica.Authentication.Common;
using TechnoLogica.Authentication.EAuth.XSD;

namespace TechnoLogica.Authentication.EAuth
{
    public static class Utils
    {
        private const string SamlStatusSuccess = "urn:oasis:names:tc:SAML:2.0:status:Success";
        private const string SamlProtocolBinding = "urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST";

        public static AuthnRequestType GenerateNewSamlRequest(this EAuthOptions options, HttpContext context)
        {
            var result = new AuthnRequestType();

            result.ID = "a" + Guid.NewGuid().ToString().Replace("-", "");
            result.Version = "2.0";
            result.IssueInstant = DateTime.UtcNow;
            result.ProtocolBinding = SamlProtocolBinding;
            result.Destination = options.AuthorizationEndpoint;
            result.ForceAuthn = true;
            result.ForceAuthnSpecified = true;
            result.IsPassive = false;
            result.IsPassiveSpecified = true;
            result.ProviderName = options.InformationSystemName;
            result.AssertionConsumerServiceURL = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.PathBase}{options.CallbackPath}";
            result.Issuer = new NameIDType()
            {
                SPProvidedID = options.SystemProviderOID,
                Value = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.PathBase}{options.CallbackPath}"
        };
            result.Extensions = new ExtensionsType()
            {
                RequestedService = new RequestedServiceType()
                {
                    Service = options.RequestServiceOID,
                    Provider = options.SystemProviderOID,
                }
            };

            return result;
        }

        /// <summary>
        /// Validate required signature, if there is no signature then it is not valid
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static bool IsValidSignatureXml(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            if (SigningUtils.HasSignature(doc))
            {
                bool isValid = SigningUtils.ValidateXmlDocumentSignature(doc.DocumentElement);
                return isValid;
            }

            return false;
        }

        /// <summary>
        /// Validate required signature, if there is no signature then it is not valid
        /// Validating against public certificate if presented
        /// </summary>
        /// <param name="xml">signed xml</param>
        /// <param name="eauthCert">Validation certificate</param>
        /// <returns></returns>
        public static bool IsValidSignatureXml(string xml, X509Certificate2 eauthCert)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            if (SigningUtils.HasSignature(document))
            {
                bool isValid = SigningUtils.ValidateXmlDocumentSignature(document.DocumentElement, eauthCert);
                return isValid;
            }

            return false;
        }

        public static bool IsValidStatus(StatusCodeType statusCode)
        {
            if (statusCode == null)
            {
                return false;
            }

            var result = statusCode.Value == SamlStatusSuccess;
            return result;
        }

        public static string SignRequestWithCertificate(this EAuthOptions options, AuthnRequestType arg)
        {
            var ns = GetEAuthNamespaces();
            XmlElement signature = SigningUtils.CreateEAuthSignature(arg, options.ClientSystemCertificate, ns);
            return signature.OuterXml;
        }

        public static XmlSerializerNamespaces GetEAuthNamespaces()
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("saml", "urn:oasis:names:tc:SAML:2.0:assertion");
            ns.Add("egovbga", "urn:bg:egov:eauth:1.0:saml:ext");
            ns.Add("samlp", "urn:oasis:names:tc:SAML:2.0:protocol");
            return ns;
        }

        public static string ExtractEgn(XmlDocument samlResponse)
        {
            return ExtractAttribute(samlResponse, EAuthClaims.EGN, "NameID", "NameQualifier");
        }

        public static string ExtractName(XmlDocument samlResponse)
        {
            return ExtractAttribute(samlResponse, EAuthClaims.PersonNamesLatin);
        }

        public static string ExtractEmail(XmlDocument samlResponse)
        {
            return ExtractAttribute(samlResponse, EAuthClaims.EMail);
        }

        public static string ExtractAttribute(
            XmlDocument samlResponse, 
            string attribute, 
            string elementName = "Attribute",
            string attributeName = "Name")
        {
            var names = new XmlNamespaceManager(samlResponse.NameTable);
            names.AddNamespace("a", "urn:oasis:names:tc:SAML:2.0:assertion");
            var nameNodes =
                samlResponse.SelectNodes($"//a:{elementName}[@{attributeName}='{attribute}']", names);
            if (nameNodes != null && nameNodes.Count > 0)
            {
                return nameNodes.Item(0).InnerText;
            }
            else
            {
                return null;
            }
        }
    }
}
