using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.MVRMPSAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.TestUtils;

namespace TechnoLogica.RegiX.MVRMPSAdapter.Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class MVRMPSAdapterTest : AdapterTest<AdapterService.MVRMPSAdapter, IMVRMPSAdapter>
    {
        //private string _serviceurl = "http://172.16.69.13:8078/MVRMockup/MVRMockupService.svc";
        //[TestMethod]
        //public void MVRMPSAdapter_CheckHealthCheckAndParamtersTest()
        //{
        //    MVRMPSAdapter adapter = new MVRMPSAdapter();
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
        //public void MVRMPSAdapter_CheckRegisterConnection()
        //{
        //    MVRMPSAdapter adapter = new MVRMPSAdapter();
        //    string result = adapter.CheckRegisterConnection();
        //    Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
        //}

        //[TestMethod]
        //public void MVRMPSAdapterTestMethod()
        //{

        //    XmlDocument identityXML = new XmlDocument();
        //    identityXML.Load("../../eID.xml");

        //    MVRMPSAdapter mvrmpsAdapter = new MVRMPSAdapter();
        //    mvrmpsAdapter.SetParameter("WebServiceUrl", _serviceurl);
        //    var result = mvrmpsAdapter.GetMotorVehicleRegistrationInfo(new MotorVehicleRegistrationRequestType { Identifier = "ю7801ун" },
        //                                      AccessMatrix.CreateForType(typeof(MotorVehicleRegistrationResponseType)),
        //                                      new AdapterAdditionalParameters 
        //                                      { 
        //                                          OrganizationUnit = "TL", 
        //                                          CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext() 
        //                                          { 
        //                                              Remark = "RegiXTest" 
        //                                          }, 
        //                                          EIDToken = identityXML.InnerXml, 
        //                                          ClientIPAddress = "198.25.14.521",
        //                                          SignResult = true,
        //                                          ReturnAccessMatrix = true
        //                                      });
        //    using (StreamWriter outfile = new StreamWriter("MVRMPS.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("MVRMPSAdapter", "MotorVehicleRegistrationRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("MVRMPSAdapter", "MotorVehicleRegistrationResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(result.Data.Response.ReturnInformation.ReturnCode == "0000");
        //}

        //[TestMethod]
        //public void MVRMPSAdapterNotFoundTestMethod()
        //{

        //    XmlDocument identityXML = new XmlDocument();
        //    identityXML.Load("../../eID.xml");

        //    MVRMPSAdapter mvrmpsAdapter = new MVRMPSAdapter();
        //    mvrmpsAdapter.SetParameter("WebServiceUrl", _serviceurl);
        //    var result = mvrmpsAdapter.GetMotorVehicleRegistrationInfo
        //        (
        //            new MotorVehicleRegistrationRequestType
        //            {
        //                Identifier = "notfound"
        //            },
        //            AccessMatrix.CreateForType(typeof(MotorVehicleRegistrationResponseType)),
        //                new AdapterAdditionalParameters
        //                {
        //                    OrganizationUnit = "TL",
        //                    CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext()
        //                    {
        //                        Remark = "RegiXTest"
        //                    },
        //                    EIDToken = identityXML.InnerXml,
        //                    ClientIPAddress = "198.25.14.521",
        //                    SignResult = true,
        //                    ReturnAccessMatrix = true
        //                }
        //         );
        //    using (StreamWriter outfile = new StreamWriter("MVRMPS.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("MVRMPSAdapter", "MotorVehicleRegistrationRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("MVRMPSAdapter", "MotorVehicleRegistrationResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(result.Data.Response.ReturnInformation.ReturnCode == "0100");
        //}

        //[TestMethod]
        //public void MVRMPSAdapterErrorTestMethod()
        //{

        //    XmlDocument identityXML = new XmlDocument();
        //    identityXML.Load("../../eID.xml");

        //    MVRMPSAdapter mvrmpsAdapter = new MVRMPSAdapter();
        //    mvrmpsAdapter.SetParameter("WebServiceUrl", _serviceurl);
        //    var result = mvrmpsAdapter.GetMotorVehicleRegistrationInfo
        //        (
        //            new MotorVehicleRegistrationRequestType
        //            {
        //                Identifier = "error"
        //            },
        //            AccessMatrix.CreateForType(typeof(MotorVehicleRegistrationResponseType)),
        //                new AdapterAdditionalParameters
        //                {
        //                    OrganizationUnit = "TL",
        //                    CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext()
        //                    {
        //                        Remark = "RegiXTest"
        //                    },
        //                    EIDToken = identityXML.InnerXml,
        //                    ClientIPAddress = "198.25.14.521",
        //                    SignResult = true,
        //                    ReturnAccessMatrix = true
        //                }
        //         );
        //    using (StreamWriter outfile = new StreamWriter("MVRMPS.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("MVRMPSAdapter", "MotorVehicleRegistrationRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("MVRMPSAdapter", "MotorVehicleRegistrationResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(result.Data.Response.ReturnInformation.ReturnCode == "1111");
        //}

        //[TestMethod]
        //public void MVRMPSAdapterExceptionTestMethod()
        //{

        //    XmlDocument identityXML = new XmlDocument();
        //    identityXML.Load("../../eID.xml");

        //    MVRMPSAdapter mvrmpsAdapter = new MVRMPSAdapter();
        //    mvrmpsAdapter.SetParameter("WebServiceUrl", _serviceurl);
        //    try
        //    {
        //        var result = mvrmpsAdapter.GetMotorVehicleRegistrationInfo
        //        (
        //            new MotorVehicleRegistrationRequestType
        //            {
        //                Identifier = "exception"
        //            },
        //            AccessMatrix.CreateForType(typeof(MotorVehicleRegistrationResponseType)),
        //                new AdapterAdditionalParameters
        //                {
        //                    OrganizationUnit = "TL",
        //                    CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext()
        //                    {
        //                        Remark = "RegiXTest"
        //                    },
        //                    EIDToken = identityXML.InnerXml,
        //                    ClientIPAddress = "198.25.14.521",
        //                    SignResult = true,
        //                    ReturnAccessMatrix = true
        //                }
        //         );
        //        using (StreamWriter outfile = new StreamWriter("MVRMPS.xml", false, System.Text.Encoding.UTF8))
        //        {
        //            outfile.Write(result.XmlSerialize());
        //        }

        //        XsltUtils.RunXsltAndWriteHtml("MVRMPSAdapter", "MotorVehicleRegistrationRequest", result.Data.Request.XmlSerialize());
        //        XsltUtils.RunXsltAndWriteHtml("MVRMPSAdapter", "MotorVehicleRegistrationResponse", result.Data.Response.XmlSerialize());
        //        Assert.Fail();
        //    }
        //    catch (System.Exception ex)
        //    {
        //        Assert.IsTrue(ex.GetType().BaseType.Name == "FaultException" && ex.Message == "RegiX.MVRMockService.MVRService is throwing new test exception!");
        //    }
        //}

        //[TestMethod]
        //public void MVRMPSAdapterV2TestMethod()
        //{

        //    XmlDocument identityXML = new XmlDocument();
        //    identityXML.Load("../../eID.xml");

        //    MVRMPSAdapter mvrmpsAdapter = new MVRMPSAdapter();
        //    //mvrmpsAdapter.SetParameter("WebServiceUrl", _serviceurl);
        //    var result = mvrmpsAdapter.GetMotorVehicleRegistrationInfoV2(new MotorVehicleRegistrationRequestTypeV2 { Identifier = "CA7100XK" },
        //                                      AccessMatrix.CreateForType(typeof(GetMotorVehicleRegistrationInfoV2ResponseType)),
        //                                      new AdapterAdditionalParameters
        //                                      {
        //                                          OrganizationUnit = "TL",
        //                                          CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext()
        //                                          {
        //                                              Remark = "RegiXTest"
        //                                          },
        //                                          EIDToken = identityXML.InnerXml,
        //                                          ClientIPAddress = "198.25.14.521",
        //                                          SignResult = true,
        //                                          ReturnAccessMatrix = true
        //                                      });
        //    using (StreamWriter outfile = new StreamWriter("MVRMPSV2.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("MVRMPSAdapter", "MotorVehicleRegistrationRequestV2", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("MVRMPSAdapter", "MotorVehicleRegistrationResponseV2", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(result.Data.Response.Response.ReturnInformation.ReturnCode == "0000");
        //}

        //[TestMethod]
        //public void MVRMPSAdapterV3TestMethod()
        //{

        //    XmlDocument identityXML = new XmlDocument();
        //    identityXML.Load("../../eID.xml");

        //    MVRMPSAdapter mvrmpsAdapter = new MVRMPSAdapter();
        //    //mvrmpsAdapter.SetParameter("WebServiceUrl", _serviceurl);
        //    var result = mvrmpsAdapter.GetMotorVehicleRegistrationInfoV3(new MotorVehicleRegistrationRequestTypeV3 { Identifier = "CA7100XK" },
        //                                      AccessMatrix.CreateForType(typeof(GetMotorVehicleRegistrationInfoV3ResponseType)),
        //                                      new AdapterAdditionalParameters
        //                                      {
        //                                          OrganizationUnit = "TL",
        //                                          CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext()
        //                                          {
        //                                              Remark = "RegiXTest"
        //                                          },
        //                                          EIDToken = identityXML.InnerXml,
        //                                          ClientIPAddress = "198.25.14.521",
        //                                          SignResult = true,
        //                                          ReturnAccessMatrix = true
        //                                      });
        //    using (StreamWriter outfile = new StreamWriter("MVRMPSV3.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    // XsltUtils.RunXsltAndWriteHtml("MVRMPSAdapter", "MotorVehicleRegistrationRequestV3", result.Data.Request.XmlSerialize());
        //    //XsltUtils.RunXsltAndWriteHtml("MVRMPSAdapter", "MotorVehicleRegistrationResponseV3", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(result.Data.Response.Response.ReturnInformation.ReturnCode == "0000");
        //}
    }
}


