//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.NRAObligatedPersonsAdapter;
//using TechnoLogica.RegiX.NRAObligatedPersonsAdapter.AdapterService;
//using TechnoLogica.RegiX.NRAEmploymentContractsAdapter;
//using TechnoLogica.RegiX.NRAEmploymentContractsAdapter.AdapterService;
//using System.IO;
//using TechnoLogica.RegiX.Common.Utils;
//using System.ServiceModel;
//using TechnoLogica.RegiX.Common.AdapterCore;
//using System.Xml;
//using System.Linq;

//namespace Regix.NRAObligatedPersonsAdapterTests
//{
//    [TestClass]
//    public class NRAObligatedPersonsAdapterTests
//    {
//        //[TestMethod]
//        //public void NRAObligatedPersonsAdapterTests_CheckHealthCheckAndParamtersTest()
//        //{
//        //    NRAObligatedPersonsAdapter adapter = new NRAObligatedPersonsAdapter();
//        //    //test GetParameters , and ConnectionString
//        //    var connectionString = adapter.GetParameters().ParameterList.Where(p => p.Key == TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName).FirstOrDefault();
//        //    //test SetParameter
//        //    adapter.SetParameter(TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName, connectionString.CurrentValue);
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
//        //public void NRAObligatedPersonsAdapterTests_CheckRegisterConnection()
//        //{
//        //    NRAObligatedPersonsAdapter adapter = new NRAObligatedPersonsAdapter();
//        //    string result = adapter.CheckRegisterConnection();
//        //    Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
//        //    //Assert.IsFalse(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
//        //}

//        //[TestMethod]
//        //public void NRAEmploymentContractsAdapter_CheckHealthCheckAndParamtersTest()
//        //{
//        //    NRAEmploymentContractsAdapter adapter = new NRAEmploymentContractsAdapter();
//        //    //test GetParameters , and ConnectionString
//        //    var connectionString = adapter.GetParameters().ParameterList.Where(p => p.Key == TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName).FirstOrDefault();
//        //    //test SetParameter
//        //    adapter.SetParameter(TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName, connectionString.CurrentValue);
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
//        //public void NRAEmploymentContractsAdapter_CheckRegisterConnection()
//        //{
//        //    NRAEmploymentContractsAdapter adapter = new NRAEmploymentContractsAdapter();
//        //    string result = adapter.CheckRegisterConnection();
//        //    Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
//        //    //Assert.IsFalse(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
//        //}
//        [TestMethod]
//        public void GetObligatedPersonsTest1()
//        {
//            EmploymentContractsRequest req = new EmploymentContractsRequest();
//            req.Identity = new TechnoLogica.RegiX.NRAEmploymentContractsAdapter.IdentityTypeRequest();
//            req.Identity.ID = "123456";
//            req.Identity.TYPE = TechnoLogica.RegiX.NRAEmploymentContractsAdapter.EikTypeType.EGN;
//            var res = req.XmlSerialize();

//            string request1 = "<EmploymentContractsRequest xmlns=\"http://egov.bg/RegiX/NRA/EmploymentContracts/Request\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n<Identity>\r\n<ID>test</ID>\r\n<TYPE>EGN</TYPE>\r\n</Identity>\r\n</EmploymentContractsRequest>";
//            var doc = new XmlDocument();
//            doc.LoadXml(request1);
//            var result = doc.DocumentElement.Deserialize(typeof(EmploymentContractsRequest));
//        }

//        [TestMethod]
//        public void GetObligatedPersonsTest()
//        {
//            NRAObligatedPersonsAdapter adapter = new NRAObligatedPersonsAdapter();
//            adapter.SetParameter("WebServiceUrl", "http://172.16.69.13:8078/RegiX.NRAObligatedPersonsAdapterMockup/NRAObligatedPersonsService.svc/GetObligatedPerson");
//            adapter.SetParameter("ServiceSslCertificateThumbPrint", "");
           
//            var accessMatrix = AccessMatrix.CreateForType(typeof(ObligationResponse));

//            TechnoLogica.RegiX.NRAObligatedPersonsAdapter.IdentityTypeRequest parameters = new TechnoLogica.RegiX.NRAObligatedPersonsAdapter.IdentityTypeRequest()
//            {
//                ID = "9811186295",
//                TYPE = TechnoLogica.RegiX.NRAObligatedPersonsAdapter.EikTypeTypeRequest.EGN
//            };

//            ObligationRequest searchCriteria = new ObligationRequest() { Identity = parameters, Threshold = 2 };

