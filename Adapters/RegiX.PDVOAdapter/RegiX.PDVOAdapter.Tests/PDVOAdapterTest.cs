using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.PDVOAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.TestUtils;

namespace TechnoLogica.RegiX.PDVOAdapter.Tests
{
    [TestClass]
    public class PDVOAdapterTest : AdapterTest<AdapterService.PDVOAdapter, IPDVOAdapter>
    {
        //[TestMethod]
        //public void PDVOAdapterTest_CheckHealthCheckAndParamtersTest()
        //{
        //    PDVOAdapter adapter = new PDVOAdapter();
        //    //test GetParameters , and ConnectionString
        //    var connectionString = adapter.GetParameters().ParameterList.Where(p => p.Key == TechnoLogica.RegiX.Common.Constants.ConnectionStringParameterKeyName).FirstOrDefault();
        //    //test SetParameter
        //    adapter.SetParameter(TechnoLogica.RegiX.Common.Constants.ConnectionStringParameterKeyName, connectionString.CurrentValue);
        //    //test HCfunctions
        //    var hcFunctions = adapter.GetHealthCheckFunctions();
        //    hcFunctions.HealthInfosList.ForEach(f => adapter.CheckHealthFunction(f.Key));
        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void PDVOAdapterTest_CheckRegisterConnection()
        //{
        //    PDVOAdapter adapter = new PDVOAdapter();
        //    string result = adapter.CheckRegisterConnection();
        //    Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
        //}

        //[TestMethod]
        //public void PDVOAdapter_GetAcademicRecognition()
        //{
        //    PDVOAdapter adapter = new PDVOAdapter();

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(AcademicRecognitionResponseType));
        //    AcademicRecognitionRequestType operation = new AcademicRecognitionRequestType();
        //    operation.InternalAppNum = "654321XX"; //123456XX или 654321XX
        //    operation.InternalAppDate = new DateTime(2012, 1, 1);

        //    var result = adapter.GetAcademicRecognition(operation, accessMatrix,
        //        new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters
        //        {
        //            CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext
        //            {
        //                Remark = "RegiX Test"
        //            }
        //        });
        //    using (StreamWriter outfile = new StreamWriter("GetAcademicRecognition.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }
        //    XsltUtils.RunXsltAndWriteHtml("PDVOAdapter", "AcademicRecognitionRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("PDVOAdapter", "NACID", result.Data.Response.XmlSerialize());
        //    Assert.IsNotNull(result);
        //}
    }
}


