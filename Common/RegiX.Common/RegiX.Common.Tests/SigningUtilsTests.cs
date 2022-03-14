using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Common.Utils;

namespace RegiX.CommonTests
{
    [TestClass]
    public class SigningUtilsTests
    {
        //[TestMethod]
        //public void SignObject()
        //{
        //    ConfigurationManager.AppSettings["SignResponse"] = "true";
        //    ConfigurationManager.AppSettings["CertificateStoreName"] = "My";
        //    ConfigurationManager.AppSettings["CertificateFindValue"] = "05dd79c626a910f2b3f635bb23bd8aaa2e639ff7";
        //    ConfigurationManager.AppSettings["CertificateX509FindType"] = "FindByThumbprint";
        //    ConfigurationManager.AppSettings["CertificateStoreLocation"] = "CurrentUser";

        //    RoutesSearch routeSearch = new RoutesSearch();
        //    RoutesResponse routeResponse = new RoutesResponse();
        //    var result =
        //        SigningUtils.CreateAndSign<RoutesSearch, RoutesResponse>(
        //            routeSearch,
        //            routeResponse,
        //            AccessMatrix.CreateForType(typeof(RoutesResponse)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters() { SignResult = true });
        //    String serializedSignedXml = result.XmlSerialize();
        //    File.WriteAllText(@"c:\Users\dmitev\Desktop\SingedUtilsTestsSingedObject.xml", serializedSignedXml);


        //    XmlDocument docToValidate = new XmlDocument();
        //    docToValidate.LoadXml(serializedSignedXml);

        //    var signatureValidity = SigningUtils.ValidateXmlDocumentWithX509Certificate(docToValidate);
        //    Assert.IsTrue(signatureValidity);
        //}

        [TestMethod]
        public void NullAdditionalParameters()
        {
          SigningUtils.CreateAndSignNonGeneric(new object(), typeof(object), new object(), typeof(object), null, null, false);
        }

        [TestMethod]
        public void NullAdditionalParametersWithSign()
        {
            SigningUtils.CreateAndSignNonGeneric(new object(), typeof(object), new object(), typeof(object), null, null, true);
        }
    }
}
