using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.MVRBDSAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.TestUtils;

namespace TechnoLogica.RegiX.MVRBDSAdapter.Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    /// 
    [TestClass]
    public class MVRBDSAdapterTest : AdapterTest<AdapterService.MVRBDSAdapter, IMVRBDSAdapter>
    {
        //private string _serviceurl = "http://172.16.69.13:8078/MVRMockup/MVRMockupService.svc";
        //[TestMethod]
        //public void MVRBDSAdapter_CheckHealthCheckAndParamtersTest()
        //{
        //    MVRBDSAdapter adapter = new MVRBDSAdapter();
        //    //test GetParameters , and ConnectionString
        //    var connectionString = adapter.GetParameters().ParameterList.Where(p => p.Key == TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName).FirstOrDefault();
        //    //test SetParameter
        //    adapter.SetParameter(TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName, connectionString.CurrentValue);
        //    //test HCfunctions
        //    var hcFunctions = adapter.GetHealthCheckFunctions();
        //    string checkHealthFunctionResult = string.Empty;
        //    hcFunctions.HealthInfosList.ForEach(f =>
        //    {
        //        checkHealthFunctionResult = checkHealthFunctionResult + f.Key + ":" + adapter.CheckHealthFunction(f.Key) + ";\r\n";
        //    });
        //    using (StreamWriter outfile = new StreamWriter("CheckHealthFunctions.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(checkHealthFunctionResult);
        //    }
        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void MVRBDSAdapter_CheckRegisterConnection()
        //{
        //    MVRBDSAdapter adapter = new MVRBDSAdapter();
        //    string result = adapter.CheckRegisterConnection();
        //    Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
        //}
        //[TestMethod]
        //public void MVRBDSAdapterTestMethod()
        //{
        //    XmlDocument identityXML = new XmlDocument();
        //    identityXML.Load("../../eID.xml");

        //    MVRBDSAdapter mvrbdsAdapter = new MVRBDSAdapter();
        //    mvrbdsAdapter.SetParameter("WebServiceUrl", _serviceurl);


        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters()
        //    {
        //        OrganizationUnit = "TL",
        //        EIDToken = identityXML.InnerXml,
        //        CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { LawReason = "Regixtest" },
        //        SignResult = true,
        //        ReturnAccessMatrix = true
        //    };

        //    var result = mvrbdsAdapter.GetPersonalIdentity(new PersonalIdentityInfoRequestType() { EGN = "1111111111", IdentityDocumentNumber = "100003755" },
        //                                      AccessMatrix.CreateForType(typeof(PersonalIdentityInfoResponseType)),
        //                                      additionalParameters);

        //    XsltUtils.RunXsltAndWriteHtml("MVRBDSAdapter", "PersonalIdentityInfoRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("MVRBDSAdapter", "PersonalIdentityInoResponse", result.Data.Response.XmlSerialize());

        //    using (StreamWriter outfile = new StreamWriter("MVRBDS.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }
        //    Assert.IsTrue(result.Data.Response.ReturnInformations.ReturnCode == "0000");
        //}
        //[TestMethod]
        //public void MVRBDSAdapterTestMethodV2()
        //{
        //    XmlDocument identityXML = new XmlDocument();
        //    identityXML.Load("../../eID.xml");

        //    MVRBDSAdapter mvrbdsAdapter = new MVRBDSAdapter();
        //    mvrbdsAdapter.SetParameter("WebServiceUrlV2", _serviceurl);


        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters()
        //    {
        //        OrganizationUnit = "TL",
        //        EIDToken = identityXML.InnerXml,
        //        CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() {  LawReason = "Regixtest"},
        //        SignResult = true,
        //        ReturnAccessMatrix = true
        //    };

        //    var result = mvrbdsAdapter.GetPersonalIdentityV2(new TechnoLogica.RegiX.MVRBDSAdapterV2.PersonalIdentityInfoRequestType() { EGN = "1234567890", IdentityDocumentNumber = "100003755" },
        //                                      AccessMatrix.CreateForType(typeof(TechnoLogica.RegiX.MVRBDSAdapterV2.PersonalIdentityInfoResponseType)),
        //                                      additionalParameters);

        //    XsltUtils.RunXsltAndWriteHtml("MVRBDSAdapter", "PersonalIdentityInfoRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("MVRBDSAdapter", "PersonalIdentityInoResponse", result.Data.Response.XmlSerialize());

        //    using (StreamWriter outfile = new StreamWriter("MVRBDS.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }
        //    Assert.IsTrue(result.Data.Response.ReturnInformations.ReturnCode == "0000");
        //}

        //[TestMethod]
        //public void MVRBDSAdapterNotFoundTestMethod()
        //{
        //    XmlDocument identityXML = new XmlDocument();
        //    identityXML.Load("../../eID.xml");

        //    MVRBDSAdapter mvrbdsAdapter = new MVRBDSAdapter();
        //    mvrbdsAdapter.SetParameter("WebServiceUrl", _serviceurl);

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters()
        //    {
        //        OrganizationUnit = "TL",
        //        EIDToken = identityXML.InnerXml,
        //        CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { LawReason = "Regixtest" },
        //        SignResult = true,
        //        ReturnAccessMatrix = true
        //    };

        //    var result = mvrbdsAdapter.GetPersonalIdentity(new PersonalIdentityInfoRequestType() { EGN = "notfound", IdentityDocumentNumber = "100003755" },
        //                                      AccessMatrix.CreateForType(typeof(PersonalIdentityInfoResponseType)),
        //                                      additionalParameters);

        //    XsltUtils.RunXsltAndWriteHtml("MVRBDSAdapter", "PersonalIdentityInfoRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("MVRBDSAdapter", "PersonalIdentityInoResponse", result.Data.Response.XmlSerialize());

        //    using (StreamWriter outfile = new StreamWriter("MVRBDSNotFound.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }
        //    Assert.IsTrue(result.Data.Response.ReturnInformations.ReturnCode == "0100");
        //}

        //[TestMethod]
        //public void MVRBDSAdapterErrorTestMethod()
        //{
        //    XmlDocument identityXML = new XmlDocument();
        //    identityXML.Load("../../eID.xml");

        //    MVRBDSAdapter mvrbdsAdapter = new MVRBDSAdapter();
        //    mvrbdsAdapter.SetParameter("WebServiceUrl", _serviceurl);

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters()
        //    {
        //        OrganizationUnit = "TL",
        //        EIDToken = identityXML.InnerXml,
        //        CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { LawReason = "Regixtest" },
        //        SignResult = true,
        //        ReturnAccessMatrix = true
        //    };

        //    var result = mvrbdsAdapter.GetPersonalIdentity(new PersonalIdentityInfoRequestType() { EGN = "error", IdentityDocumentNumber = "100003755" },
        //                                      AccessMatrix.CreateForType(typeof(PersonalIdentityInfoResponseType)),
        //                                      additionalParameters);

        //    XsltUtils.RunXsltAndWriteHtml("MVRBDSAdapter", "PersonalIdentityInfoRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("MVRBDSAdapter", "PersonalIdentityInoResponse", result.Data.Response.XmlSerialize());

        //    using (StreamWriter outfile = new StreamWriter("MVRBDSError.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }
        //    Assert.IsTrue(result.Data.Response.ReturnInformations.ReturnCode == "1111");
        //}

        //[TestMethod]
        //public void MVRBDSAdapterexceptionTestMethod()
        //{
        //    XmlDocument identityXML = new XmlDocument();
        //    identityXML.Load("../../eID.xml");

        //    MVRBDSAdapter mvrbdsAdapter = new MVRBDSAdapter();
        //    mvrbdsAdapter.SetParameter("WebServiceUrl", _serviceurl);

        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters()
        //    {
        //        OrganizationUnit = "TL",
        //        EIDToken = identityXML.InnerXml,
        //        CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() { LawReason = "Regixtest" },
        //        SignResult = true,
        //        ReturnAccessMatrix = true
        //    };
        //    try
        //    {
        //        var result = mvrbdsAdapter.GetPersonalIdentity(new PersonalIdentityInfoRequestType() { EGN = "exception", IdentityDocumentNumber = "100003755" },
        //                                          AccessMatrix.CreateForType(typeof(PersonalIdentityInfoResponseType)),
        //                                          additionalParameters);

        //        XsltUtils.RunXsltAndWriteHtml("MVRBDSAdapter", "PersonalIdentityInfoRequest", result.Data.Request.XmlSerialize());
        //        XsltUtils.RunXsltAndWriteHtml("MVRBDSAdapter", "PersonalIdentityInoResponse", result.Data.Response.XmlSerialize());

        //        using (StreamWriter outfile = new StreamWriter("MVRBDSexception.xml", false, System.Text.Encoding.UTF8))
        //        {
        //            outfile.Write(result.XmlSerialize());
        //        }
        //        Assert.Fail();
        //    }
        //    catch(System.Exception ex)
        //    {
        //        Assert.IsTrue(ex.GetType().BaseType.Name == "FaultException" && ex.Message == "RegiX.MVRMockService.MVRService is throwing new test exception!");
        //    }
        //}

    }
}


