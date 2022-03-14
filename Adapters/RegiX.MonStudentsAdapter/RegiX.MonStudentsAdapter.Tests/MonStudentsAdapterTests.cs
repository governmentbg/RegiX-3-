//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.MonStudentsAdapter;
//using TechnoLogica.RegiX.MonStudentsAdapter.AdapterService;
//using System.IO;
//using TechnoLogica.RegiX.Common.Utils;
//using TechnoLogica.RegiX.Common.DataContracts;
//using TechnoLogica.RegiX.Common.AdapterCore;
//using System.Xml;
//using System.Linq;

//namespace RegiX.MonStudentsAdapterTests
//{
//    [TestClass]
//    public class MonStudentsAdapterTests
//    {
//        [TestMethod]
//        public void MonStudentsAdapter_CheckHealthCheckAndParamtersTest()
//        {
//            MonStudentsAdapter adapter = new MonStudentsAdapter();
//            //test GetParameters , and ConnectionString
//            var connectionString = adapter.GetParameters().ParameterList.Where(p => p.Key == TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName).FirstOrDefault();
//            //test SetParameter
//            adapter.SetParameter(TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName, connectionString.CurrentValue);
//            //test HCfunctions
//            var hcFunctions = adapter.GetHealthCheckFunctions();
//            string checkHealthFunctionResult = string.Empty;
//            hcFunctions.HealthInfosList.ForEach(f =>
//            {
//                checkHealthFunctionResult = checkHealthFunctionResult + f.Key + ":" + adapter.CheckHealthFunction(f.Key) + ";\r\n";
//            });
//            using (StreamWriter outfile = new StreamWriter("CheckHealthFunctions.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(checkHealthFunctionResult);
//            }
//            Assert.IsTrue(true);
//        }

//        [TestMethod]
//        public void MonStudentsAdapter_CheckRegisterConnection()
//        {
//            MonStudentsAdapter adapter = new MonStudentsAdapter();
//            string result = adapter.CheckRegisterConnection();
//            Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
//        }

//        [TestMethod]
//        public void GetChildStudentStatus_Test()
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
//            // "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            MonStudentsAdapter adapter = new MonStudentsAdapter();
//            var mockupServiceAdress = "http://localhost:50203/MonSoapService.svc";
//            adapter.SetParameter(TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName, mockupServiceAdress);
//            var accessMatrix = AccessMatrix.CreateForType(typeof(HigherEduStudentByStatusResponse));
//            HigherEduStudentByStatusRequestType searchCriteria = new HigherEduStudentByStatusRequestType()
//            {
//                StudentIdentifier = "SI123",
//                StudentStatus = StudentStatusType.active,
//            };

//            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//            additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            additionalParameters.CitizenEGN = "8888888888";
//            additionalParameters.ClientIPAddress = "111.111.111.111";
//            additionalParameters.ConsumerCertificateThumbprint = "###";
//            additionalParameters.EIDToken = "token123";
//            additionalParameters.EmployeeEGN = "11111111111111";
//            additionalParameters.OrganizationEIK = "12121212121";
//            additionalParameters.OrganizationUnit = "qqqqqq";
//            additionalParameters.SignResult = true;
//            additionalParameters.ReturnAccessMatrix = true;

//            var result = adapter.GetHigherEduStudentByStatus(searchCriteria, accessMatrix, additionalParameters);
//            string xml = result.Data.Response.XmlSerialize();
//            using (StreamWriter outfile = new StreamWriter("GetChildStudentStatus_Test.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(xml);
//            }
//            XsltUtils.RunXsltAndWriteHtml("MonStudentsAdapter", "HigherEduStudentByStatusRequest", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("MonStudentsAdapter", "HigherEduStudentByStatusResponse", result.Data.Response.XmlSerialize());

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
//        public void GetChildStudentStatus_NULL_Test()
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
//            // "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            MonStudentsAdapter adapter = new MonStudentsAdapter();
//            var accessMatrix = AccessMatrix.CreateForType(typeof(HigherEduStudentByStatusResponse));
//            HigherEduStudentByStatusRequestType searchCriteria = new HigherEduStudentByStatusRequestType()
//            {
//                StudentIdentifier = "test",
//                StudentStatus = StudentStatusType.active
//            };

