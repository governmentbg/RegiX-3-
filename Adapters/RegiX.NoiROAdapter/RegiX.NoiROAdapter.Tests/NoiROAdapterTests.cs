//using System;
//using System.IO;
//using System.Xml;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using TechnoLogica.RegiX.Common.DataContracts;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.Common.Utils;
//using TechnoLogica.RegiX.NoiROAdapter;
//using TechnoLogica.RegiX.NoiROAdapter.AdapterService;

//namespace RegiX.NoiROAdapterTests
//{
//    [TestClass]
//    public class NoiROAdapterTests
//    {
//        [TestMethod]
//        public void NoiROAdapterTestPOVNPOB()
//        {
//            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//            additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",”ServiceType”:”За проверовъчна дейност”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",” UserAdministrationID”:”10.20.503.4”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            additionalParameters.CitizenEGN = "8888888888";
//            additionalParameters.ClientIPAddress = "111.111.111.111";
//            additionalParameters.ConsumerCertificateThumbprint = "###";
//            additionalParameters.EIDToken = "token123";
//            additionalParameters.EmployeeEGN = "11111111111111";
//            additionalParameters.OrganizationEIK = "12121212121";
//            additionalParameters.OrganizationUnit = "qqqqqq";
//            additionalParameters.SignResult = true;
//            additionalParameters.ReturnAccessMatrix = true;

//            POVNPOBRequestType request = new POVNPOBRequestType()
//                    {
//                        Identifier = "1111111110",
//                        IdentifierType = IdentifierType.ЕГН,
//                        DateFrom = new DateTime(2012, 8, 1),
//                        DateTo = new DateTime(2012, 9, 30)
//                    };

//            AccessMatrix matrix = AccessMatrix.CreateForType((typeof(POVNPOBResponseType)));

//            ROAdapter adapter = new ROAdapter();

//            var result = adapter.SearchDisabilityCompensationByCompensationPeriod(request, matrix, additionalParameters);

//            using (StreamWriter outfile = new StreamWriter("NoiROAdapterTestPOVNPOB.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(result.XmlSerialize());
//            }

//            XsltUtils.RunXsltAndWriteHtml("NoiROAdapter", "POVNPOBRequest", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("NoiROAdapter", "POVNPOBResponse", result.Data.Response.XmlSerialize());

//            XmlDocument doc = new XmlDocument();
//            doc.LoadXml(result.XmlSerialize());
//            if (SigningUtils.HasSignature(doc))
//            {
//                bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc);
//                if (isValid)
//                {
//                    Assert.IsTrue(true);
//                }
//            }
//            else
//            {
//                Assert.IsTrue(true);
//            }
//        }

//        [TestMethod]
//        public void NoiROAdapterTestPOVNVED()
//        {
//            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//            additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",”ServiceType”:”За проверовъчна дейност”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",” UserAdministrationID”:”10.20.503.4”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            additionalParameters.CitizenEGN = "8888888888";
//            additionalParameters.ClientIPAddress = "111.111.111.111";
//            additionalParameters.ConsumerCertificateThumbprint = "###";
//            additionalParameters.EIDToken = "token123";
//            additionalParameters.EmployeeEGN = "11111111111111";
//            additionalParameters.OrganizationEIK = "12121212121";
//            additionalParameters.OrganizationUnit = "qqqqqq";
//            additionalParameters.SignResult = true;
//            additionalParameters.ReturnAccessMatrix = true;

//            POVNVEDRequestType request = new POVNVEDRequestType()
//            {
//                Identifier = "1111111110",
//                IdentifierType = IdentifierType.ЕГН,
//                DateFrom = new DateTime(2012, 8, 1),
//                DateTo = new DateTime(2012, 9, 30)
//            };

//            AccessMatrix matrix = AccessMatrix.CreateForType(typeof(POVNVEDResponseType));

//            ROAdapter adapter = new ROAdapter();

//            var result = adapter.SearchDisabilityCompensationByPaymentPeriod(request, matrix, additionalParameters);

//            using (StreamWriter outfile = new StreamWriter("NoiROAdapterTestPOVNVED.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(result.XmlSerialize());
//            }

//            XsltUtils.RunXsltAndWriteHtml("NoiROAdapter", "POVNVEDRequest", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("NoiROAdapter", "POVNVEDResponse", result.Data.Response.XmlSerialize());

