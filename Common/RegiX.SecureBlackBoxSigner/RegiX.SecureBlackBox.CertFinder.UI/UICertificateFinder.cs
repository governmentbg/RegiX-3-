using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoLogica.RegiX.BaseSigner;
using System.ComponentModel.Composition;
using SBX509;
using System.Security.Cryptography.X509Certificates;
using SBWinCertStorage;
using SBTypes;

namespace RegiX.SecureBlackBox.CertFinder.UI
{
    /// <summary>
    /// Implements a certificate finder using windows UI for certificate selection
    /// </summary>
    [Export(typeof(ICertificateFinder<TElX509Certificate>))]
    public class UICertificateFinder : ICertificateFinder<TElX509Certificate>
    {
        /// <summary>
        /// Retrieves the certificate
        /// </summary>
        /// <returns>Retrieved certificate</returns>
        public TElX509Certificate GetCertificate()
        {
            var store = new X509Store("MY", StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
            var collection = store.Certificates;
            var cert = X509Certificate2UI.SelectFromCollection(collection, "Изберете КЕП", "Изберете КЕП за подписване", X509SelectionFlag.SingleSelection);

            if (cert.Count == 1)
            {
                var systemStore = new TElWinCertStorage();
                systemStore.AccessType = TSBStorageAccessType.atCurrentUser;

                // Read from Store
                systemStore.SystemStores.BeginUpdate();
                try
                {
                    systemStore.SystemStores.Clear();
                    systemStore.SystemStores.Add("MY");
                }
                finally
                {
                    systemStore.SystemStores.EndUpdate();
                }

                TMessageDigest160 Digest = new TMessageDigest160();
                byte[] bytes = StringToByteArray(cert[0].Thumbprint);
                SBUtils.Unit.ByteArrayToDigest160(bytes, 0, ref Digest);

                int Index = systemStore.FindByHashSHA1(Digest);
                return systemStore.get_Certificates(Index);
            }
            else
            {
                return null;
            }
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
                Encoding.GetEncoding(
                    "us-ascii",
                    new EncoderReplacementFallback(string.Empty),
                    new DecoderExceptionFallback()
                );
            return encoder.GetString(encoder.GetBytes(dirty));
        }
    }
    [Export(typeof(ICertificateFinder<X509Certificate2>))]
    public class UICertificateFinderX : ICertificateFinder<X509Certificate2>
    {
        public X509Certificate2 GetCertificate()
        {
            throw new NotImplementedException();
        }
    }
}
