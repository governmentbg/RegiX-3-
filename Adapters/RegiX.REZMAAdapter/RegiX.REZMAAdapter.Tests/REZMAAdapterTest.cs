using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.REZMAAdapter.AdapterService;

namespace TechnoLogica.RegiX.REZMAAdapter.Tests
{
    [TestClass]
    public class REZMAAdapterTest : AdapterTest<AdapterService.REZMAAdapter, IREZMAAdapter>
    {
       // [TestMethod]
        public void GetCustomsObligationsTest()
        {
            AdapterService.REZMAAdapter rezmaAdapter = new AdapterService.REZMAAdapter();

            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters()
            {
                OrganizationUnit = "TL",
                EIDToken = "",
                CallContext = new CallContext() { LawReason = "RegiX.Test", EmployeeIdentifier = "tl_mmarinov", AdministrationName = "TL_Miro" },
                SignResult = false,
                ReturnAccessMatrix = true,
                ApiServiceCallId = 191417,
                CallbackURL = "192.168.1.1"
            };
            CustomsObligationsRequestType request = new CustomsObligationsRequestType
            {
                Identifier = "204505202"
            };
            var result = rezmaAdapter.GetCustomsObligations(request, AccessMatrix.CreateForType(typeof(CustomsObligationsResponseType)), additionalParameters);


            Assert.IsTrue(result.Data.Response.Name == "String");
        }
       // [TestMethod]
        public void GetExciseObligationsTest()
        {
            AdapterService.REZMAAdapter rezmaAdapter = new AdapterService.REZMAAdapter();

            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters()
            {
                OrganizationUnit = "TL",
                EIDToken = "",
                CallContext = new CallContext() { LawReason = "RegiX.Test", EmployeeIdentifier = "tl_mmarinov", AdministrationName = "TL_Miro" },
                SignResult = false,
                ReturnAccessMatrix = true,
                ApiServiceCallId = 191417,
                CallbackURL = "192.168.1.1"
            };
            ExciseObligationsRequestType request = new ExciseObligationsRequestType
            {
                Identifier = "204505202"
            };
            var result = rezmaAdapter.GetExciseObligations(request, AccessMatrix.CreateForType(typeof(ExciseObligationsResponseType)), additionalParameters);


            Assert.IsTrue(result.Data.Response.Name == "String");
        }
       // [TestMethod]
        public void CheckObligationsTest()
        {
            AdapterService.REZMAAdapter rezmaAdapter = new AdapterService.REZMAAdapter();

            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters()
            {
                OrganizationUnit = "TL",
                EIDToken = "",
                CallContext = new CallContext() { LawReason = "RegiX.Test", EmployeeIdentifier = "tl_mmarinov", AdministrationName = "TL_Miro" },
                SignResult = false,
                ReturnAccessMatrix = true,
                ApiServiceCallId = 191417,
                CallbackURL = "192.168.1.1"
            };
            CheckObligationsRequestType request = new CheckObligationsRequestType
            {
                Identifier = "204505202"
            };
            var result = rezmaAdapter.CheckObligations(request, AccessMatrix.CreateForType(typeof(CheckObligationsResponseType)), additionalParameters);


            Assert.IsTrue(result.Data.Response.Name == "String");
        }
        //[TestMethod]
        //public void REZMACustomsTest()
        //{
        //    REZMAAdapter remza = new REZMAAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(CustomsObligationsResponseType));
        //    CustomsObligationsRequestType searchCriteria = new CustomsObligationsRequestType() { Identifier = "123456789" };
        //    var result = remza.GetCustomsObligations(searchCriteria, accessMatrix,
        //        new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters
        //        {
        //            CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext
        //            {
        //                Remark = "RegiX Test"
        //            }
        //        });
        //    using (StreamWriter outfile = new StreamWriter("CustomsObligations.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("REZMAAdapter", "CustomsObligationsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("REZMAAdapter", "CustomsObligations", result.Data.Response.XmlSerialize());

        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void REZMAExciseTest()
        //{
        //    REZMAAdapter remza = new REZMAAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(ExciseObligationsResponseType));
        //    ExciseObligationsRequestType searchCriteria = new ExciseObligationsRequestType() { Identifier = "123456789" };
        //    var result = remza.GetExciseObligations(searchCriteria, accessMatrix,
        //        new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters
        //        {
        //            CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext
        //            {
        //                Remark = "RegiX Test"
        //            }
        //        });
        //    using (StreamWriter outfile = new StreamWriter("ExciseObligations.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }
        //    XsltUtils.RunXsltAndWriteHtml("REZMAAdapter", "ExciseObligationsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("REZMAAdapter", "ExciseObligations", result.Data.Response.XmlSerialize());
        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void REZMACheckObligationsTest()
        //{
        //    REZMAAdapter remza = new REZMAAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(CheckObligationsResponseType));
        //    CheckObligationsRequestType searchCriteria = new CheckObligationsRequestType() { Identifier = "123456789" };
        //    var result = remza.CheckObligations(searchCriteria, accessMatrix,
        //        new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters
        //        {
        //            CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext
        //            {
        //                Remark = "RegiX Test"
        //            }
        //        });
        //    using (StreamWriter outfile = new StreamWriter("CheckObligations.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }
        //   // XsltUtils.RunXsltAndWriteHtml("REZMAAdapter", "CheckObligationsRequest", result.Data.Request.XmlSerialize());
        //   // XsltUtils.RunXsltAndWriteHtml("REZMAAdapter", "CheckObligationsResponse", result.Data.Response.XmlSerialize());
        //    Assert.IsTrue(true);
        //}

        ////[TestMethod]
        ////public void REZMAAdapterTest_CheckHealthCheckAndParamtersTest()
        ////{
        ////    REZMAAdapter adapter = new REZMAAdapter();
        ////    //test GetParameters , and ConnectionString
        ////    var connectionString = adapter.GetParameters().ParameterList.Where(p => p.Key == TechnoLogica.RegiX.Common.Constants.ConnectionStringParameterKeyName).FirstOrDefault();
        ////    //test SetParameter
        ////    adapter.SetParameter(TechnoLogica.RegiX.Common.Constants.ConnectionStringParameterKeyName, connectionString.CurrentValue);
        ////    //test HCfunctions
        ////    var hcFunctions = adapter.GetHealthCheckFunctions();
        ////    hcFunctions.HealthInfosList.ForEach(f => adapter.CheckHealthFunction(f.Key));
        ////    Assert.IsTrue(true);
        ////}

        ////[TestMethod]
        ////public void REZMAAdapterTest_CheckRegisterConnection()
        ////{
        ////    REZMAAdapter adapter = new REZMAAdapter();
        ////    string result = adapter.CheckRegisterConnection();
        ////    Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
        ////}

    }
}


