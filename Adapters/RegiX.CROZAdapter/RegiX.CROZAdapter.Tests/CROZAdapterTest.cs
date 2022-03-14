using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.CROZAdapter.AdapterService;

namespace TechnoLogica.RegiX.CROZAdapter.Tests
{
    //[TestClass]
    //public class CROZAdapterTest : AdapterTest<AdapterService.CROZAdapter, ICROZAdapter>
    //{
    //    [TestMethod]
    //    public void CROZAdapterTest_CheckHealthCheckAndParamtersTest()
    //    {
    //        AdapterService.CROZAdapter adapter = new AdapterService.CROZAdapter();
    //        //test GetParameters , and ConnectionString
    //        var connectionString = adapter.GetParameters().ParameterList.Where(p => p.Key == Common.Constants.WebServiceUrlParameterKeyName).FirstOrDefault();
    //        //test SetParameter
    //        adapter.SetParameter(Common.Constants.WebServiceUrlParameterKeyName, connectionString.CurrentValue);
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
    //    public void CROZAdapterTest_CheckRegisterConnection()
    //    {
    //        AdapterService.CROZAdapter adapter = new AdapterService.CROZAdapter();
    //        string result = adapter.CheckRegisterConnection();
    //        Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
    //    }


    //    [TestMethod]
    //    public void ParticipantsSearchTest()
    //    {
    //        AdapterService.CROZAdapter croaAdapter = new AdapterService.CROZAdapter();
    //        croaAdapter.SetParameter(Common.Constants.WebServiceUrlParameterKeyName, "http://localhost:8078/RegiX.CROZAdapterMockup/CROZServiceImplServiceInterfaces.svc");

    //        var accessMatrix = AccessMatrix.CreateForType(typeof(ParticipantsDataType));

    //        //accessMatrix.AMEntry.AccessMatrix["participantsList"].AccessMatrix["full_name"].HasAccess = false;

    //        ParticipantsSearchType searchParam = new ParticipantsSearchType();
    //        //searchParam.ParticipantCode = "~3111032440";
    //        searchParam.ParticipantName = "ДЪРЖАВНА СПЕСТОВНА";

    //        AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
    //        additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };
            
    //        // "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";

    //        additionalParameters.CitizenEGN = "8888888888";
    //        additionalParameters.ClientIPAddress = "111.111.111.111";
    //        additionalParameters.ConsumerCertificateThumbprint = "###";
    //        additionalParameters.EIDToken = "token123";
    //        additionalParameters.EmployeeEGN = "11111111111111";
    //        additionalParameters.OrganizationEIK = "12121212121";
    //        additionalParameters.OrganizationUnit = "qqqqqq";

    //        var result = croaAdapter.ParticipantsSearch(searchParam, accessMatrix, additionalParameters);

    //        using (StreamWriter outfile = new StreamWriter("ParticipantsSearch.xml", false, System.Text.Encoding.UTF8))
    //        {
    //            outfile.Write(result.XmlSerialize());
    //        }

    //        XsltUtils.RunXsltAndWriteHtml("CROZAdapter", "ParticipantsRequest", result.Data.Request.XmlSerialize());
    //        XsltUtils.RunXsltAndWriteHtml("CROZAdapter", "ParticipantsResponse", result.Data.Response.XmlSerialize());

    //        Assert.IsNotNull(result);
    //    }

    //    [TestMethod]
    //    public void GetConsignmentInfoTest()
    //    {
    //        AdapterService.CROZAdapter croaAdapter = new AdapterService.CROZAdapter();

    //        var accessMatrix = AccessMatrix.CreateForType(typeof(ConsignmentDataType));

    //        //accessMatrix.AMEntry.AccessMatrix["consignment"].AccessMatrix["consignEntries"].

    //        ConsignmentInfoSearchType searchParam = new ConsignmentInfoSearchType();
    //        //searchParam.ParticipantID = 71;
    //        searchParam.ParticipantID = 284;
    //        searchParam.DateFrom = new DateTime(2000, 1, 1);
    //        searchParam.DateTo = new DateTime(2019, 1, 1);

    //        AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
    //        additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };
            
    //        // "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";

    //        additionalParameters.CitizenEGN = "8888888888";
    //        additionalParameters.ClientIPAddress = "111.111.111.111";
    //        additionalParameters.ConsumerCertificateThumbprint = "###";
    //        additionalParameters.EIDToken = "token123";
    //        additionalParameters.EmployeeEGN = "11111111111111";
    //        additionalParameters.OrganizationEIK = "12121212121";
    //        additionalParameters.OrganizationUnit = "qqqqqq";

    //        var result = croaAdapter.GetConsignmentInfo(searchParam, accessMatrix, additionalParameters);

    //        using (StreamWriter outfile = new StreamWriter("GetConsignmentInfo.xml", false, System.Text.Encoding.UTF8))
    //        {
    //            outfile.Write(result.XmlSerialize());
    //        }

    //        XsltUtils.RunXsltAndWriteHtml("CROZAdapter", "ConsignmentsRequest", result.Data.Request.XmlSerialize());
    //        XsltUtils.RunXsltAndWriteHtml("CROZAdapter", "ConsignmentsResponse", result.Data.Response.XmlSerialize());

    //        Assert.IsNotNull(result);
    //    }

    //    [TestMethod]
    //    public void GetDealInfoTest()
    //    {
    //        AdapterService.CROZAdapter croaAdapter = new AdapterService.CROZAdapter();
    //        var accessMatrix = AccessMatrix.CreateForType(typeof(DealInfoDataType));

    //        //accessMatrix.AMEntry.AccessMatrix["deal"].AccessMatrix["amendments"].AccessMatrix["entry"].AccessMatrix["distrainSecuredClaims"].HasAccess = false;

    //        DealInfoSearchType searchParam = new DealInfoSearchType();
    //        searchParam.RegEntryID = "2009010500014";
    //        //searchParam.RegEntryID = "2009010500053";

    //        AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
    //        additionalParameters.CallContext = new CallContext() { Remark = "RegiXTest" };

    //        // "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";

    //        additionalParameters.CitizenEGN = "8888888888";
    //        additionalParameters.ClientIPAddress = "111.111.111.111";
    //        additionalParameters.ConsumerCertificateThumbprint = "###";
    //        additionalParameters.EIDToken = "token123";
    //        additionalParameters.EmployeeEGN = "11111111111111";
    //        additionalParameters.OrganizationEIK = "12121212121";
    //        additionalParameters.OrganizationUnit = "qqqqqq";

    //        var result = croaAdapter.GetDealInfo(searchParam, accessMatrix, additionalParameters);
    //        using (StreamWriter outfile = new StreamWriter("GetDealInfo.xml", false, System.Text.Encoding.UTF8))
    //        {
    //            outfile.Write(result.XmlSerialize());
    //        }

    //        XsltUtils.RunXsltAndWriteHtml("CROZAdapter", "DealInfoRequest", result.Data.Request.XmlSerialize());
    //        XsltUtils.RunXsltAndWriteHtml("CROZAdapter", "DealInfoResponse", result.Data.Response.XmlSerialize());

    //        Assert.IsNotNull(result);

    //    }

    //}
}
