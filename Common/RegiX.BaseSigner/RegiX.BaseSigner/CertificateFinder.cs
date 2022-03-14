using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TechnoLogica.RegiX.BaseSigner
{
    /// <summary>
    /// Used to locate a X509 certificate. Application settings are used for the retrieval of configuration values.
    /// </summary>
    [Export(typeof(ICertificateFinder<X509Certificate2>))]
    class CertificateFinder : ICertificateFinder<X509Certificate2>
    {
        /// <summary>
        /// Locates the certificate and returns an instance
        /// </summary>
        /// <returns>Instance of a certificate</returns>
        public X509Certificate2 GetCertificate()
        {
            X509Certificate2 cert = GetX509Certificate(GetCertificateFindValue(), GetCertificateStoreName(), GetCertificateStoreLocation(), GetCertificateX509FindType());
            return cert;
        }

        /// <summary>
        /// Helper method for locating the ceritifcate
        /// </summary>
        /// <param name="findValue">Value to find</param>
        /// <param name="storeName">Name of the store</param>
        /// <param name="storeLocation">Location of the store</param>
        /// <param name="findType">Find type</param>
        /// <returns>The retrieved certificate</returns>
        public static X509Certificate2 GetX509Certificate(object findValue, StoreName storeName, StoreLocation storeLocation, X509FindType findType)
        {
            // Try to open the store.
            X509Store certStore = new X509Store(storeName, storeLocation);

            certStore.Open(OpenFlags.ReadOnly);
            // Find the certificate that matches the thumbprint.
            X509Certificate2Collection certCollection = certStore.Certificates.Find(findType, findValue, false);
            certStore.Close();

            // Check to see if our certificate was added to the collection. If no, throw an error, if yes, create a certificate using it.
            if (0 == certCollection.Count)
            {
                throw new Exception(String.Format("Certificate {0} not found in {1}, {2}.", findValue, storeName.ToString(), storeLocation.ToString()));
            }
            return certCollection[0];
        }

        /// <summary>
        /// Retrievs the certificate store name
        /// </summary>
        /// <returns>Retrieved certificate store name</returns>
        public static StoreName GetCertificateStoreName()
        {
            return (StoreName)Enum.Parse(typeof(StoreName), ConfigurationManager.AppSettings["CertificateStoreName"], true);
        }

        /// <summary>
        /// Retrieves certificate find value
        /// </summary>
        /// <returns>Retrieved certificate find value</returns>
        public static object GetCertificateFindValue()
        {
            return ConfigurationManager.AppSettings["CertificateFindValue"];

        }

        /// <summary>
        /// Retrieves certificate find type
        /// </summary>
        /// <returns>Retrieved find type</returns>
        public static X509FindType GetCertificateX509FindType()
        {
            return (X509FindType)Enum.Parse(typeof(X509FindType), ConfigurationManager.AppSettings["CertificateX509FindType"], true);

        }

        /// <summary>
        /// Retrieves certificate store location
        /// </summary>
        /// <returns>Retrieved certificate store location</returns>
        public static StoreLocation GetCertificateStoreLocation()
        {
            return (StoreLocation)Enum.Parse(typeof(StoreLocation), ConfigurationManager.AppSettings["CertificateStoreLocation"], true);
        }
    }
}
