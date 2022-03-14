//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.IaosRegister67ZOUAdapter;
//using TechnoLogica.RegiX.IaosRegister67ZOUAdapter.AdapterService;
//using System.IO;
//using TechnoLogica.RegiX.Common.Utils;
//using TechnoLogica.RegiX.Common.DataContracts;
//using TechnoLogica.RegiX.Common.AdapterCore;
//using System.Xml;
//using System.Linq;

//namespace RegiX.IaosRegister67ZOUAdapterTests
//{
//    [TestClass]
//    public class IaosRegister67ZOUAdapterTests
//    {

//        [TestMethod]
//        public void IaosRegister67ZOUAdapterTest_CheckHealthCheckAndParamtersTest()
//        {
//            IaosRegister67ZOUAdapter adapter = new IaosRegister67ZOUAdapter();
//            //test GetParameters , and ConnectionString
//            var connectionString = adapter.GetParameters().ParameterList.Where(p => p.Key == TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName).FirstOrDefault();
//            //test SetParameter
//            adapter.SetParameter(TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName, connectionString.CurrentValue);
//            //test HCfunctions
//            var hcFunctions = adapter.GetHealthCheckFunctions();
//            string checkHealthFunctionResult = string.Empty;
//            hcFunctions.HealthInfosList.ForEach(f => {
//                checkHealthFunctionResult = checkHealthFunctionResult + f.Key + ":" + adapter.CheckHealthFunction(f.Key) + ";\r\n";
//            });
//            using (StreamWriter outfile = new StreamWriter("CheckHealthFunctions.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(checkHealthFunctionResult);
//            }
//            Assert.IsTrue(true);
//        }
//        [TestMethod]
//        public void IaosRegister67ZOUAdapterTest_CheckRegisterConnection()
//        {
//            IaosRegister67ZOUAdapter adapter = new IaosRegister67ZOUAdapter();
//            string result = adapter.CheckRegisterConnection();
//            Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
//        }


//        [TestMethod]
//        public void GetREG35_Info_By_EIK_Test()
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

//            IaosRegister67ZOUAdapter adapter = new IaosRegister67ZOUAdapter();
//            var accessMatrix = AccessMatrix.CreateForType(typeof(REG35_Info_By_EIK_Response));
//            REG35_Info_By_EIK_Request searchCriteria = new REG35_Info_By_EIK_Request() { EIK = "131103818" };

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

//            var result = adapter.GetREG35_Info_By_EIK(searchCriteria, accessMatrix, additionalParameters);
//            string xml = result.Data.Response.XmlSerialize();
//            using (StreamWriter outfile = new StreamWriter("GetREG35_Info_By_EIK_Test.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(xml);
//            }
//            XsltUtils.RunXsltAndWriteHtml("IaosRegister67ZOUAdapter", "REG35_Info_By_EIK_Request", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("IaosRegister67ZOUAdapter", "REG35_Info_By_EIK_Response", result.Data.Response.XmlSerialize());

//            XmlDocument doc = new XmlDocument();
//            doc.LoadXml(xml);
//            if (SigningUtils.HasSignature(doc))
//            {
//                bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc.DocumentElement);
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
//        public void GetREG35_Info_By_EIK_Null_Test()
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

//            IaosRegister67ZOUAdapter adapter = new IaosRegister67ZOUAdapter();
//            var accessMatrix = AccessMatrix.CreateForType(typeof(REG35_Info_By_EIK_Response));
//            REG35_Info_By_EIK_Request searchCriteria = new REG35_Info_By_EIK_Request() { EIK = "test" };

//            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//            additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            additionalParameters.CitizenEGN = "8888888888";
//            additionalParameters.ClientIPAddress = "111.111.111.111";
//            additionalParameters.ConsumerCertificateThumbprint = "###";
//            additionalParameters.EIDToken = "token123";
//            additionalParameters.EmployeeEGN = "11111111111111";
//            additionalParameters.OrganizationEIK = "12121212121";
//            additionalParameters.OrganizationUnit = "qqqqqq";
//            additionalParameters.SignResult = false;
//            additionalParameters.ReturnAccessMatrix = true;

//            var result = adapter.GetREG35_Info_By_EIK(searchCriteria, accessMatrix, additionalParameters);
//            string xml = result.Data.Response.XmlSerialize();
//            using (StreamWriter outfile = new StreamWriter("GetREG35_Info_By_EIK_Null_Test.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(xml);
//            }
//            XsltUtils.RunXsltAndWriteHtml("IaosRegister67ZOUAdapter", "REG35_Info_By_EIK_Request", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("IaosRegister67ZOUAdapter", "REG35_Info_By_EIK_Response", result.Data.Response.XmlSerialize());

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
//        public void GetREG35_License_Validity_Check_Test()
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

