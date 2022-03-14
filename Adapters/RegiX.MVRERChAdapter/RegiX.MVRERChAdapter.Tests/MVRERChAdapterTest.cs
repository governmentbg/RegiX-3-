using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.MVRERChAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.TestUtils;

namespace TechnoLogica.RegiX.MVRERChAdapter.Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class MVRERChAdapterTest : AdapterTest<AdapterService.MVRERChAdapter, IMVRERChAdapter>
    {
    //    private string _serviceurl = "http://172.16.69.13:8078/MVRMockup/MVRMockupService.svc";
    //    [TestMethod]
    //    public void MVRERChAdapter_CheckHealthCheckAndParamtersTest()
    //    {
    //        MVRERChAdapter adapter = new MVRERChAdapter();
    //        //test GetParameters , and ConnectionString
    //        var connectionString = adapter.GetParameters().ParameterList.Where(p => p.Key == TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName).FirstOrDefault();
    //        //test SetParameter
    //        adapter.SetParameter(TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName, connectionString.CurrentValue);
    //        //test HCfunctions
    //        var hcFunctions = adapter.GetHealthCheckFunctions();
    //        string checkHealthFunctionResult = string.Empty;
    //        hcFunctions.HealthInfosList.ForEach(f =>
    //        {
    //            checkHealthFunctionResult = checkHealthFunctionResult + f.Key + ":" + adapter.CheckHealthFunction(f.Key) + ";\r\n";
    //        });
    //        using (StreamWriter outfile = new StreamWriter("CheckHealthFunctions.xml", false, System.Text.Encoding.UTF8))
    //        {
    //            outfile.Write(checkHealthFunctionResult);
    //        }
    //        Assert.IsTrue(true);
    //    }

    //    [TestMethod]
    //    public void MVRERChAdapter_CheckRegisterConnection()
    //    {
    //        MVRERChAdapter adapter = new MVRERChAdapter();
    //        string result = adapter.CheckRegisterConnection();
    //        Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
    //    }


    //    [TestMethod]
    //    public void MVRERChTestMethodSuccess()
    //    {
    //        XmlDocument identityXML = new XmlDocument();
    //        identityXML.Load("../../eID.xml");
        
    //        MVRERChAdapter mvrerchAdapter = new MVRERChAdapter();
    //        mvrerchAdapter.SetParameter("WebServiceUrl", _serviceurl);

    //        ForeignIdentityInfoRequestType req = new ForeignIdentityInfoRequestType();
    //        req.IdentifierType = IdentifierType.LNCh;
    //        req.Identifier = "1000006058";


    //        var result = mvrerchAdapter.GetForeignIdentity(req,
    //                                          AccessMatrix.CreateForType(typeof(ForeignIdentityInfoResponseType)),
    //                                          new AdapterAdditionalParameters()
    //                                          {
    //                                              OrganizationUnit = "TL",
    //                                              EIDToken = identityXML.InnerXml,
    //                                              ClientIPAddress = "194.12.85.142",
    //                                              CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext
    //                                              {
    //                                                   AdministrationName = "Technologica",
    //                                                   AdministrationOId = "213213123.3213123.3123",
    //                                                   LawReason = "Test"
    //                                              }, 
    //                                              ReturnAccessMatrix = true,
    //                                              SignResult = true
    //                                          });
    //        using (StreamWriter outfile = new StreamWriter("MVRERCh.xml", false, System.Text.Encoding.UTF8))
    //        {
    //            outfile.Write(result.XmlSerialize());
    //        }

    //        XsltUtils.RunXsltAndWriteHtml("MVRERChAdapter", "ForeignIdentityInfoRequest", result.Data.Request.XmlSerialize());
    //        XsltUtils.RunXsltAndWriteHtml("MVRERChAdapter", "ForeignIdentityInfoResponse", result.Data.Response.XmlSerialize());

    //        Assert.IsTrue(result.Data.Response.ReturnInformations.ReturnCode == "0000");
    //    }

    //    [TestMethod]
    //    public void MVRERChNotFoundTestMethodSuccess()
    //    {
    //        XmlDocument identityXML = new XmlDocument();
    //        identityXML.Load("../../eID.xml");

    //        MVRERChAdapter mvrerchAdapter = new MVRERChAdapter();
    //        mvrerchAdapter.SetParameter("WebServiceUrl", _serviceurl);

    //        ForeignIdentityInfoRequestType req = new ForeignIdentityInfoRequestType();
    //        req.IdentifierType = IdentifierType.LNCh;
    //        req.Identifier = "notfound";


    //        var result = mvrerchAdapter.GetForeignIdentity(req,
    //                                          AccessMatrix.CreateForType(typeof(ForeignIdentityInfoResponseType)),
    //                                          new AdapterAdditionalParameters()
    //                                          {
    //                                              OrganizationUnit = "TL",
    //                                              EIDToken = identityXML.InnerXml,
    //                                              ClientIPAddress = "194.12.85.142",
    //                                              CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext
    //                                              {
    //                                                  AdministrationName = "Technologica",
    //                                                  AdministrationOId = "213213123.3213123.3123",
    //                                                  LawReason = "Test"
    //                                              },
    //                                              ReturnAccessMatrix = true,
    //                                              SignResult = true
    //                                          });
    //        using (StreamWriter outfile = new StreamWriter("MVRERCh.xml", false, System.Text.Encoding.UTF8))
    //        {
    //            outfile.Write(result.XmlSerialize());
    //        }

    //        XsltUtils.RunXsltAndWriteHtml("MVRERChAdapter", "ForeignIdentityInfoRequest", result.Data.Request.XmlSerialize());
    //        XsltUtils.RunXsltAndWriteHtml("MVRERChAdapter", "ForeignIdentityInfoResponse", result.Data.Response.XmlSerialize());

    //        Assert.IsTrue(result.Data.Response.ReturnInformations.ReturnCode == "0100");
    //    }

    //    [TestMethod]
    //    public void MVRERChErrorTestMethodSuccess()
    //    {
    //        XmlDocument identityXML = new XmlDocument();
    //        identityXML.Load("../../eID.xml");

    //        MVRERChAdapter mvrerchAdapter = new MVRERChAdapter();
    //        mvrerchAdapter.SetParameter("WebServiceUrl", _serviceurl);

    //        ForeignIdentityInfoRequestType req = new ForeignIdentityInfoRequestType();
    //        req.IdentifierType = IdentifierType.LNCh;
    //        req.Identifier = "error";


    //        var result = mvrerchAdapter.GetForeignIdentity(req,
    //                                          AccessMatrix.CreateForType(typeof(ForeignIdentityInfoResponseType)),
    //                                          new AdapterAdditionalParameters()
    //                                          {
    //                                              OrganizationUnit = "TL",
    //                                              EIDToken = identityXML.InnerXml,
    //                                              ClientIPAddress = "194.12.85.142",
    //                                              CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext
    //                                              {
    //                                                  AdministrationName = "Technologica",
    //                                                  AdministrationOId = "213213123.3213123.3123",
    //                                                  LawReason = "Test"
    //                                              },
    //                                              ReturnAccessMatrix = true,
    //                                              SignResult = true
    //                                          });
    //        using (StreamWriter outfile = new StreamWriter("MVRERCh.xml", false, System.Text.Encoding.UTF8))
    //        {
    //            outfile.Write(result.XmlSerialize());
    //        }

    //        XsltUtils.RunXsltAndWriteHtml("MVRERChAdapter", "ForeignIdentityInfoRequest", result.Data.Request.XmlSerialize());
    //        XsltUtils.RunXsltAndWriteHtml("MVRERChAdapter", "ForeignIdentityInfoResponse", result.Data.Response.XmlSerialize());

    //        Assert.IsTrue(result.Data.Response.ReturnInformations.ReturnCode == "1111");
    //    }

    //    [TestMethod]
    //    public void MVRERChExceptionTestMethodSuccess()
    //    {
    //        XmlDocument identityXML = new XmlDocument();
    //        identityXML.Load("../../eID.xml");

    //        MVRERChAdapter mvrerchAdapter = new MVRERChAdapter();
    //        mvrerchAdapter.SetParameter("WebServiceUrl", _serviceurl);

    //        ForeignIdentityInfoRequestType req = new ForeignIdentityInfoRequestType();
    //        req.IdentifierType = IdentifierType.LNCh;
    //        req.Identifier = "exception";
    //        try
    //        {

    //            var result = mvrerchAdapter.GetForeignIdentity(req,
    //                                              AccessMatrix.CreateForType(typeof(ForeignIdentityInfoResponseType)),
    //                                              new AdapterAdditionalParameters()
    //                                              {
    //                                                  OrganizationUnit = "TL",
    //                                                  EIDToken = identityXML.InnerXml,
    //                                                  ClientIPAddress = "194.12.85.142",
    //                                                  CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext
    //                                                  {
    //                                                      AdministrationName = "Technologica",
    //                                                      AdministrationOId = "213213123.3213123.3123",
    //                                                      LawReason = "Test"
    //                                                  },
    //                                                  ReturnAccessMatrix = true,
    //                                                  SignResult = true
    //                                              });
    //            using (StreamWriter outfile = new StreamWriter("MVRERCh.xml", false, System.Text.Encoding.UTF8))
    //            {
    //                outfile.Write(result.XmlSerialize());
    //            }

    //            XsltUtils.RunXsltAndWriteHtml("MVRERChAdapter", "ForeignIdentityInfoRequest", result.Data.Request.XmlSerialize());
    //            XsltUtils.RunXsltAndWriteHtml("MVRERChAdapter", "ForeignIdentityInfoResponse", result.Data.Response.XmlSerialize());
    //            Assert.Fail();
    //        }
    //        catch (System.Exception ex)
    //        {
    //            Assert.IsTrue(ex.GetType().BaseType.Name == "FaultException" && ex.Message == "RegiX.MVRMockService.MVRService is throwing new test exception!");
    //        }
    //    }


    }
}


