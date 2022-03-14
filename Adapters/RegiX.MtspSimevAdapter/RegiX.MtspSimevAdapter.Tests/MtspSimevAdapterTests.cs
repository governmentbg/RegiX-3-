//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using TechnoLogica.RegiX.Common.DataContracts;
//using TechnoLogica.RegiX.MtspSimevAdapter.AdapterService;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using System.IO;
//using TechnoLogica.RegiX.Common.Utils;
//using System.Xml;
//using TechnoLogica.RegiX.MtspSimevAdapter;


//namespace RegiX.MtspSimevAdapterTests
//{
//    [TestClass]
//    public class MtspSimevAdapterTests
//    {
//        [TestMethod]
//        public void MtspSimevAdapterTests1()
//        {
//            TechnoLogica.RegiX.Common.TransportObject.CallContext context = new TechnoLogica.RegiX.Common.TransportObject.CallContext()
//            {
//                AdministrationOId = "https://trust-party-openid.com",
//                LawReason = "Тестване на RegiX",
//                ServiceURI = "1222-200030-12.12.2022",
//                Remark = "Забележки",
//                EmployeeAditionalIdentifier = "Карта номер 3",
//                EmployeeIdentifier = "test@tesactivedirectory.com",
//                EmployeeNames = "Тестов Потребител Потребител",
//                AdministrationName = "Българска агенция за Тестване",
//                EmployeePosition = "Старши експерт Отдел \"Тестване на интеграцията\"",
//                ResponsiblePersonIdentifier = "392309324",
//                ServiceType = "За проверовъчна дейност"
//            };
//            string oldcontext = context.ToString();

//            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//            additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext();// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            additionalParameters.CitizenEGN = "8888888888";
//            additionalParameters.ClientIPAddress = "111.111.111.111";
//            additionalParameters.ConsumerCertificateThumbprint = "###";
//            additionalParameters.EIDToken = "token123";
//            additionalParameters.EmployeeEGN = "11111111111111";
//            additionalParameters.OrganizationEIK = "12121212121";
//            additionalParameters.OrganizationUnit = "qqqqqq";
//            additionalParameters.SignResult = false;
//            additionalParameters.ReturnAccessMatrix = true;

//            MtspSimevAdapter adapter = new MtspSimevAdapter();
//            //adapter.SetParameter("WebServiceUrl", "http://localhost:1643/SimevAspServiceImpl.svc");
//            //adapter.SetParameter("WebServiceUrl", "https://customs.gravis.bg/simevsoa/soap/SimevAsp");
            
//            adapter.SetParameter("WebServiceUrl", "https://regix2-adapters.regix.tlogica.com:4434/RegiX.MtspSimevMockup/SimevAspServiceImpl.svc");
//            XmlElement requestString = File.ReadAllText(".\\TestData\\Request.xml").ToXmlElement();
            
//            MtspInfoFosterParentsRequest request = (MtspInfoFosterParentsRequest)requestString.Deserialize(typeof(MtspInfoFosterParentsRequest));
            
//            var accessMatrix = AccessMatrix.CreateForType(typeof(MtspInfoFosterParentsResponse));
//            var result = adapter.SendInfoForFosterParents(request, accessMatrix, additionalParameters);

//            string xml = result.XmlSerialize();

//            using (StreamWriter outfile = new StreamWriter("MtspSimevAdapter.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(xml);
//            }

//            //XsltUtils.RunXsltAndWriteHtml("MtspSimevAdapter", "RNSearchRequest", result.Data.Request.XmlSerialize());
//            //XsltUtils.RunXsltAndWriteHtml("MtspSimevAdapter", "RNSearchResponse", result.Data.Response.XmlSerialize());

//            XmlDocument doc = new XmlDocument();
//            doc.LoadXml(xml);
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