//            XmlDocument doc = new XmlDocument();
//            doc.LoadXml(result.XmlSerialize());
//            if (SigningUtils.HasSignature(doc))
//            {
//                bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc);
//                if (isValid)
//                {
//                    Assert.IsTrue(true);
//                }
//            }
//            else
//            {
//                Assert.IsTrue(true);
//            }
//        }

//        [TestMethod]
//        public void NoiROAdapterTestPOBPOB()
//        {
//            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//            additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",”ServiceType”:”За проверовъчна дейност”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",” UserAdministrationID”:”10.20.503.4”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            additionalParameters.CitizenEGN = "8888888888";
//            additionalParameters.ClientIPAddress = "111.111.111.111";
//            additionalParameters.ConsumerCertificateThumbprint = "###";
//            additionalParameters.EIDToken = "token123";
//            additionalParameters.EmployeeEGN = "11111111111111";
//            additionalParameters.OrganizationEIK = "12121212121";
//            additionalParameters.OrganizationUnit = "qqqqqq";
//            additionalParameters.SignResult = true;
//            additionalParameters.ReturnAccessMatrix = true;

//            POBPOBRequestType request = new POBPOBRequestType()
//            {
//                Identifier = "1111111110",
//                IdentifierType = IdentifierType.ЕГН,
//                DateFrom = new DateTime(2012, 8, 1),
//                DateTo = new DateTime(2012, 9, 30)
//            };

//            AccessMatrix matrix = AccessMatrix.CreateForType(typeof(POBPOBResponseType));

//            ROAdapter adapter = new ROAdapter();

//            var result = adapter.SearchUnemploymentCompensationByCompensationPeriod(request, matrix, additionalParameters);

//            using (StreamWriter outfile = new StreamWriter("NoiROAdapterTestPOBPOB.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(result.XmlSerialize());
//            }

//            XsltUtils.RunXsltAndWriteHtml("NoiROAdapter", "POBPOBRequest", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("NoiROAdapter", "POBPOBResponse", result.Data.Response.XmlSerialize());

//            XmlDocument doc = new XmlDocument();
//            doc.LoadXml(result.XmlSerialize());
//            if (SigningUtils.HasSignature(doc))
//            {
//                bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc);
//                if (isValid)
//                {
//                    Assert.IsTrue(true);
//                }
//            }
//            else
//            {
//                Assert.IsTrue(true);
//            }
//        }

//        [TestMethod]
//        public void NoiROAdapterTestPOBVED()
//        {
//            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//            additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",”ServiceType”:”За проверовъчна дейност”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",” UserAdministrationID”:”10.20.503.4”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            additionalParameters.CitizenEGN = "8888888888";
//            additionalParameters.ClientIPAddress = "111.111.111.111";
//            additionalParameters.ConsumerCertificateThumbprint = "###";
//            additionalParameters.EIDToken = "token123";
//            additionalParameters.EmployeeEGN = "11111111111111";
//            additionalParameters.OrganizationEIK = "12121212121";
//            additionalParameters.OrganizationUnit = "qqqqqq";
//            additionalParameters.SignResult = true;
//            additionalParameters.ReturnAccessMatrix = true;

//            POBVEDRequestType request = new POBVEDRequestType()
//            {
//                Identifier = "1111111110",
//                IdentifierType = IdentifierType.ЕГН,
//                DateFrom = new DateTime(2012, 8, 1),
//                DateTo = new DateTime(2012, 9, 30)
//            };

//            AccessMatrix matrix = AccessMatrix.CreateForType(typeof(POBVEDResponseType));

//            ROAdapter adapter = new ROAdapter();

//            var result = adapter.SearchUnemploymentCompensationByPaymentPeriod(request, matrix, additionalParameters);

//            using (StreamWriter outfile = new StreamWriter("NoiROAdapterTestPOBVED.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(result.XmlSerialize());
//            }

//            XsltUtils.RunXsltAndWriteHtml("NoiROAdapter", "POBVEDRequest", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("NoiROAdapter", "POBVEDResponse", result.Data.Response.XmlSerialize());

//            XmlDocument doc = new XmlDocument();
//            doc.LoadXml(result.XmlSerialize());
//            if (SigningUtils.HasSignature(doc))
//            {
//                bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc);
//                if (isValid)
//                {
//                    Assert.IsTrue(true);
//                }
//            }
//            else
//            {
//                Assert.IsTrue(true);
//            }
//        }
//    }
//}