//            IaosRegister67ZOUAdapter adapter = new IaosRegister67ZOUAdapter();
//            var accessMatrix = AccessMatrix.CreateForType(typeof(REG35_License_Validity_Check_Response));
//            REG35_License_Validity_Check_Request searchCriteria = new REG35_License_Validity_Check_Request() { AuthNum = "00-ДО-00000185-09", Date = new DateTime(2015, 5, 12) };

//            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//            additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            additionalParameters.CitizenEGN = "8888888888";
//            additionalParameters.ClientIPAddress = "111.111.111.111";
//            additionalParameters.ConsumerCertificateThumbprint = "###";
//            additionalParameters.EIDToken = "token123";
//            additionalParameters.EmployeeEGN = "11111111111111";
//            additionalParameters.OrganizationEIK = "12121212121";
//            additionalParameters.OrganizationUnit = "qqqqqq";
//            additionalParameters.SignResult = false;
//            additionalParameters.ReturnAccessMatrix = true;

//            var result = adapter.GetREG35_License_Validity_Check(searchCriteria, accessMatrix, additionalParameters);
//            string xml = result.Data.Response.XmlSerialize();
//            using (StreamWriter outfile = new StreamWriter("GetREG35_License_Validity_Check_Test.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(xml);
//            }
//            XsltUtils.RunXsltAndWriteHtml("IaosRegister67ZOUAdapter", "REG35_License_Validity_Check_Request", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("IaosRegister67ZOUAdapter", "REG35_License_Validity_Check_Response", result.Data.Response.XmlSerialize());

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
//        public void GetREG35_License_Validity_Check_Null_Test()
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

//            IaosRegister67ZOUAdapter adapter = new IaosRegister67ZOUAdapter();
//            var accessMatrix = AccessMatrix.CreateForType(typeof(REG35_License_Validity_Check_Response));
//            REG35_License_Validity_Check_Request searchCriteria = new REG35_License_Validity_Check_Request() { AuthNum = "test", Date = new DateTime(2000, 1, 1) };

//            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//            additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            additionalParameters.CitizenEGN = "8888888888";
//            additionalParameters.ClientIPAddress = "111.111.111.111";
//            additionalParameters.ConsumerCertificateThumbprint = "###";
//            additionalParameters.EIDToken = "token123";
//            additionalParameters.EmployeeEGN = "11111111111111";
//            additionalParameters.OrganizationEIK = "12121212121";
//            additionalParameters.OrganizationUnit = "qqqqqq";
//            additionalParameters.SignResult = false;
//            additionalParameters.ReturnAccessMatrix = true;

//            var result = adapter.GetREG35_License_Validity_Check(searchCriteria, accessMatrix, additionalParameters);
//            string xml = result.Data.Response.XmlSerialize();
//            using (StreamWriter outfile = new StreamWriter("GetREG35_License_Validity_Check_NULL_Test.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(result.Data.Response.XmlSerialize());
//            }
//            XsltUtils.RunXsltAndWriteHtml("IaosRegister67ZOUAdapter", "REG35_License_Validity_Check_Request", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("IaosRegister67ZOUAdapter", "REG35_License_Validity_Check_Response", result.Data.Response.XmlSerialize());

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
//        public void GetREG35_Stage_Info_By_Pop_Name_Test()
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

//            IaosRegister67ZOUAdapter adapter = new IaosRegister67ZOUAdapter();
//            var accessMatrix = AccessMatrix.CreateForType(typeof(REG35_Stage_Info_By_Pop_Name_Response));
//            REG35_Stage_Info_By_Pop_Name_Request searchCriteria = new REG35_Stage_Info_By_Pop_Name_Request() { AuthNum = "00-ДО-00000185-09", PopName = "52393" };

//            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//            additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            additionalParameters.CitizenEGN = "8888888888";
//            additionalParameters.ClientIPAddress = "111.111.111.111";
//            additionalParameters.ConsumerCertificateThumbprint = "###";
//            additionalParameters.EIDToken = "token123";
//            additionalParameters.EmployeeEGN = "11111111111111";
//            additionalParameters.OrganizationEIK = "12121212121";
//            additionalParameters.OrganizationUnit = "qqqqqq";
//            additionalParameters.SignResult = false;
//            additionalParameters.ReturnAccessMatrix = true;

