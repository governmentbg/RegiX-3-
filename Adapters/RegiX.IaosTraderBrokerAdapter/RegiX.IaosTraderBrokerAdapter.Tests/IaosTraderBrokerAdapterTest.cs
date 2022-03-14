using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.IaosTraderBrokerAdapter.AdapterService;
using TechnoLogica.RegiX.IaosTraderBrokerAdapter;
using System.IO;
using System;

namespace TechnoLogica.RegiX.IaosTraderBrokerAdapter.Tests
{
    [TestClass]
    public class IaosTraderBrokerAdapterTest : AdapterTest<AdapterService.IaosTraderBrokerAdapter, IIaosTraderBrokerAdapter>
    {
    //    [TestMethod]
    //    public void GetTRADER_BROKER_Waste_Codes_By_EIKV2Test()
    //    {
    //        AdapterService.IaosTraderBrokerAdapter adapter = new AdapterService.IaosTraderBrokerAdapter();
    //        var accessMatrix = AccessMatrix.CreateForType(typeof(TRADER_BROKER_Waste_Codes_By_EIK_ResponseV2));
    //        TRADER_BROKER_Waste_Codes_By_EIK_RequestV2 searchCriteria = new TRADER_BROKER_Waste_Codes_By_EIK_RequestV2()
    //        {
    //           EIK = "1234567890"

    //        };
    //        AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters()
    //        {
    //            //CallContext = CallContext()
    //            //{
    //            //    AdministrationOId = "2.16.0.55.12.14"
    //            //}
    //        };
    //        try
    //        {
    //            var result = adapter.GetTRADER_BROKER_Waste_Codes_By_EIKV2(searchCriteria, accessMatrix, additionalParameters);
    //            string xml = result.XmlSerialize();
    //            using (StreamWriter outfile = new StreamWriter("IaosTraderBrokerAdapter_GetTRADER_BROKER_Waste_Codes_By_EIKV2.xml", false, System.Text.Encoding.UTF8))
    //            {
    //                outfile.Write(xml);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            if (ex.InnerException != null && ex.InnerException.Message.StartsWith("StatusCode:"))
    //            {
    //                Assert.IsTrue(true);
    //            }
    //            else
    //            {
    //                throw ex;
    //            }
    //        }
    //    }
    }
}
