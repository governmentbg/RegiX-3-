using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.RDSOAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.TestUtils;

namespace TechnoLogica.RegiX.RDSOAdapter.Tests
{
    [TestClass]
    public class RDSOAdapterTest : AdapterTest<AdapterService.RDSOAdapter, IRDSOAdapter>
    {
        //[TestMethod]
        //public void RDSOAdapter_CheckHealthCheckAndParamtersTest()
        //{
        //    RDSOAdapter adapter = new RDSOAdapter();
        //    //test GetParameters , and ConnectionString
        //    var connectionString = adapter.GetParameters().ParameterList.Where(p => p.Key == TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName).FirstOrDefault();
        //    //test SetParameter
        //    adapter.SetParameter(TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName, "http://regix2-adapters.regix.tlogica.com/MockRegisters/RegiX.RDSOAdapterMockup/RDSOServiceimplServiceInterfaces.svc");
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
        //public void RDSOAdapter_CheckRegisterConnection()
        //{
        //    RDSOAdapter adapter = new RDSOAdapter();
        //    string result = adapter.CheckRegisterConnection();
        //    Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
        //}

        //[TestMethod]
        //public void RDSOAdapterTestDiplomaDocument_83112167890()
        //{
        //    RDSOAdapter rdso = new RDSOAdapter();
        //    var mockupServiceAdress = "http://localhost:50203/MonSoapService.svc";
        //    rdso.SetParameter(TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName, mockupServiceAdress);
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(DiplomaDocumentsType));
        //    DiplomaSearchType searchCriteria = new DiplomaSearchType() { StudentID = "83112167890", DocumentNumber = "070350" };

        //    var result = rdso.GetDiplomaInfo(searchCriteria, accessMatrix,
        //        new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters
        //        {
        //            CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext
        //            {
        //                Remark = "RegiX Test"
        //            }
        //        });
        //    bool testResult = true;
        //    foreach (DiplomaDocumentType d in result.Data.Response.DiplomaDocument)
        //    {
        //        if (d.intStudentID != "83112167890")
        //        {
        //            testResult = false;
        //        }
        //        if (!d.vcPrnNo.Contains("070350"))
        //        {
        //            testResult = false;
        //        }
        //    }
        //    using (StreamWriter outfile = new StreamWriter("resultDiploma.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("RDSOAdapter", "DiplomaDocumentsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("RDSOAdapter", "RDSO_DiplomaInfo", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(testResult);
        //}
        //[TestMethod]
        //public void RDSOAdapterTestDiplomaDocument_default()
        //{
        //    RDSOAdapter rdso = new RDSOAdapter();
        //    var mockupServiceAdress = "http://localhost:50203/MonSoapService.svc";
        //    rdso.SetParameter(TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName, mockupServiceAdress);
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(DiplomaDocumentsType));
        //    DiplomaSearchType searchCriteria = new DiplomaSearchType() { StudentID = "1111111110", DocumentNumber = "44545" };

        //    var result = rdso.GetDiplomaInfo(searchCriteria, accessMatrix,
        //        new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters
        //        {
        //            CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext
        //            {
        //                Remark = "RegiX Test"
        //            }
        //        });
        //    bool testResult = true;
        //    foreach (DiplomaDocumentType d in result.Data.Response.DiplomaDocument)
        //    {
        //        if (d.intStudentID != "1111111110")
        //        {
        //            testResult = false;
        //        }
        //        if (!d.vcPrnNo.Contains("44545"))
        //        {
        //            testResult = false;
        //        }
        //    }
        //    using (StreamWriter outfile = new StreamWriter("resultDiploma.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("RDSOAdapter", "DiplomaDocumentsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("RDSOAdapter", "RDSO_DiplomaInfo", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(testResult);
        //}


        //[TestMethod]
        //public void RDSOAdapterTestCertifiedDocument_83112167890()
        //{
        //    RDSOAdapter rdso = new RDSOAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(CertifiedDocumentsType));
        //    CertifiedDocumentsSearchType searchCriteria = new CertifiedDocumentsSearchType() { StudentID = "83112167890", DocumentNumber = "070350" };
        //    var result = rdso.GetCertifiedDiplomaInfo(searchCriteria, accessMatrix,
        //        new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters
        //        {
        //            CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext 
        //            {
        //                Remark = "RegiX Test"
        //            }
        //        });
        //    bool testResult = true;
        //    foreach (CertifiedDocumentType d in result.Data.Response.CertifiedDocument)
        //    {
        //        if (!d.intStudentID.Equals("83112167890"))
        //        {
        //            testResult = false;
        //        }
        //        if (!d.vcPrnNo.Contains("070350"))
        //        {
        //            testResult = false;
        //        }
        //    }
        //    using (StreamWriter outfile = new StreamWriter("resultCertified.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }


        //    XsltUtils.RunXsltAndWriteHtml("RDSOAdapter", "CertifiedDocumentsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("RDSOAdapter", "CertifiedDiploma", result.Data.Response.XmlSerialize());


        //    Assert.IsTrue(testResult);
        //}

        //[TestMethod]
        //public void RDSOAdapterTestCertifiedDocument_default()
        //{
        //    RDSOAdapter rdso = new RDSOAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(CertifiedDocumentsType));
        //    CertifiedDocumentsSearchType searchCriteria = new CertifiedDocumentsSearchType() { StudentID = "1111111110", DocumentNumber = "070350" };
        //    var result = rdso.GetCertifiedDiplomaInfo(searchCriteria, accessMatrix,
        //        new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters
        //        {
        //            CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext
        //            {
        //                Remark = "RegiX Test"
        //            }
        //        });
        //    bool testResult = true;
        //    foreach (CertifiedDocumentType d in result.Data.Response.CertifiedDocument)
        //    {
        //        if (!d.intStudentID.Equals("1111111110"))
        //        {
        //            testResult = false;
        //        }
        //        if (!d.vcPrnNo.Contains("070350"))
        //        {
        //            testResult = false;
        //        }
        //    }
        //    using (StreamWriter outfile = new StreamWriter("resultCertified.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }


        //    XsltUtils.RunXsltAndWriteHtml("RDSOAdapter", "CertifiedDocumentsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("RDSOAdapter", "CertifiedDiploma", result.Data.Response.XmlSerialize());


        //    Assert.IsTrue(testResult);
        //}
    }
}