//            var result = adapter.GetREG35_Stage_Info_By_Pop_Name(searchCriteria, accessMatrix, additionalParameters);
//            string xml = result.Data.Response.XmlSerialize();
//            using (StreamWriter outfile = new StreamWriter("GetREG35_Stage_Info_By_Pop_Name_Test.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(xml);
//            }
//            XsltUtils.RunXsltAndWriteHtml("IaosRegister67ZOUAdapter", "REG35_Stage_Info_By_Pop_Name_Request", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("IaosRegister67ZOUAdapter", "REG35_Stage_Info_By_Pop_Name_Response", result.Data.Response.XmlSerialize());

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
//        public void GetREG35_Stage_Info_By_Pop_Name_Null_Test()
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

//            IaosRegister67ZOUAdapter adapter = new IaosRegister67ZOUAdapter();
//            var accessMatrix = AccessMatrix.CreateForType(typeof(REG35_Stage_Info_By_Pop_Name_Response));
//            REG35_Stage_Info_By_Pop_Name_Request searchCriteria = new REG35_Stage_Info_By_Pop_Name_Request() { AuthNum = "test", PopName = "test" };

//            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//            additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            additionalParameters.CitizenEGN = "8888888888";
//            additionalParameters.ClientIPAddress = "111.111.111.111";
//            additionalParameters.ConsumerCertificateThumbprint = "###";
//            additionalParameters.EIDToken = "token123";
//            additionalParameters.EmployeeEGN = "11111111111111";
//            additionalParameters.OrganizationEIK = "12121212121";
//            additionalParameters.OrganizationUnit = "qqqqqq";
//            additionalParameters.SignResult = false;
//            additionalParameters.ReturnAccessMatrix = true;


//            var result = adapter.GetREG35_Stage_Info_By_Pop_Name(searchCriteria, accessMatrix, additionalParameters);
//            string xml = result.Data.Response.XmlSerialize();
//            using (StreamWriter outfile = new StreamWriter("GetREG35_Stage_Info_By_Pop_Name_NULL_Test.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(xml);
//            }
//            XsltUtils.RunXsltAndWriteHtml("IaosRegister67ZOUAdapter", "REG35_Stage_Info_By_Pop_Name_Request", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("IaosRegister67ZOUAdapter", "REG35_Stage_Info_By_Pop_Name_Response", result.Data.Response.XmlSerialize());

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
//        public void GetREG35_Stage_Info_By_Waste_Code_Test()
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

//            IaosRegister67ZOUAdapter adapter = new IaosRegister67ZOUAdapter();
//            var accessMatrix = AccessMatrix.CreateForType(typeof(REG35_Stage_Info_By_Waste_Code_Response));
//            REG35_Stage_Info_By_Waste_Code_Request searchCriteria = new REG35_Stage_Info_By_Waste_Code_Request() { EIK = "131103818", WasteOperation = "160602" };

//            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//            additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            additionalParameters.CitizenEGN = "8888888888";
//            additionalParameters.ClientIPAddress = "111.111.111.111";
//            additionalParameters.ConsumerCertificateThumbprint = "###";
//            additionalParameters.EIDToken = "token123";
//            additionalParameters.EmployeeEGN = "11111111111111";
//            additionalParameters.OrganizationEIK = "12121212121";
//            additionalParameters.OrganizationUnit = "qqqqqq";
//            additionalParameters.SignResult = false;
//            additionalParameters.ReturnAccessMatrix = true;


//            var result = adapter.GetREG35_Stage_Info_By_Waste_Code(searchCriteria, accessMatrix, additionalParameters);
//            string xml = result.Data.Response.XmlSerialize();
//            using (StreamWriter outfile = new StreamWriter("GetREG35_Stage_Info_By_Waste_Code_Test.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(xml);
//            }
//            XsltUtils.RunXsltAndWriteHtml("IaosRegister67ZOUAdapter", "REG35_Stage_Info_By_Waste_Code_Request", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("IaosRegister67ZOUAdapter", "REG35_Stage_Info_By_Waste_Code_Response", result.Data.Response.XmlSerialize());

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
//        public void GetREG35_Stage_Info_By_Waste_Code_Null_Test()
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

