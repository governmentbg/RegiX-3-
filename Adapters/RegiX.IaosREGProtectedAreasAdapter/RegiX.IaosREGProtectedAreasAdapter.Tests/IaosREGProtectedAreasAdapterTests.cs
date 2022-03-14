//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using TechnoLogica.RegiX.IaosREGProtectedAreasAdapter;
//using TechnoLogica.RegiX.IaosREGProtectedAreasAdapter.AdapterService;
//using System.IO;
//using TechnoLogica.RegiX.Common.Utils;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.Common.DataContracts;
//using TechnoLogica.RegiX.Common.AdapterCore;
//using System.Xml;
//using System.Linq;

//namespace RegiX.IaosREGProtectedAreasAdapterTests
//{
//    [TestClass]
//    public class IaosREGProtectedAreasAdapterTests
//    {

//        [TestMethod]
//        public void IaosREGProtectedAreasAdapterTest_CheckHealthCheckAndParamtersTest()
//        {
//            IaosREGProtectedAreasAdapter adapter = new IaosREGProtectedAreasAdapter();
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
//        public void IaosREGProtectedAreasAdapterTest_CheckRegisterConnection()
//        {
//            IaosREGProtectedAreasAdapter adapter = new IaosREGProtectedAreasAdapter();
//            string result = adapter.CheckRegisterConnection();
//            Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
//        }


//        [TestMethod]
//        public void GetREG_PAPZ_Protected_Area_Size_Test()
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

//            IaosREGProtectedAreasAdapter adapter = new IaosREGProtectedAreasAdapter();
//            var accessMatrix = AccessMatrix.CreateForType(typeof(REG_PAPZ_Protected_Area_Size_Response));
//            REG_PAPZ_Protected_Area_Size_Request searchCriteria = new REG_PAPZ_Protected_Area_Size_Request() { AreaCode = "2", AreaType = "1" };

//            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//            additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTestTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            additionalParameters.CitizenEGN = "8888888888";
//            additionalParameters.ClientIPAddress = "111.111.111.111";
//            additionalParameters.ConsumerCertificateThumbprint = "###";
//            additionalParameters.EIDToken = "token123";
//            additionalParameters.EmployeeEGN = "11111111111111";
//            additionalParameters.OrganizationEIK = "12121212121";
//            additionalParameters.OrganizationUnit = "qqqqqq";
//            additionalParameters.SignResult = false;
//            additionalParameters.ReturnAccessMatrix = true;

//            var result = adapter.GetREG_PAPZ_Protected_Area_Size(searchCriteria, accessMatrix, additionalParameters);
//            string xml = result.Data.Response.XmlSerialize();
//            using (StreamWriter outfile = new StreamWriter("GetREG_PAPZ_Protected_Area_Size_Test.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(xml);
//            }
//            XsltUtils.RunXsltAndWriteHtml("IaosREGProtectedAreasAdapter", "REG_PAPZ_Protected_Area_Size_Request", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("IaosREGProtectedAreasAdapter", "REG_PAPZ_Protected_Area_Size_Responce", result.Data.Response.XmlSerialize());

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
//        public void GetREG_PAPZ_Protected_Area_Size_NULL_Test()
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

//            IaosREGProtectedAreasAdapter adapter = new IaosREGProtectedAreasAdapter();
//            var accessMatrix = AccessMatrix.CreateForType(typeof(REG_PAPZ_Protected_Area_Size_Response));
//            REG_PAPZ_Protected_Area_Size_Request searchCriteria = new REG_PAPZ_Protected_Area_Size_Request() { AreaCode = "5", AreaType = "5" };

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

//            var result = adapter.GetREG_PAPZ_Protected_Area_Size(searchCriteria, accessMatrix, additionalParameters);
//            string xml = result.Data.Response.XmlSerialize();
//            using (StreamWriter outfile = new StreamWriter("GetREG_PAPZ_Protected_Area_Size_NULL_Test.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(xml);
//            }
//            XsltUtils.RunXsltAndWriteHtml("IaosREGProtectedAreasAdapter", "REG_PAPZ_Protected_Area_Size_Request", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("IaosREGProtectedAreasAdapter", "REG_PAPZ_Protected_Area_Size_Responce", result.Data.Response.XmlSerialize());

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
//        public void GetREG_PAPZ_Protected_Area_Category_Test()
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

//            IaosREGProtectedAreasAdapter adapter = new IaosREGProtectedAreasAdapter();
//            var accessMatrix = AccessMatrix.CreateForType(typeof(REG_PAPZ_Protected_Area_Category_Response));
//            REG_PAPZ_Protected_Area_Category_Request searchCriteria = new REG_PAPZ_Protected_Area_Category_Request() { AreaType = "1", CategoryName = "1" };

//            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//            additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTestTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            additionalParameters.CitizenEGN = "8888888888";
//            additionalParameters.ClientIPAddress = "111.111.111.111";
//            additionalParameters.ConsumerCertificateThumbprint = "###";
//            additionalParameters.EIDToken = "token123";
//            additionalParameters.EmployeeEGN = "11111111111111";
//            additionalParameters.OrganizationEIK = "12121212121";
//            additionalParameters.OrganizationUnit = "qqqqqq";
//            additionalParameters.SignResult = false;
//            additionalParameters.ReturnAccessMatrix = true;

//            var result = adapter.GetREG_PAPZ_Protected_Area_Category(searchCriteria, accessMatrix, additionalParameters);
//            string xml = result.Data.Response.XmlSerialize();
//            using (StreamWriter outfile = new StreamWriter("GetREG_PAPZ_Protected_Area_Category_Test.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(xml);
//            }
//            XsltUtils.RunXsltAndWriteHtml("IaosREGProtectedAreasAdapter", "REG_PAPZ_Protected_Area_Category_Request", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("IaosREGProtectedAreasAdapter", "REG_PAPZ_Protected_Area_Category_Responce", result.Data.Response.XmlSerialize());

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
//        public void GetREG_PAPZ_Protected_Area_Category_NULL_Test()
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

