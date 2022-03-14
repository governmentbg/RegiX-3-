using System;
using System.IO;
using System.Linq;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.ChNTsAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;

namespace TechnoLogica.RegiX.ChNTsAdapter.Tests
{
    [TestClass]
    public class ChNTsAdapterTest : AdapterTest<AdapterService.ChNTsAdapter, IChNTsAdapter>
    {
        //[TestMethod]
        //public void ChNTsAdapterTest_CheckHealthCheckAndParamtersTest()
        //{
        //    AdapterService.ChNTsAdapter adapter = new AdapterService.ChNTsAdapter();
        //    //test GetParameters, and ConnectionString
        //   var connectionString = adapter.GetParameters().ParameterList.Where(p => p.Key == Common.Constants.ConnectionStringParameterKeyName).FirstOrDefault();
        //    //test SetParameter
        //    adapter.SetParameter(TechnoLogica.RegiX.Common.Constants.ConnectionStringParameterKeyName, connectionString.CurrentValue);
        //    //test HCfunctions
        //    var hcFunctions = adapter.GetHealthCheckFunctions();
        //    hcFunctions.HealthInfosList.ForEach(f => adapter.CheckHealthFunction(f.Key));
        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void ChNTsAdapterTest_CheckRegisterConnection()
        //{
        //    AdapterService.ChNTsAdapter adapter = new AdapterService.ChNTsAdapter();
        //    string result = adapter.CheckRegisterConnection();
        //    Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
        //}

        //[TestMethod]
        //public void ChNTsAdapter_GetForeignerPermissions()
        //{
        //    CallContext context = new CallContext()
        //    {
        //        AdministrationOId = "https://trust-party-openid.com",
        //        LawReason = "Тестване на RegiX",
        //        ServiceURI = "1222-200030-12.12.2022",
        //        Remark = "Забележки",
        //        EmployeeAditionalIdentifier = "Карта номер 3",
        //        EmployeeIdentifier = "test@tesactivedirectory.com",
        //        EmployeeNames = "Тестов Потребител Потребител",
        //        AdministrationName = "Българска агенция за Тестване",
        //        EmployeePosition = "Старши експерт Отдел \"Тестване на интеграцията\"",
        //        ResponsiblePersonIdentifier = "392309324",
        //        ServiceType = "За проверовъчна дейност"
        //    };
        //    string oldcontext = context.ToString();

        //    AdapterService.ChNTsAdapter adapter = new AdapterService.ChNTsAdapter();

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(ForeignerPermissionsResponseType));
        //    ForeignerPermissionsRequestType operation = new ForeignerPermissionsRequestType();
        //    operation.SearchDate = new DateTime(2005, 10, 21);
        //    //operation.BirthDateSpecified = false;
        //    operation.NamesLatin = "OK";
        //    operation.BirthDate = new DateTime(1980, 07, 18);
        //    operation.BirthDateSpecified = true;


        //    AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
        //    additionalParameters.CallContext = new CallContext();

        //    // "\"LawReason\":\"Тестване на RegiX\",\"ServiceURI\":\"123456789\",\”ServiceType\”:\”За проверовъчна дейност\”\"Remark\":\"\",\"RequestorNames\":\"Ivelin Ivanov\",\"UserAdministrationName\":\"Министерство на земеделието и храните\",\” UserAdministrationID\”:\”10.20.503.4\”,\" RequestorIdentifier\":\"IIvanov@technologica.com\",\"RequestorIdentifierOptional\":\"123456\",\"UserPosition\":\"Developer\",\"EAuthToken\":\"https://trust-party-openid.com\"";

        //    additionalParameters.CitizenEGN = "8888888888";
        //    additionalParameters.ClientIPAddress = "111.111.111.111";
        //    additionalParameters.ConsumerCertificateThumbprint = "###";
        //    additionalParameters.EIDToken = "token123";
        //    additionalParameters.EmployeeEGN = "11111111111111";
        //    additionalParameters.OrganizationEIK = "12121212121";
        //    additionalParameters.OrganizationUnit = "qqqqqq";
        //    additionalParameters.SignResult = false;
        //    additionalParameters.ReturnAccessMatrix = true;

        //    var result = adapter.GetForeignerPermissions(operation, accessMatrix, additionalParameters);
        //    string xml = result.XmlSerialize();
        //    using (StreamWriter outfile = new StreamWriter("GetForeignerPermissions.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(xml);
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("ChNTsAdapter", "ForeignerPermissionsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("ChNTsAdapter", "ForeignerPermissionsResponse", result.Data.Response.XmlSerialize());

        //    XmlDocument doc = new XmlDocument();
        //    doc.LoadXml(xml);
        //    if (SigningUtils.HasSignature(doc))
        //    {
        //        bool isValid = SigningUtils.ValidateXmlDocumentWithX509Certificate(doc);
        //        if (isValid)
        //        {
        //            Assert.IsTrue(true);
        //        }
        //    }
        //    else
        //    {
        //        Assert.IsTrue(true);
        //    }
        //}
    }
}