//            IaosRegister67ZOUAdapter adapter = new IaosRegister67ZOUAdapter();
//            var accessMatrix = AccessMatrix.CreateForType(typeof(REG35_Stage_Info_By_Waste_Code_Response));
//            REG35_Stage_Info_By_Waste_Code_Request searchCriteria = new REG35_Stage_Info_By_Waste_Code_Request() { EIK = "test", WasteOperation = "test" };

//            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//            additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            additionalParameters.CitizenEGN = "8888888888";
//            additionalParameters.ClientIPAddress = "111.111.111.111";
//            additionalParameters.ConsumerCertificateThumbprint = "###";
//            additionalParameters.EIDToken = "token123";
//            additionalParameters.EmployeeEGN = "11111111111111";
//            additionalParameters.OrganizationEIK = "12121212121";
//            additionalParameters.OrganizationUnit = "qqqqqq";
//            additionalParameters.SignResult = false;
//            additionalParameters.ReturnAccessMatrix = true;

//            var result = adapter.GetREG35_Stage_Info_By_Waste_Code(searchCriteria, accessMatrix, additionalParameters);
//            string xml = result.Data.Response.XmlSerialize();
//            using (StreamWriter outfile = new StreamWriter("GetREG35_Stage_Info_By_Waste_Code_NULL_Test.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(xml);
//            }
//            XsltUtils.RunXsltAndWriteHtml("IaosRegister67ZOUAdapter", "REG35_Stage_Info_By_Waste_Code_Request", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("IaosRegister67ZOUAdapter", "REG35_Stage_Info_By_Waste_Code_Response", result.Data.Response.XmlSerialize());

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
//        public void GetREG35_Stages_By_Reg_Number_And_Waste_Code_Test()
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

//            IaosRegister67ZOUAdapter adapter = new IaosRegister67ZOUAdapter();
//            var accessMatrix = AccessMatrix.CreateForType(typeof(REG35_Stages_By_Reg_Number_And_Waste_Code_Response));
//            REG35_Stages_By_Reg_Number_And_Waste_Code_Request searchCriteria = new REG35_Stages_By_Reg_Number_And_Waste_Code_Request() { AuthNum = "00-ДО-00000185-09", WasteCode = "160216" };

//            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//            additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            additionalParameters.CitizenEGN = "8888888888";
//            additionalParameters.ClientIPAddress = "111.111.111.111";
//            additionalParameters.ConsumerCertificateThumbprint = "###";
//            additionalParameters.EIDToken = "token123";
//            additionalParameters.EmployeeEGN = "11111111111111";
//            additionalParameters.OrganizationEIK = "12121212121";
//            additionalParameters.OrganizationUnit = "qqqqqq";
//            additionalParameters.SignResult = false;
//            additionalParameters.ReturnAccessMatrix = true;

//            var result = adapter.GetREG35_Stages_By_Reg_Number_And_Waste_Code(searchCriteria, accessMatrix, additionalParameters);
//            string xml = result.Data.Response.XmlSerialize();
//            using (StreamWriter outfile = new StreamWriter("GetREG35_Stages_By_Reg_Number_And_Waste_Code_Test.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(xml);
//            }
//            XsltUtils.RunXsltAndWriteHtml("IaosRegister67ZOUAdapter", "REG35_Stages_By_Reg_Number_And_Waste_Code_Request", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("IaosRegister67ZOUAdapter", "REG35_Stages_By_Reg_Number_And_Waste_Code_Response", result.Data.Response.XmlSerialize());

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
//        public void GetREG35_Stages_By_Reg_Number_And_Waste_Code_Null_Test()
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

//            IaosRegister67ZOUAdapter adapter = new IaosRegister67ZOUAdapter();
//            var accessMatrix = AccessMatrix.CreateForType(typeof(REG35_Stages_By_Reg_Number_And_Waste_Code_Response));
//            REG35_Stages_By_Reg_Number_And_Waste_Code_Request searchCriteria = new REG35_Stages_By_Reg_Number_And_Waste_Code_Request() { AuthNum = "test", WasteCode = "test" };

//            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//            additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            additionalParameters.CitizenEGN = "8888888888";
//            additionalParameters.ClientIPAddress = "111.111.111.111";
//            additionalParameters.ConsumerCertificateThumbprint = "###";
//            additionalParameters.EIDToken = "token123";
//            additionalParameters.EmployeeEGN = "11111111111111";
//            additionalParameters.OrganizationEIK = "12121212121";
//            additionalParameters.OrganizationUnit = "qqqqqq";
//            additionalParameters.SignResult = false;
//            additionalParameters.ReturnAccessMatrix = true;

