using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.ZADSAdapter.AdapterService;

namespace TechnoLogica.RegiX.ZADSAdapter.Tests
{
    [TestClass]
    public class ZADSAdapterTest : AdapterTest<AdapterService.ZADSAdapter, IZADSAdapter>
    {
        //[TestMethod]
        public void ZADSAdapterTest1()
        {
            AdapterService.ZADSAdapter zads = new AdapterService.ZADSAdapter();
            //zads.SetParameter(TechnoLogica.RegiX.Common.Constants.ConnectionStringParameterKeyName, "Database=zads;Host=172.16.38.173;Server=;Service=25852;Protocol=onsoctcp;UID=informix;Password=;DB_LOCALE=en_US.57372");
            var accessMatrix = AccessMatrix.CreateForType(typeof(RegistrationInfoResponseType));
            RegistrationInfoRequestType searchCriteria = new RegistrationInfoRequestType() { EIK = "123456789", StatusDate = new DateTime(2013, 01, 11) };
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
            var result = zads.GetRegistrationInfo(searchCriteria, accessMatrix, additionalParameters);
            Assert.IsTrue(true);
        }
        //[TestMethod]
        //public void ZADSAdapterTest2()
        //{
        //    ZADSAdapter zads = new ZADSAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(RegistrationInfoResponseType));
        //    RegistrationInfoRequestType searchCriteria = new RegistrationInfoRequestType() { EIK = "987654321", StatusDate = new DateTime(2013, 01, 11) };
        //    var result = zads.GetRegistrationInfo(searchCriteria, accessMatrix,
        //        new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters
        //        {
        //            CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext
        //            {
        //                Remark = "RegiX Test"
        //            }
        //        });
        //    using (StreamWriter outfile = new StreamWriter("ZADSRegistrationInfo1.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("ZADSAdapter", "RegistrationInfoRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("ZADSAdapter", "RegistrationInfoResponse", result.Data.Response.XmlSerialize());
        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void ZADSAdapterTest_CheckHealthCheckAndParamtersTest()
        //{
        //    ZADSAdapter adapter = new ZADSAdapter();
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
        //public void ZADSAdapterTest_CheckRegisterConnection()
        //{
        //    ZADSAdapter adapter = new ZADSAdapter();
        //    string result = adapter.CheckRegisterConnection();
        //    Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
        //}
    }
}


