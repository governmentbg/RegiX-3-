//using System;
//using System.IO;
//using System.Xml;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using TechnoLogica.RegiX.Common.DataContracts;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.Common.Utils;
//using TechnoLogica.RegiX.NoiRPAdapter;
//using TechnoLogica.RegiX.NoiRPAdapter.AdapterService;
//using System.Linq;

//namespace RegiX.NoiROAdapterTests
//{
//    [TestClass]
//    public class NoiRPAdapterTests
//    {
//        //[TestMethod]
//        //public void RPAdapter_CheckHealthCheckAndParamtersTest()
//        //{
//        //    RPAdapter adapter = new RPAdapter();
//        //    //test GetParameters , and ConnectionString
//        //    var connectionString = adapter.GetParameters().ParameterList.Where(p => p.Key == TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName).FirstOrDefault();
//        //    //test SetParameter
//        //    adapter.SetParameter(TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName, "http://regix2-adapters.regix.tlogica.com/MockRegisters/NoiRPAdapterMockup/NoiService.svc");
//        //    //test HCfunctions
//        //    var hcFunctions = adapter.GetHealthCheckFunctions();
//        //    string checkHealthFunctionResult = string.Empty;
//        //    hcFunctions.HealthInfosList.ForEach(f =>
//        //    {
//        //        checkHealthFunctionResult = checkHealthFunctionResult + f.Key + ":" + adapter.CheckHealthFunction(f.Key) + ";\r\n";
//        //    });
//        //    using (StreamWriter outfile = new StreamWriter("CheckHealthFunctions.xml", false, System.Text.Encoding.UTF8))
//        //    {
//        //        outfile.Write(checkHealthFunctionResult);
//        //    }
//        //    Assert.IsTrue(true);
//        //}

//        //[TestMethod]
//        //public void RPAdapter_CheckRegisterConnection()
//        //{
//        //    RPAdapter adapter = new RPAdapter();
//        //    string result = adapter.CheckRegisterConnection();
//        //    Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
//        //}

//        [TestMethod]
//        public void GetPensionRightInfoReportTest()
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

//            PensionRightRequestType request = new PensionRightRequestType()
//            {
//                Identifier = "1234567890",
//                IdentifierType = IdentifierType.ЕГН,
//                Month = new MonthType() { Month = "--01", Year = "2015" }
//            };

//            AccessMatrix matrix = AccessMatrix.CreateForType(typeof(PensionRightResponseType));

//            RPAdapter adapter = new RPAdapter();
//            var result = adapter.GetPensionRightInfoReport(request, matrix, additionalParameters);

//            using (StreamWriter outfile = new StreamWriter("GetPensionRightInfoReportResponse.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(result.XmlSerialize());
//            }

//            XsltUtils.RunXsltAndWriteHtml("NoiRPAdapter", "PensionRightRequest", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("NoiRPAdapter", "PensionRightResponse", result.Data.Response.XmlSerialize());

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
//        public void GetPensionRightInfoReportTestNull()
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

//            PensionRightRequestType request = new PensionRightRequestType()
//            {
//                Identifier = "1111111111",
//                IdentifierType = IdentifierType.ЕГН,
//                Month = new MonthType() { Month = "--01", Year = "2015" }
//            };

//            AccessMatrix matrix = AccessMatrix.CreateForType(typeof(PensionRightResponseType));

//            RPAdapter adapter = new RPAdapter();
//            //adapter.SetParameter("WebServiceUrl", "http://localhost/RegiX.NoiRPAdapterMockup/NoiService.svc");
//            var result = adapter.GetPensionRightInfoReport(request, matrix, additionalParameters);
//            if(result.Data.Response.XmlSerialize().ToXmlElement().HasChildNodes)
//            {
//                Assert.Fail();
//            }
//            using (StreamWriter outfile = new StreamWriter("GetPensionRightInfoReportResponseNull.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(result.XmlSerialize());
//            }
//        }