//            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//            additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            additionalParameters.CitizenEGN = "8888888888";
//            additionalParameters.ClientIPAddress = "111.111.111.111";
//            additionalParameters.ConsumerCertificateThumbprint = "###";
//            additionalParameters.EIDToken = "token123";
//            additionalParameters.EmployeeEGN = "11111111111111";
//            additionalParameters.OrganizationEIK = "12121212121";
//            additionalParameters.OrganizationUnit = "qqqqqq";
//            additionalParameters.SignResult = true;
//            additionalParameters.ReturnAccessMatrix = true;

//            var result = adapter.GetHigherEduStudentByStatus(searchCriteria, accessMatrix, additionalParameters);
//            string xml = result.Data.Response.XmlSerialize();
//            using (StreamWriter outfile = new StreamWriter("GetChildStudentStatus_NULL_Test.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(xml);
//            }
//            XsltUtils.RunXsltAndWriteHtml("MonStudentsAdapter", "HigherEduStudentByStatusRequest", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("MonStudentsAdapter", "HigherEduStudentByStatusResponse", result.Data.Response.XmlSerialize());

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
//        public void GetHigherEduStudent_Test_default()
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
//            // "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            MonStudentsAdapter adapter = new MonStudentsAdapter();
//            var accessMatrix = AccessMatrix.CreateForType(typeof(HigherEduStudentResponse));
//            HigherEduStudentRequestType searchCriteria = new HigherEduStudentRequestType() { StudentIdentifier = "SI123" };

//            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//            additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            additionalParameters.CitizenEGN = "8888888888";
//            additionalParameters.ClientIPAddress = "111.111.111.111";
//            additionalParameters.ConsumerCertificateThumbprint = "###";
//            additionalParameters.EIDToken = "token123";
//            additionalParameters.EmployeeEGN = "11111111111111";
//            additionalParameters.OrganizationEIK = "12121212121";
//            additionalParameters.OrganizationUnit = "qqqqqq";
//            additionalParameters.SignResult = true;
//            additionalParameters.ReturnAccessMatrix = true;

//            var result = adapter.GetHigherEduStudent(searchCriteria, accessMatrix, additionalParameters);
//            string xml = result.Data.Response.XmlSerialize();
//            using (StreamWriter outfile = new StreamWriter("GetHigherEduStudent_Test.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(xml);
//            }
//            XsltUtils.RunXsltAndWriteHtml("MonStudentsAdapter", "HigherEduStudentRequest", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("MonStudentsAdapter", "HigherEduStudentResponse", result.Data.Response.XmlSerialize());

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
//        public void GetHigherEduStudent_NULL_Test()
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
//            // "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            MonStudentsAdapter adapter = new MonStudentsAdapter();
//            var accessMatrix = AccessMatrix.CreateForType(typeof(HigherEduStudentResponse));
//            HigherEduStudentRequestType searchCriteria = new HigherEduStudentRequestType() { StudentIdentifier = "test" };

//            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//            additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            additionalParameters.CitizenEGN = "8888888888";
//            additionalParameters.ClientIPAddress = "111.111.111.111";
//            additionalParameters.ConsumerCertificateThumbprint = "###";
//            additionalParameters.EIDToken = "token123";
//            additionalParameters.EmployeeEGN = "11111111111111";
//            additionalParameters.OrganizationEIK = "12121212121";
//            additionalParameters.OrganizationUnit = "qqqqqq";
//            additionalParameters.SignResult = true;
//            additionalParameters.ReturnAccessMatrix = true;

//            var result = adapter.GetHigherEduStudent(searchCriteria, accessMatrix, additionalParameters);
//            string xml = result.Data.Response.XmlSerialize();
//            using (StreamWriter outfile = new StreamWriter("GetHigherEduStudent_NULL_Test.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(xml);
//            }
//            XsltUtils.RunXsltAndWriteHtml("MonStudentsAdapter", "HigherEduStudentRequest", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("MonStudentsAdapter", "HigherEduStudentResponse", result.Data.Response.XmlSerialize());

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
