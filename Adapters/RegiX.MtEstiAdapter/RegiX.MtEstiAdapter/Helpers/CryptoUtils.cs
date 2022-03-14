using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.MtEstiAdapter.Helpers
{
    // Important: Copied from ESTI.Common
    public class CryptoUtils
    {
        private static readonly string EncryptionDelimiter = "_";
        private static readonly string RegistryPath = @"SOFTWARE\ESTI";
        private static readonly string RegistryAlias = "EncryptedAesKey";

        internal static string GetSubUin(string uin)
        {
            if (string.IsNullOrEmpty(uin))
            {
                return uin;
            }

            var parts = uin.Split('-').Take(2);
            var subUin = string.Join("-", parts);
            return subUin;
        }

        internal static string EncryptField(string text, string entropy)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(entropy))
            {
                return null;
            }

            var fieldToEncrypt = text + EncryptionDelimiter + entropy;
            var result = CryptoUtils.EncryptString(fieldToEncrypt);
            return result;
        }

        private static string EncryptString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }

            byte[] aesKey = ExtractProtectedKey();
            byte[] aesIv = GetInitializationVector(aesKey);

            // Use symmetric key to encrypt the input
            byte[] encrypted = EncryptAes(input, aesKey, aesIv);
            string encryptedText = Convert.ToBase64String(encrypted);
            return encryptedText;
        }

        private static byte[] EncryptAes(string plainText, byte[] key, byte[] IV)
        {
            byte[] encrypted;
            using (AesManaged aes = new AesManaged())
            {
                ICryptoTransform encryptor = aes.CreateEncryptor(key, IV);
                using (MemoryStream ms = new MemoryStream())
                {
                    // Create crypto stream using the CryptoStream class. This class is the key to encryption 
                    // and encrypts and decrypts data from any given stream. In this case, we will pass a memory stream to encrypt    
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        // Create StreamWriter and write data to a stream    
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }
                        encrypted = ms.ToArray();
                    }
                }
            }

            return encrypted;
        }

        private static byte[] GetInitializationVector(byte[] aesKey)
        {
            int ivLength = 16;
            string key = Convert.ToBase64String(aesKey);
            if (key.Length > ivLength)
            {
                return Encoding.UTF8.GetBytes(key.Substring(0, ivLength));
            }

            return Encoding.UTF8.GetBytes(key);
        }

        private static byte[] ExtractProtectedKey()
        {
            // Extract key from LocalMachine registry
            using (var registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            {
                var subKey = registryKey.OpenSubKey(RegistryPath);
                if (subKey == null)
                {
                    string message = string.Format(@"Registry key {0}\{1} cannot be found", registryKey, RegistryPath);
                    throw new ArgumentException(message);
                }

                var aesKey = subKey.GetValue(RegistryAlias).ToString();
                subKey.Dispose();

                var result = Convert.FromBase64String(aesKey);
                return result;
            }
        }
    }
}
