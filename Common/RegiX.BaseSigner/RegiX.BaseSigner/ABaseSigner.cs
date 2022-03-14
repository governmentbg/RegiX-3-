using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common.Utils;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace TechnoLogica.RegiX.BaseSigner
{
    /// <summary>
    /// Abstract implementation of the signer interface. 
    /// </summary>
    public abstract class ABaseSigner : ISigner
    {

        /// <summary>
        /// Logger
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// AES key size
        /// </summary>
        private static readonly int AES_KEY_SIZE = 256;

        /// <summary>
        /// AES block size
        /// </summary>e
        private static readonly int AES_BLOCK_SIZE = 128;

        /// <summary>
        /// AES cipher mode
        /// </summary>
        private static readonly CipherMode AES_CIPHER_MODE = CipherMode.CBC;

        /// <summary>
        /// AES padding
        /// </summary>
        private static readonly PaddingMode AES_PADDING = PaddingMode.PKCS7;

        /// <summary>
        /// RSA encryption padding
        /// </summary>
        private static readonly RSAEncryptionPadding RSA_ENCRYPTION_PADDING = RSAEncryptionPadding.OaepSHA256;

        /// <summary>
        /// Used to resolve X509 certificate
        /// </summary>
        [Import]
        protected ICertificateFinder<X509Certificate2> X509CertificateFinder { get; set; }

        /// <summary>
        /// Digitally signs a CommonSignedResponse object. The signature is stored in the Signature
        /// property of the CommonSignedResponse argument.
        /// </summary>
        /// <typeparam name="A">Request type</typeparam>
        /// <typeparam name="R">Response Type</typeparam>
        /// <param name="arg">A CommonSignedResponse object</param>
        public abstract void SignXmlDocumentWithCertificate<A, R>(CommonSignedResponse<A, R> arg);

        /// <summary>
        /// Digitally signs the provided XmlElement (Only the element with id data is signed)
        /// </summary>
        /// <param name="element">XmlElement contaiing the data element</param>
        /// <returns>Signature</returns>
        public abstract XmlElement Sign(XmlElement element);

        /// <summary>
        ///  Digitally signs a ServiceResultData object. The signature is stored in the Signature 
        ///  element. If multiple signatures are present the Signature element contains a sequence 
        ///  of signatures. If the response is PDF - the PDF itself is signed (the siganture 
        ///  is embeded in the PDF).
        /// </summary>
        /// <param name="serviceResultData">Object to be signed</param>
        public void Sign(ServiceResultData serviceResultData)
        {
            if (serviceResultData?.Data?.Response?.Response?.Name == nameof(BinaryArgument))
            {
                var binaryArgument = serviceResultData.Data.Response.Response.Deserialize<BinaryArgument>();         
                var signedPDF = SignPDF(binaryArgument.Binary);
                binaryArgument.Binary = signedPDF;
                serviceResultData.Data.Response.Response = binaryArgument.XmlSerialize().ToXmlElement();
   
            }
            else if (serviceResultData?.Data != null)
            {
                var signature = Sign(serviceResultData.Data.XmlSerialize().ToXmlElement());
                AddSignature(serviceResultData, signature);
            }
        }

        /// <summary>
        /// Digitally signs a PDF document
        /// </summary>
        /// <param name="pdf">PDF document to be ditially signed</param>
        /// <returns>Digitally signed PDF document</returns>
        public abstract byte[] SignPDF(byte[] pdf);

        /// <summary>
        /// Encrypts the provided data with the provided key
        /// </summary>
        /// <param name="encodedKey">Key</param>
        /// <param name="data">Data to be encrypted</param>
        /// <returns>Encrypted data</returns>
        public byte[] Encrypt(byte[] encodedKey, byte[] data)
        {
            RijndaelManaged aesEncryption = GetAESEncryption(encodedKey);
            ICryptoTransform encryptor = aesEncryption.CreateEncryptor();
            return encryptor.TransformFinalBlock(data, 0, data.Length);
        }

        /// <summary>
        /// Decrypts the provided cipher data with the provided key
        /// </summary>
        /// <param name="encodedKey">Key</param>
        /// <param name="encryptedData">Data to be decrypted</param>
        /// <returns>Decrypted data</returns>
        public byte[] Decrypt(byte[] encodedKey, byte[] encryptedData)
        {
            RijndaelManaged aesEncryption = GetAESEncryption(encodedKey);
            ICryptoTransform decryptor = aesEncryption.CreateDecryptor();
            return decryptor.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
        }

        /// <summary>
        /// Generates new symetric key
        /// </summary>
        /// <returns>Generated symetric key</returns>
        public byte[] GenerateSymeticKey()
        {
            RijndaelManaged aesEncryption = new RijndaelManaged();
            aesEncryption.KeySize = AES_KEY_SIZE;
            aesEncryption.BlockSize = AES_BLOCK_SIZE;
            aesEncryption.Mode = AES_CIPHER_MODE;
            aesEncryption.Padding = AES_PADDING;
            aesEncryption.GenerateIV();
            string ivStr = Convert.ToBase64String(aesEncryption.IV);
            aesEncryption.GenerateKey();
            string keyStr = Convert.ToBase64String(aesEncryption.Key);
            string completeKey = ivStr + "," + keyStr;
            return Encoding.UTF8.GetBytes(completeKey);
        }

        /// <summary>
        /// Encrypts a symetric key
        /// </summary>
        /// <param name="key">Symetric key to be encrypted</param>
        /// <returns>Encrypted symetric key</returns>
        public byte[] EncryptKey(byte[] key)
        {
            using (var rsa = GetPublicKey())
            {
                return rsa.Encrypt(key, RSAEncryptionPadding.Pkcs1);
            }
        }

        /// <summary>
        /// Decrypts a symetric key
        /// </summary>
        /// <param name="encryptedKey">Ciphered key to be decrypted</param>
        /// <returns>Decrypted symetric key</returns>
        public byte[] DecryptKey(byte[] encryptedKey)
        {
            using (var rsa = GetPrivateKey())
            {
                return rsa.Decrypt(encryptedKey, RSAEncryptionPadding.Pkcs1);
            }
        }

        /// <summary>
        /// Retrieve the public key of the signer
        /// </summary>
        /// <returns>Retrieved public key</returns>
        public string GetPublicKeyString()
        {
            X509Certificate2 cert = X509CertificateFinder.GetCertificate();
            return cert.GetPublicKeyString();
        }

        /// <summary>
        /// Validates the digital signature of an XmlElement
        /// </summary>
        /// <param name="doc">Digitally sigend XmlElement</param>
        /// <returns>If the signature of the XmlElement is valid or not</returns>
        public virtual bool Validate(XmlElement doc)
        {
            try
            {
                return Validate(new SignedXml(doc), doc.GetElementsByTagName("Signature")[0]);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Validates the digital signature of an XmlDocument
        /// </summary>
        /// <param name="doc">Digitally sigend XmlDocument</param>
        /// <returns>If the signature of the XmlDocument is valid or not</returns>
        public virtual bool Validate(XmlDocument doc)
        {
            try
            {
                return Validate(new SignedXml(doc), doc.GetElementsByTagName("Signature")[0]);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Validate a SigneXml agains teh provided signature
        /// </summary>
        /// <param name="signedXml">Signed XML</param>
        /// <param name="signatureNode">Signature node</param>
        /// <returns>If the siganture is valid</returns>
        private bool Validate(SignedXml signedXml, XmlNode signatureNode)
        {
            signedXml.LoadXml((XmlElement)signatureNode);
            return signedXml.CheckSignature();
        }

        /// <summary>
        /// Retrieves the private key of the cerificate used for signing
        /// </summary>
        /// <returns>RSA private key</returns>
        protected virtual RSA GetPrivateKey()
        {
            return X509CertificateFinder.GetCertificate().GetRSAPrivateKey();
        }

        /// <summary>
        /// Retrieves the public key of the cerificate used for signing
        /// </summary>
        /// <returns>RSA public key</returns>
        protected virtual RSA GetPublicKey()
        {
            return X509CertificateFinder.GetCertificate().GetRSAPublicKey();
        }

        /// <summary>
        /// Retrieves a Rijndael algorithm instance
        /// </summary>
        /// <param name="encodedKey">Encoded key</param>
        /// <returns>Instance of Rijndael algorithm</returns>
        private RijndaelManaged GetAESEncryption(byte[] encodedKey)
        {
            string decodedKey = Encoding.UTF8.GetString(encodedKey);
            string[] splittedKey = decodedKey.Split(',');
            string base64IV = splittedKey[0];
            string base64Key = splittedKey[1];

            RijndaelManaged aesEncryption = new RijndaelManaged();
            aesEncryption.KeySize = AES_KEY_SIZE;
            aesEncryption.BlockSize = AES_BLOCK_SIZE;
            aesEncryption.Mode = AES_CIPHER_MODE;
            aesEncryption.Padding = AES_PADDING;
            aesEncryption.IV = Convert.FromBase64String(base64IV);
            aesEncryption.Key = Convert.FromBase64String(base64Key);

            return aesEncryption;
        }

        /// <summary>
        /// Adds signature to a ServiceResultData object. Addition of multiple
        /// signatures is possible. If there is a single Signature it is at the root level.
        /// For multiple signatures - all are children of the Signature root element.
        /// </summary>
        /// <param name="arg">ServiceResultData object</param>
        /// <param name="signature">Signature to be added</param>
        protected void AddSignature(ServiceResultData arg, XmlElement signature)
        {
            if (arg.Signature == null)
            {
                arg.Signature = signature;
            }
            else
            {
                if (arg.Signature.HasChildNodes && arg.Signature.FirstChild.Name == "Signature")
                {
                    var insertedNewSignatureNode = arg.Signature.OwnerDocument.ImportNode(signature, true);
                    arg.Signature.AppendChild(insertedNewSignatureNode);
                }
                else
                {
                    XmlDocument signatureDocument = new XmlDocument();
                    var rootSignature = signatureDocument.CreateElement("Signature", "http://egov.bg/RegiX/SignedData");
                    signatureDocument.AppendChild(rootSignature);
                    var insertedExistingNode = signatureDocument.ImportNode(arg.Signature, true);
                    rootSignature.AppendChild(insertedExistingNode);
                    var insertedNewSignatureNode = signatureDocument.ImportNode(signature, true);
                    rootSignature.AppendChild(insertedNewSignatureNode);
                    arg.Signature = signatureDocument.DocumentElement;
                }
            }
        }

        /// <summary>
        /// Adds signature to a CommonSignedResponse object. Addition of multiple
        /// signatures is possible. If there is a single Signature it is at the root level.
        /// For multiple signatures - all are children of the Signature root element.
        /// </summary>
        /// <typeparam name="A">Request type</typeparam>
        /// <typeparam name="R">Response type</typeparam>
        /// <param name="arg">Object for signing</param>
        /// <param name="signature">Signature to be added</param>
        protected void AddSignature<A, R>(CommonSignedResponse<A, R> arg, XmlElement signature)
        {
            if (arg.Signature == null)
            {
                arg.Signature = signature;
            }
            else
            {
                if (arg.Signature.HasChildNodes && arg.Signature.FirstChild.Name == "Signature")
                {
                    var insertedNewSignatureNode = arg.Signature.OwnerDocument.ImportNode(signature, true);
                    arg.Signature.AppendChild(insertedNewSignatureNode);
                }
                else
                {
                    XmlDocument signatureDocument = new XmlDocument();
                    var rootSignature = signatureDocument.CreateElement("Signature");
                    signatureDocument.AppendChild(rootSignature);
                    var insertedExistingNode = signatureDocument.ImportNode(arg.Signature, true);
                    rootSignature.AppendChild(insertedExistingNode);
                    var insertedNewSignatureNode = signatureDocument.ImportNode(signature, true);
                    rootSignature.AppendChild(insertedNewSignatureNode);
                    arg.Signature = signatureDocument.DocumentElement;
                }
            }
        }
    }
}
