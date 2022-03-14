//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using TechnoLogica.RegiX;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.NKPDAdapter;
//using TechnoLogica.RegiX.NKPDAdapter.AdapterService;
//using TechnoLogica.RegiX.Common.Utils;
//using System.Collections.Generic;
//using System.IO;
//using TechnoLogica.RegiX.Common.DataContracts;
//using System.Xml;
//using System.Linq;

//namespace RegiX.NKPDAdapterTests
//{
//    [TestClass]
//    public class NKPDAdapterTests
//    {
//        [TestMethod]
//        public void NKPDAdapterTest_CheckHealthCheckAndParamtersTest()
//        {
//            NKPDAdapter adapter = new NKPDAdapter();
//            //test GetParameters , and ConnectionString
//            var connectionString = adapter.GetParameters().ParameterList.Where(p => p.Key == TechnoLogica.RegiX.Common.Constants.ConnectionStringParameterKeyName).FirstOrDefault();
//            //test SetParameter
//            adapter.SetParameter(TechnoLogica.RegiX.Common.Constants.ConnectionStringParameterKeyName, connectionString.CurrentValue);
//            //test HCfunctions
//            var hcFunctions = adapter.GetHealthCheckFunctions();
//            hcFunctions.HealthInfosList.ForEach(f => adapter.CheckHealthFunction(f.Key));
//            Assert.IsTrue(true);
//        }

//        [TestMethod]
//        public void NKPDAdapterTest_CheckRegisterConnection()
//        {
//            NKPDAdapter adapter = new NKPDAdapter();
//            string result = adapter.CheckRegisterConnection();
//            Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
//        }

//        [TestMethod]
//        public void NKPDAdapter_TestAllNKPDSearch()
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

//            NKPDAdapter nkpAdapter = new NKPDAdapter();
//            var accessMatrix = AccessMatrix.CreateForType(typeof(AllNKPDDataType));
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
//            DateTime validDate = DateTime.Now;

//            var result = nkpAdapter.GetNKPDAllData(new AllNKPDDataSearchType() { ValidDate = validDate }, accessMatrix, additionalParameters);
//            string xml = result.XmlSerialize();
//            using (StreamWriter outfile = new StreamWriter("AllNKPDData.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(xml);
//            }
//            XsltUtils.RunXsltAndWriteHtml("NKPDAdapter", "AllNKPDDataRequest", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("NKPDAdapter", "NKPD_allData", result.Data.Response.XmlSerialize());
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

//        [TestMethod]
//        public void NKPDAdapter_TestGetNKPDData()
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

//            NKPDAdapter nkpAdapter = new NKPDAdapter();
//            //var accessMatrix = AccessMatrix.LoadFromDictionary(
//            //    new Dictionary<string, bool>() 
//            //    { 
//            //        {"NKPD", true},
//            //        {"NKPD.Type", true},
//            //        {"NKPD.Code", true},
//            //        {"NKPD.Name", true},
//            //        {"NKPD.ClassCode", false },
//            //        {"NKPD.SubclassCode", true },
//            //        {"NKPD.GroupCode", false },
//            //        {"NKPD.IndividualGroupCode", true },
//            //        {"NKPD.EducationLevelCode", true }

//            //    }
//            //    );

//            var accessMatrix = AccessMatrix.CreateForType(typeof(NKPDDataType));
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

//            DateTime validDate = DateTime.Now;
//            string code = "1";
//            string name = "рък";
//            var filterResult = nkpAdapter.GetNKPDData(new NKPDDataSearchType() { ValidDate = validDate, Code = code, Name = name }, accessMatrix, additionalParameters);
//            string xml = filterResult.XmlSerialize();
//            using (StreamWriter outfile = new StreamWriter("NKPDData.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(xml);
//            }

//            XsltUtils.RunXsltAndWriteHtml("NKPDAdapter", "NKPDDataRequest", filterResult.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("NKPDAdapter", "NKPD_responseData", filterResult.Data.Response.XmlSerialize());
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