//            TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters aparams = new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters();
//            aparams.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };
//            aparams.CitizenEGN = "egn3;,kl";
//            aparams.ClientIPAddress = "200.929.29.29";
//            aparams.EmployeeEGN = "1632598847";

//            var result = adapter.GetObligatedPersons(searchCriteria, accessMatrix, aparams);

//            using (StreamWriter outfile = new StreamWriter("GetObligatedPersonsTest.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(result.XmlSerialize());
//            }

//            XsltUtils.RunXsltAndWriteHtml("NRAObligatedPersonsAdapter", "ObligatedPersonsRequest", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("NRAObligatedPersonsAdapter", "ObligatedPersonsResponse", result.Data.Response.XmlSerialize());

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
//        public void GetObligatedPersonsHttpsTest()
//        {
//            NRAObligatedPersonsAdapter adapter = new NRAObligatedPersonsAdapter();
//            adapter.SetParameter("WebServiceUrl", "https://172.16.69.13:4434/RegiX.NRAObligatedPersonsAdapterMockupSSL/NRAObligatedPersonsService.svc/GetObligatedPerson");
//            adapter.SetParameter("ServiceSslCertificateThumbPrint", "62e243badfaeae6df21dca81ff9cdf7644020469");
         

//            var accessMatrix = AccessMatrix.CreateForType(typeof(ObligationResponse));

//            TechnoLogica.RegiX.NRAObligatedPersonsAdapter.IdentityTypeRequest parameters = new TechnoLogica.RegiX.NRAObligatedPersonsAdapter.IdentityTypeRequest()
//            {
//                ID = "9811186295",
//                TYPE = TechnoLogica.RegiX.NRAObligatedPersonsAdapter.EikTypeTypeRequest.EGN
//            };

//            ObligationRequest searchCriteria = new ObligationRequest() { Identity = parameters, Threshold = 2 };

//            TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters aparams = new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters();
//            aparams.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };
//            aparams.CitizenEGN = "egn3;,kl";
//            aparams.ClientIPAddress = "200.929.29.29";
//            aparams.EmployeeEGN = "1632598847";

//            var result = adapter.GetObligatedPersons(searchCriteria, accessMatrix, aparams);

//            using (StreamWriter outfile = new StreamWriter("GetObligatedPersonsTest.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(result.XmlSerialize());
//            }

//            XsltUtils.RunXsltAndWriteHtml("NRAObligatedPersonsAdapter", "ObligatedPersonsRequest", result.Data.Request.XmlSerialize());
//            XsltUtils.RunXsltAndWriteHtml("NRAObligatedPersonsAdapter", "ObligatedPersonsResponse", result.Data.Response.XmlSerialize());

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


//        /*В момента методът не работи правилно*/

//        //[TestMethod]
//        //public void GetObligatedPersonsNULLTest()
//        //{
//        //    NRAObligatedPersonsAdapter adapter = new NRAObligatedPersonsAdapter();
//        //    var accessMatrix = AccessMatrix.CreateForType(typeof(ObligationResponse));
//        //    TechnoLogica.RegiX.NRAObligatedPersonsAdapter.IdentityTypeRequest parameters = new TechnoLogica.RegiX.NRAObligatedPersonsAdapter.IdentityTypeRequest()
//        //    {
//        //        ID = String.Empty,
//        //        TYPE = TechnoLogica.RegiX.NRAObligatedPersonsAdapter.EikTypeTypeRequest.EGN
//        //    };
//        //    ObligationRequest searchCriteria = new ObligationRequest() { Identity = parameters, Threshold = 2 };
//        //    var result = adapter.GetObligatedPersons(searchCriteria, accessMatrix, new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters());
//        //    using (StreamWriter outfile = new StreamWriter("GetObligatedPersonsNULLTest.xml", false, System.Text.Encoding.UTF8))
//        //    {
//        //        outfile.Write(result.XmlSerialize());
//        //    }

//        //    XsltUtils.RunXsltAndWriteHtml("NRAObligatedPersonsAdapter", "ObligatedPersonsRequest", result.Data.Request.XmlSerialize());
//        //    XsltUtils.RunXsltAndWriteHtml("NRAObligatedPersonsAdapter", "ObligatedPersonsResponse", result.Data.Response.XmlSerialize());

