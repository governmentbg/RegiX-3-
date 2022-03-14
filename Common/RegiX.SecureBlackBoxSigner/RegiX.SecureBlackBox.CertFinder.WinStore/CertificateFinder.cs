using SBTypes;
using SBWinCertStorage;
using SBX509;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TechnoLogica.RegiX.BaseSigner;

namespace TechnoLogica.RegiX.SecureBlackBox.CertFinder.WinStore
{

    /// <summary>
    /// Implements a certificate finder and timestamp server information.
    /// </summary>
    [Export(typeof(ICertificateFinder<TElX509Certificate>))]
    public class CertificateFinder : ICertificateFinder<TElX509Certificate>
    {
        /// <summary>
        /// Retrieves the certificate
        /// </summary>
        /// <returns>Retrieved certificate</returns>
        public TElX509Certificate GetCertificate()
        {
            var systemStore = new TElWinCertStorage();
            systemStore.AccessType = GetCertificateStoreLocation();
            systemStore.ReadOnly = true; // This property is crucial for openning computer store with no privileged account

            // Read from Store
            systemStore.SystemStores.BeginUpdate();
            try
            {
                systemStore.SystemStores.Clear();
                systemStore.SystemStores.Add(GetCertificateStoreName());
            }
            finally
            {
                systemStore.SystemStores.EndUpdate();
            }

            TMessageDigest160 Digest = new TMessageDigest160();
            byte[] bytes = StringToByteArray(GetCertificateFindValue());
            SBUtils.Unit.ByteArrayToDigest160(bytes, 0, ref Digest);

            int Index = systemStore.FindByHashSHA1(Digest);
            return systemStore.get_Certificates(Index);
        }

        /// <summary>
        /// Gets the bytes from a hex value
        /// </summary>
        /// <param name="hexValues">Hex value to get bytes from</param>
        /// <returns>Retrieved bytes</returns>
        private byte[] StringToByteArray(string hexValues)
        {
            //Cleaning string from app setting
            hexValues = ToAscii(hexValues);

            List<byte> byteList = new List<byte>();
            for (int i = 0; i < hexValues.Length - 1; i = i + 2)
            {
                // Convert the number expressed in base-16 to an integer and cast to byte. 
                byteList.Add((byte)(Convert.ToInt32(hexValues.Substring(i, 2), 16)));
            }
            return byteList.ToArray();
        }

        /// <summary>
        /// Converts the string to ASCII string
        /// </summary>
        /// <param name="dirty">Dirty string</param>
        /// <returns>Converted string</returns>
        private string ToAscii(string dirty)
        {
            //Cleans the string
            var encoder =
                ASCIIEncoding.GetEncoding(
                    "us-ascii",
                    new EncoderReplacementFallback(string.Empty),
                    new DecoderExceptionFallback()
                );
            return encoder.GetString(encoder.GetBytes(dirty));
        }

        /// <summary>
        /// Retrieve the certificate store name
        /// </summary>
        /// <returns></returns>
        public static string GetCertificateStoreName()
        {
            return ConfigurationManager.AppSettings["CertificateStoreName"];
        }

        /// <summary>
        /// Retrieves the certificate find value 
        /// </summary>
        /// <returns>Retrieved certificate find value</returns>
        public static string GetCertificateFindValue()
        {
            return ConfigurationManager.AppSettings["CertificateFindValue"];
        }

        /// <summary>
        /// Retrieves the certificate find type
        /// </summary>
        /// <returns>Retrieved certificate find type</returns>
        public static X509FindType GetCertificateX509FindType()
        {
            return (X509FindType)Enum.Parse(typeof(X509FindType), ConfigurationManager.AppSettings["CertificateX509FindType"], true);

        }

        /// <summary>
        /// Retrieves the certificate store location
        /// </summary>
        /// <returns>Retrieved certificate store location</returns>
        public static TSBStorageAccessType GetCertificateStoreLocation()
        {
            var storeLocation = (StoreLocation)Enum.Parse(typeof(StoreLocation), ConfigurationManager.AppSettings["CertificateStoreLocation"], true);
            switch (storeLocation)
            {
                case StoreLocation.CurrentUser:
                    {
                        return TSBStorageAccessType.atCurrentUser;
                    }
                case StoreLocation.LocalMachine:
                default:
                    {
                        return TSBStorageAccessType.atLocalMachine;
                    }
            }
        }
    }
}