//            var result = adapter.GetREG35_Stages_By_Reg_Number_And_Waste_Code(searchCriteria, accessMatrix, additionalParameters);
//            string xml = result.Data.Response.XmlSerialize();
//            using (StreamWriter outfile = new StreamWriter("GetREG35_Stages_By_Reg_Number_And_Waste_Code_NULL_Test.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(xml);
//            }
//            XsltUtils.RunXsltAndWriteHtml("IaosRegister67ZOUAdapter", "REG35_Stages_By_Reg_Number_And_Waste_Code_Request", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("IaosRegister67ZOUAdapter", "REG35_Stages_By_Reg_Number_And_Waste_Code_Response", result.Data.Response.XmlSerialize());

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
//        public void GetREG35_Validity_Check_By_Reg_Number_Test()
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

//            IaosRegister67ZOUAdapter adapter = new IaosRegister67ZOUAdapter();
//            var accessMatrix = AccessMatrix.CreateForType(typeof(REG35_Validity_Check_By_Reg_Number_Response));
//            REG35_Validity_Check_By_Reg_Number_Request searchCriteria = new REG35_Validity_Check_By_Reg_Number_Request() { AuthNum = "00-ДО-00000185-09" };

//            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//            additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            additionalParameters.CitizenEGN = "8888888888";
//            additionalParameters.ClientIPAddress = "111.111.111.111";
//            additionalParameters.ConsumerCertificateThumbprint = "###";
//            additionalParameters.EIDToken = "token123";
//            additionalParameters.EmployeeEGN = "11111111111111";
//            additionalParameters.OrganizationEIK = "12121212121";
//            additionalParameters.OrganizationUnit = "qqqqqq";
//            additionalParameters.SignResult = false;
//            additionalParameters.ReturnAccessMatrix = true;

//            var result = adapter.GetREG35_Validity_Check_By_Reg_Number(searchCriteria, accessMatrix, additionalParameters);
//            string xml = result.Data.Response.XmlSerialize();
//            using (StreamWriter outfile = new StreamWriter("GetREG35_Validity_Check_By_Reg_Number_Test.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(xml);
//            }
//            XsltUtils.RunXsltAndWriteHtml("IaosRegister67ZOUAdapter", "REG35_Validity_Check_By_Reg_Number_Request", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("IaosRegister67ZOUAdapter", "REG35_Validity_Check_By_Reg_Number_Response", result.Data.Response.XmlSerialize());

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
//        public void GetREG35_Validity_Check_By_Reg_Number_Null_Test()
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

//            IaosRegister67ZOUAdapter adapter = new IaosRegister67ZOUAdapter();
//            var accessMatrix = AccessMatrix.CreateForType(typeof(REG35_Validity_Check_By_Reg_Number_Response));
//            REG35_Validity_Check_By_Reg_Number_Request searchCriteria = new REG35_Validity_Check_By_Reg_Number_Request() { AuthNum = "test" };

//            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//            additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            additionalParameters.CitizenEGN = "8888888888";
//            additionalParameters.ClientIPAddress = "111.111.111.111";
//            additionalParameters.ConsumerCertificateThumbprint = "###";
//            additionalParameters.EIDToken = "token123";
//            additionalParameters.EmployeeEGN = "11111111111111";
//            additionalParameters.OrganizationEIK = "12121212121";
//            additionalParameters.OrganizationUnit = "qqqqqq";
//            additionalParameters.SignResult = false;
//            additionalParameters.ReturnAccessMatrix = true;

//            var result = adapter.GetREG35_Validity_Check_By_Reg_Number(searchCriteria, accessMatrix, additionalParameters);
//            string xml = result.Data.Response.XmlSerialize();
//            using (StreamWriter outfile = new StreamWriter("GetREG35_Validity_Check_By_Reg_Number_NULL_Test.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(xml);
//            }
//            XsltUtils.RunXsltAndWriteHtml("IaosRegister67ZOUAdapter", "REG35_Validity_Check_By_Reg_Number_Request", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("IaosRegister67ZOUAdapter", "REG35_Validity_Check_By_Reg_Number_Response", result.Data.Response.XmlSerialize());

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

//        //[TestMethod]
//        //public void CheckConnectionTest()
//        //{
//        //    IaosRegister67ZOUAdapter adapter = new IaosRegister67ZOUAdapter();
//        //    ConnectionStatusInfo status = adapter.CheckRegisterConnection();
//        //    Assert.IsTrue(true);
//        //}
//    }
//}
