using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.MZHAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.TestUtils;

namespace TechnoLogica.RegiX.MZHAdapter.Tests
{
    [TestClass]
    public class MZHAdapterTest : AdapterTest<AdapterService.MZHAdapter, IMZHAdapter>
    {
        //[TestMethod]
        //public void MZHAdapterTest_CheckHealthCheckAndParamtersTest()
        //{
        //    MZHAdapter adapter = new MZHAdapter();
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
        //public void MZHAdapterTest_CheckRegisterConnection()
        //{
        //    MZHAdapter adapter = new MZHAdapter();
        //    string result = adapter.CheckRegisterConnection();
        //    Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
        //}


        //[TestMethod]
        //public void MZHTestMethodSuccess()
        //{
        //    MZHAdapter mzhAdapter = new MZHAdapter();
        //    var result =
        //        mzhAdapter.FarmerDetailsSearch(
        //            new TechnoLogica.RegiX.MZHAdapter.FarmerSearchParametersType() { Parameter = "1234564566" },
        //            AccessMatrix.CreateForType(typeof(FarmerType)), 
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters 
        //            {
        //                CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext
        //                {
        //                     Remark = "RegiXTest"
        //                }
        //            }
        //        );
        //    string res = result.XmlSerialize();
        //    XmlWrite(res, "MZHData.xml", "FarmerSearchResponse.xsd", "http://egov.bg/RegiX/MZH/FarmerSearchResponse");
        //    XsltUtils.RunXsltAndWriteHtml("MZHAdapter", "FarmerSearchRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("MZHAdapter", "MZH", result.Data.Response.XmlSerialize());
        //    Assert.IsTrue(true);

        //}

        //public void XmlWrite(string xmlDocument, string outputFilename, string schemaFileName, string schemaNamespace)
        //{
        //    using (StreamWriter outfile = new StreamWriter(outputFilename, false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xmlDocument);
        //    }
        //    //Validate(schemaFileName, outputFilename, schemaNamespace);
        //}

        //public void Validate(string schemaFileName, string xmlFileName, string schemaNamespace)
        //{
        //    XmlSchemaSet schemas = new XmlSchemaSet();
        //    schemas.Add(schemaNamespace, schemaFileName);

        //    XDocument doc = XDocument.Load(xmlFileName);
        //    string msg = "";
        //    doc.Validate(schemas, (o, e) =>
        //    {
        //        msg = msg + e.Message;
        //    });
        //    if (!String.IsNullOrEmpty(msg))
        //    {
        //        throw new ApplicationException("Invalid xml!" + msg);
        //    }

        //}


        //[TestMethod]
        //public void MZHTestMethodNoDataFound()
        //{
        //    MZHAdapter mzhAdapter = new MZHAdapter();
        //    var result =
        //        mzhAdapter.FarmerDetailsSearch(
        //            new TechnoLogica.RegiX.MZHAdapter.FarmerSearchParametersType() { Parameter = "761212456812" },
        //            AccessMatrix.CreateForType(typeof(FarmerType)),
        //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters
        //            {
        //                CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext
        //                {
        //                    Remark = "RegiXTest"
        //                }
        //            }
        //        );

        //    Assert.IsTrue(
        //        result.Data.Response.Animals.Count == 0 &&
        //        result.Data.Response.Crops.Count == 0 &&
        //        result.Data.Response.Lands.Count == 0);
        //}

    }
}