//            IaosREGProtectedAreasAdapter adapter = new IaosREGProtectedAreasAdapter();
//            var accessMatrix = AccessMatrix.CreateForType(typeof(REG_PAPZ_Protected_Area_Category_Response));
//            REG_PAPZ_Protected_Area_Category_Request searchCriteria = new REG_PAPZ_Protected_Area_Category_Request() { AreaType = "5", CategoryName = "5" };

//            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//            additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTestTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            additionalParameters.CitizenEGN = "8888888888";
//            additionalParameters.ClientIPAddress = "111.111.111.111";
//            additionalParameters.ConsumerCertificateThumbprint = "###";
//            additionalParameters.EIDToken = "token123";
//            additionalParameters.EmployeeEGN = "11111111111111";
//            additionalParameters.OrganizationEIK = "12121212121";
//            additionalParameters.OrganizationUnit = "qqqqqq";
//            additionalParameters.SignResult = false;
//            additionalParameters.ReturnAccessMatrix = true;

//            var result = adapter.GetREG_PAPZ_Protected_Area_Category(searchCriteria, accessMatrix, additionalParameters);

//            string xml = result.Data.Response.XmlSerialize();
//            using (StreamWriter outfile = new StreamWriter("GetREG_PAPZ_Protected_Area_Category_NULL_Test.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(xml);
//            }
//            XsltUtils.RunXsltAndWriteHtml("IaosREGProtectedAreasAdapter", "REG_PAPZ_Protected_Area_Category_Request", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("IaosREGProtectedAreasAdapter", "REG_PAPZ_Protected_Area_Category_Responce", result.Data.Response.XmlSerialize());

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
//        public void GetREG_PAPZ_Protected_Area_Location_Test()
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

//            IaosREGProtectedAreasAdapter adapter = new IaosREGProtectedAreasAdapter();
//            var accessMatrix = AccessMatrix.CreateForType(typeof(REG_PAPZ_Protected_Area_Location_Response));
//            REG_PAPZ_Protected_Area_Location_Request searchCriteria = new REG_PAPZ_Protected_Area_Location_Request() { DistName = "BGS27", PopName = "58356", TerName = "BGS" };

//            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//            additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTestTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            additionalParameters.CitizenEGN = "8888888888";
//            additionalParameters.ClientIPAddress = "111.111.111.111";
//            additionalParameters.ConsumerCertificateThumbprint = "###";
//            additionalParameters.EIDToken = "token123";
//            additionalParameters.EmployeeEGN = "11111111111111";
//            additionalParameters.OrganizationEIK = "12121212121";
//            additionalParameters.OrganizationUnit = "qqqqqq";
//            additionalParameters.SignResult = false;
//            additionalParameters.ReturnAccessMatrix = true;

//            var result = adapter.GetREG_PAPZ_Protected_Area_Location(searchCriteria, accessMatrix, additionalParameters);
//            string xml = result.Data.Response.XmlSerialize();
//            using (StreamWriter outfile = new StreamWriter("GetREG_PAPZ_Protected_Area_Location_Test.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(xml);
//            }
//            XsltUtils.RunXsltAndWriteHtml("IaosREGProtectedAreasAdapter", "REG_PAPZ_Protected_Area_Location_Request", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("IaosREGProtectedAreasAdapter", "REG_PAPZ_Protected_Area_Location_Responce", result.Data.Response.XmlSerialize());

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
//        public void GetREG_PAPZ_Protected_Area_Location_NULL_Test()
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

//            IaosREGProtectedAreasAdapter adapter = new IaosREGProtectedAreasAdapter();
//            var accessMatrix = AccessMatrix.CreateForType(typeof(REG_PAPZ_Protected_Area_Location_Response));
//            REG_PAPZ_Protected_Area_Location_Request searchCriteria = new REG_PAPZ_Protected_Area_Location_Request() { DistName = "test", PopName = "test", TerName = "test" };

//            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
//            additionalParameters.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTestTest" };// "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";
//            additionalParameters.CitizenEGN = "8888888888";
//            additionalParameters.ClientIPAddress = "111.111.111.111";
//            additionalParameters.ConsumerCertificateThumbprint = "###";
//            additionalParameters.EIDToken = "token123";
//            additionalParameters.EmployeeEGN = "11111111111111";
//            additionalParameters.OrganizationEIK = "12121212121";
//            additionalParameters.OrganizationUnit = "qqqqqq";
//            additionalParameters.SignResult = false;
//            additionalParameters.ReturnAccessMatrix = true;

//            var result = adapter.GetREG_PAPZ_Protected_Area_Location(searchCriteria, accessMatrix, additionalParameters);
//            string xml = result.Data.Response.XmlSerialize();
//            using (StreamWriter outfile = new StreamWriter("GetREG_PAPZ_Protected_Area_Location_NULL_Test.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(xml);
//            }
//            XsltUtils.RunXsltAndWriteHtml("IaosREGProtectedAreasAdapter", "REG_PAPZ_Protected_Area_Location_Request", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("IaosREGProtectedAreasAdapter", "REG_PAPZ_Protected_Area_Location_Responce", result.Data.Response.XmlSerialize());

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
//        //    IaosREGProtectedAreasAdapter adapter = new IaosREGProtectedAreasAdapter();
//        //    ConnectionStatusInfo status = adapter.CheckRegisterConnection();
//        //    Assert.IsTrue(true);
//        //}
//    }
//}