//        [TestMethod]
//        public void GetPensionTypeAndAmountReportTest()
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

//            UP7RequestType request = new UP7RequestType()
//            {
//                Identifier = "1234567890",
//                IdentifierType = IdentifierType.ЕГН,
//                Month = new MonthType() { Month = "--01", Year = "2015" }
//            };

//            AccessMatrix matrix = AccessMatrix.CreateForType(typeof (UP7ResponseType));

//            RPAdapter adapter = new RPAdapter();
//            var result = adapter.GetPensionTypeAndAmountReport(request, matrix, additionalParameters);

//            using (StreamWriter outfile = new StreamWriter("GetPensionTypeAndAmountReportResponse.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(result.XmlSerialize());
//            }

//            XsltUtils.RunXsltAndWriteHtml("NoiRPAdapter", "UP7Request", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("NoiRPAdapter", "UP7Response", result.Data.Response.XmlSerialize());

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
//        public void GetPensionTypeAndAmountReportTestNull()
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

//            UP7RequestType request = new UP7RequestType()
//            {
//                Identifier = "1111111111",
//                IdentifierType = IdentifierType.ЕГН,
//                Month = new MonthType() { Month = "--01", Year = "2015" }
//            };

//            AccessMatrix matrix = AccessMatrix.CreateForType(typeof(UP7ResponseType));

//            RPAdapter adapter = new RPAdapter();
//            var result = adapter.GetPensionTypeAndAmountReport(request, matrix, additionalParameters);

//            if (result.Data.Response.XmlSerialize().ToXmlElement().HasChildNodes)
//            {
//                Assert.Fail();
//            }
//            using (StreamWriter outfile = new StreamWriter("GetPensionTypeAndAmountReportResponseNull.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(result.XmlSerialize());
//            }

           
//        }
//        [TestMethod]
//        public void GetPensionIncomeAmountReportTest()
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

//            UP8RequestType request = new UP8RequestType()
//            {
//                Identifier = "1234567890",
//                IdentifierType = IdentifierType.ЕГН,
//                Period =
//                    new PeriodType()
//                    {
//                        From = new MonthType() { Month = "--08", Year = "2015" },
//                        To = new MonthType() { Month = "--09", Year = "2015" }
//                    }
//            };

//            AccessMatrix matrix = AccessMatrix.CreateForType(typeof(UP8ResponseType));

//            RPAdapter adapter = new RPAdapter();
//            var result = adapter.GetPensionIncomeAmountReport(request, matrix, additionalParameters);

//            using (StreamWriter outfile = new StreamWriter("GetPensionIncomeAmountReportResponse.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(result.XmlSerialize());
//            }

//            XsltUtils.RunXsltAndWriteHtml("NoiRPAdapter", "UP8Request", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("NoiRPAdapter", "UP8Response", result.Data.Response.XmlSerialize());

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
//        public void GetPensionIncomeAmountReportTestNull()
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

//            UP8RequestType request = new UP8RequestType()
//            {
//                Identifier = "1111111111",
//                IdentifierType = IdentifierType.ЕГН,
//                Period =
//                    new PeriodType()
//                    {
//                        From = new MonthType() { Month = "--08", Year = "2015" },
//                        To = new MonthType() { Month = "--09", Year = "2015" }
//                    }
//            };

//            AccessMatrix matrix = AccessMatrix.CreateForType(typeof(UP8ResponseType));

//            RPAdapter adapter = new RPAdapter();
//            var result = adapter.GetPensionIncomeAmountReport(request, matrix, additionalParameters);

//            if (result.Data.Response.XmlSerialize().ToXmlElement().HasChildNodes)
//            {
//                Assert.Fail();
//            }

//            using (StreamWriter outfile = new StreamWriter("GetPensionIncomeAmountReportResponseNull.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(result.XmlSerialize());
//            }
            
//        }
//    }
//}