//        //    XmlDocument doc = new XmlDocument();
//        //    doc.LoadXml(result.XmlSerialize());
//        //    if (SigningUtils.HasSignature(doc))
//        //    {
//        //        bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc);
//        //        if (isValid)
//        //        {
//        //            Assert.IsTrue(true);
//        //        }
//        //    }
//        //    else
//        //    {
//        //        Assert.IsTrue(true);
//        //    }
//        //}

//        [TestMethod]
//        public void GetObligatedPersonsStatusNotOkTest()
//        {
//            NRAObligatedPersonsAdapter adapter = new NRAObligatedPersonsAdapter();
//            var accessMatrix = AccessMatrix.CreateForType(typeof(ObligationResponse));
//            TechnoLogica.RegiX.NRAObligatedPersonsAdapter.IdentityTypeRequest parameters = new TechnoLogica.RegiX.NRAObligatedPersonsAdapter.IdentityTypeRequest()
//            {
//                ID = "StatusNotOk",
//                TYPE = TechnoLogica.RegiX.NRAObligatedPersonsAdapter.EikTypeTypeRequest.EGN
//            };
//            ObligationRequest searchCriteria = new ObligationRequest() { Identity = parameters, Threshold = 2 };
//            try
//            {

//                var result = adapter.GetObligatedPersons(searchCriteria, accessMatrix, new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters());
//                Assert.Fail();
//            }
//            catch (Exception ex)
//            {
//                if (ex.InnerException != null && ex.InnerException.Message.StartsWith("StatusCode:"))
//                {
//                    Assert.IsTrue(true);
//                }
//                else
//                {
//                    throw ex;
//                }
//            }

//        }

//        [TestMethod]
//        public void GetEmploymentContractsTest()
//        {
//            NRAEmploymentContractsAdapter adapter = new NRAEmploymentContractsAdapter();
//            adapter.SetParameter("WebServiceUrl", "http://172.16.69.13:8078/RegiX.NRAObligatedPersonsAdapterMockup/NRAObligatedPersonsService.svc/GetEmploymentContracts");
//            adapter.SetParameter("ServiceSslCertificateThumbPrint", "");
//            //adapter.SetParameter("WebServiceUrl", "https://nraapp01.nra.bg/rs/regix/econtract");
//            var accessMatrix = AccessMatrix.CreateForType(typeof(EmploymentContractsResponse));

//            TechnoLogica.RegiX.NRAEmploymentContractsAdapter.IdentityTypeRequest parameters = new TechnoLogica.RegiX.NRAEmploymentContractsAdapter.IdentityTypeRequest()
//            {
//                ID = "8310188539",
//                TYPE = TechnoLogica.RegiX.NRAEmploymentContractsAdapter.EikTypeType.EGN
//            };

//            EmploymentContractsRequest searchCriteria = new EmploymentContractsRequest()
//            {
//                Identity = parameters
//            };

//            TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters aparams = new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters();
//            aparams.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };
//            aparams.CitizenEGN = "egn3;,kl";
//            aparams.ClientIPAddress = "200.929.29.29";
//            aparams.EmployeeEGN = "1632598847";

//            var result = adapter.GetEmploymentContracts(searchCriteria, accessMatrix, aparams);

//            using (StreamWriter outfile = new StreamWriter("GetEmploymentContractsTest.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(result.XmlSerialize());
//            }

//            //XsltUtils.RunXsltAndWriteHtml("NRAEmploymentContractsAdapter", "EmploymentContractsRequest", result.Data.Request.XmlSerialize());
//            //XsltUtils.RunXsltAndWriteHtml("NRAEmploymentContractsAdapter", "EmploymentContractsResponse", result.Data.Response.XmlSerialize());

//            //XmlDocument doc = new XmlDocument();
//            //doc.LoadXml(result.XmlSerialize());
//            //if (SigningUtils.HasSignature(doc))
//            //{
//            //    bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc);
//            //    if (isValid)
//            //    {
//            //        Assert.IsTrue(true);
//            //    }
//            //}
//            //else
//            //{
//            //    Assert.IsTrue(true);
//            //}
//        }

//        [TestMethod]
//        public void GetEmploymentContractsHttpsTest()
//        {
//            NRAEmploymentContractsAdapter adapter = new NRAEmploymentContractsAdapter();
//            adapter.SetParameter("WebServiceUrl", "https://172.16.69.13:4434/RegiX.NRAObligatedPersonsAdapterMockupSSL/NRAObligatedPersonsService.svc/GetEmploymentContracts");
//            adapter.SetParameter("ServiceSslCertificateThumbPrint", "62e243badfaeae6df21dca81ff9cdf7644020469");
//            //adapter.SetParameter("WebServiceUrl", "https://nraapp01.nra.bg/rs/regix/econtract");
//            var accessMatrix = AccessMatrix.CreateForType(typeof(EmploymentContractsResponse));

//            TechnoLogica.RegiX.NRAEmploymentContractsAdapter.IdentityTypeRequest parameters = new TechnoLogica.RegiX.NRAEmploymentContractsAdapter.IdentityTypeRequest()
//            {
//                ID = "8310188539",
//                TYPE = TechnoLogica.RegiX.NRAEmploymentContractsAdapter.EikTypeType.EGN
//            };

//            EmploymentContractsRequest searchCriteria = new EmploymentContractsRequest()
//            {
//                Identity = parameters
//            };

//            TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters aparams = new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters();
//            aparams.CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { Remark = "RegiXTest" };
//            aparams.CitizenEGN = "egn3;,kl";
//            aparams.ClientIPAddress = "200.929.29.29";
//            aparams.EmployeeEGN = "1632598847";

//            var result = adapter.GetEmploymentContracts(searchCriteria, accessMatrix, aparams);

//            using (StreamWriter outfile = new StreamWriter("GetEmploymentContractsTest.xml", false, System.Text.Encoding.UTF8))
//            {
//                outfile.Write(result.XmlSerialize());
//            }
//        }


//        /*В момента методът не работи правилно*/

//        //[TestMethod]
//        //public void GetEmploymentContractsNULLTest()
//        //{
//        //    NRAEmploymentContractsAdapter adapter = new NRAEmploymentContractsAdapter();
//        //    var accessMatrix = AccessMatrix.CreateForType(typeof(EmploymentContractsResponse));

//        //    EmploymentContractsRequest searchCriteria = new EmploymentContractsRequest()
//        //    {
//        //        Identity = new TechnoLogica.RegiX.NRAEmploymentContractsAdapter.IdentityTypeRequest()
//        //            {
//        //                ID = String.Empty,
//        //                TYPE = TechnoLogica.RegiX.NRAEmploymentContractsAdapter.EikTypeTypeRequest.EGN
//        //            }
//        //    };
//        //    var result = adapter.GetEmploymentContracts(searchCriteria, accessMatrix, new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters());
//        //    using (StreamWriter outfile = new StreamWriter("GetEmploymentContractsNULLTest.xml", false, System.Text.Encoding.UTF8))
//        //    {
//        //        outfile.Write(result.XmlSerialize());
//        //    }

//        //    XsltUtils.RunXsltAndWriteHtml("NRAEmploymentContractsAdapter", "EmploymentContractsRequest", result.Data.Request.XmlSerialize());
//        //    XsltUtils.RunXsltAndWriteHtml("NRAEmploymentContractsAdapter", "EmploymentContractsResponse", result.Data.Response.XmlSerialize());

//        //    XmlDocument doc = new XmlDocument();
//        //    doc.LoadXml(result.XmlSerialize());
//        //    if (SigningUtils.HasSignature(doc))
//        //    {
//        //        bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc);
//        //        if (isValid)
//        //        {
//        //            Assert.IsTrue(true);
//        //        }
//        //    }
//        //    else
//        //    {
//        //        Assert.IsTrue(true);
//        //    }
//        //}

//        [TestMethod]
//        public void GetEmploymentContractsStatusNotOkTest()
//        {
//            NRAEmploymentContractsAdapter adapter = new NRAEmploymentContractsAdapter();
//            var accessMatrix = AccessMatrix.CreateForType(typeof(EmploymentContractsResponse));

//            EmploymentContractsRequest searchCriteria = new EmploymentContractsRequest()
//            {
//                Identity = new TechnoLogica.RegiX.NRAEmploymentContractsAdapter.IdentityTypeRequest()
//                {
//                    ID = "StatusNotOk",
//                    TYPE = TechnoLogica.RegiX.NRAEmploymentContractsAdapter.EikTypeType.EGN
//                }
//            };
//            try
//            {
//                var result = adapter.GetEmploymentContracts(searchCriteria, accessMatrix, new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters());
//                Assert.Fail();
//            }
//            catch (Exception ex)
//            {
//                if (ex.InnerException != null && ex.InnerException.Message.StartsWith("StatusCode:"))
//                {
//                    Assert.IsTrue(true);
//                }
//                else
//                {
//                    throw ex;
//                }
//            }
//        }

//    }
//}
