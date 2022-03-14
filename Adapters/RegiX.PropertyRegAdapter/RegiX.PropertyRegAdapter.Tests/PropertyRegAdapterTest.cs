using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.PropertyRegAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.TestUtils;

namespace TechnoLogica.RegiX.PropertyRegAdapter.Tests
{
    /// <summary>
    /// При промяна на конфигурацията в web config-a на адаптера -> трябва да се промени и в app.config-a на теста!!!!!
    /// </summary>
    [TestClass]
    public class PropertyRegAdapterTest : AdapterTest<AdapterService.PropertyRegAdapter, IPropertyRegAdapter>
    {
        ////[TestMethod]
        ////public void PropertyRegAdapterTest_CheckHealthCheckAndParamtersTest()
        ////{
        ////    PropertyRegAdapter adapter = new PropertyRegAdapter();
        ////    //test GetParameters , and ConnectionString
        ////    var connectionString = adapter.GetParameters().ParameterList.Where(p => p.Key == TechnoLogica.RegiX.Common.Constants.ConnectionStringParameterKeyName).FirstOrDefault();
        ////    //test SetParameter
        ////    adapter.SetParameter(TechnoLogica.RegiX.Common.Constants.ConnectionStringParameterKeyName,connectionString.CurrentValue);
        ////    //test HCfunctions
        ////    var hcFunctions = adapter.GetHealthCheckFunctions();
        ////    string checkHealthFunctionResult = string.Empty;
        ////    hcFunctions.HealthInfosList.ForEach(f => {
        ////        checkHealthFunctionResult = checkHealthFunctionResult + f.Key + ":" + adapter.CheckHealthFunction(f.Key) + ";\r\n";
        ////    });
        ////    using (StreamWriter outfile = new StreamWriter("CheckHealthFunctions.xml", false, System.Text.Encoding.UTF8))
        ////    {
        ////        outfile.Write(checkHealthFunctionResult);
        ////    }
        ////    Assert.IsTrue(true); 
        ////}

        ////[TestMethod]
        ////public void PropertyRegAdapterTest_CheckRegisterConnection()
        ////{
        ////    PropertyRegAdapter adapter = new PropertyRegAdapter();
        ////    string result = adapter.CheckRegisterConnection();
        ////    Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
        ////}

        //[TestMethod]
        //public void PropertyRegAdapter_GetEntityInfo()
        //{
        //    PropertyRegAdapter adapter = new PropertyRegAdapter();

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(EntityInfoResponseType));
        //    EntityInfoRequestType operation = new EntityInfoRequestType();
        //    operation.EIK = "123456789";
        //    operation.DateFrom = new DateTime(2000, 1, 1);
        //    operation.DateTo = new DateTime(2013, 1, 1);
        //    operation.SiteID = "006";
        //    var adapterAdditionalParameters = CreateAdapterAdditionalParameters(true); // For testing purpose, can be changed to false

        //    var result = adapter.GetEntityInfo(operation, accessMatrix, adapterAdditionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetEntityInfo.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("PropertyRegAdapter", "EntityInfoRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("PropertyRegAdapter", "EntityInfoResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsNotNull(result);
        //}

        //[TestMethod]
        //public void PropertyRegAdapter_GetEntityInfoNull()
        //{
        //    PropertyRegAdapter adapter = new PropertyRegAdapter();

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(EntityInfoResponseType));
        //    EntityInfoRequestType operation = new EntityInfoRequestType();
        //    operation.EIK = "123456789000";
        //    operation.DateFrom = new DateTime(2000, 1, 1);
        //    operation.DateTo = new DateTime(2013, 1, 1);
        //    operation.SiteID = "006";
        //    var adapterAdditionalParameters = CreateAdapterAdditionalParameters(true); // For testing purpose, can be changed to false

        //    var result = adapter.GetEntityInfo(operation, accessMatrix, adapterAdditionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetEntityInfo.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("PropertyRegAdapter", "EntityInfoRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("PropertyRegAdapter", "EntityInfoResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsNotNull(result);
        //}

        //[TestMethod]
        //public void PropertyRegAdapter_GetPersonInfo()
        //{
        //    PropertyRegAdapter adapter = new PropertyRegAdapter();

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(PersonInfoResponseType));
        //    PersonInfoRequestType operation = new PersonInfoRequestType();
        //    operation.EGN = "123456789";
        //    operation.DateFrom = new DateTime(2000, 1, 1);
        //    operation.DateTo = new DateTime(2013, 1, 1);
        //    //operation.SiteID = "006";
        //    var adapterAdditionalParameters = CreateAdapterAdditionalParameters(true); // For testing purpose, can be changed to false

        //    var result = adapter.GetPersonInfo(operation, accessMatrix, adapterAdditionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetPersonInfo.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("PropertyRegAdapter", "PersonInfoRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("PropertyRegAdapter", "PersonInfoResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsNotNull(result);
        //}

        //[TestMethod]
        //public void PropertyRegAdapter_GetPersonInfoNull()
        //{
        //    PropertyRegAdapter adapter = new PropertyRegAdapter();

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(PersonInfoRequestType));
        //    PersonInfoRequestType operation = new PersonInfoRequestType();
        //    operation.EGN = "123456789000";
        //    operation.DateFrom = new DateTime(2000, 1, 1);
        //    operation.DateTo = new DateTime(2013, 1, 1);
        //    operation.SiteID = "006";
        //    var adapterAdditionalParameters = CreateAdapterAdditionalParameters(true); // For testing purpose, can be changed to false

        //    var result = adapter.GetPersonInfo(operation, accessMatrix, adapterAdditionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetEntityInfo.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("PropertyRegAdapter", "PersonInfoRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("PropertyRegAdapter", "PersonInfoResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsNotNull(result);
        //}

        //[TestMethod]
        //public void PropertyRegAdapter_GetPropertyInfo()
        //{
        //    PropertyRegAdapter adapter = new PropertyRegAdapter();

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(PropertyInfoResponseType));
        //    PropertyInfoRequestType operation = new PropertyInfoRequestType();
        //    //operation.PropertyLot = "247406";
        //    operation.PropertyID = "09002200100000433958";
        //    operation.DateFrom = new DateTime(2000, 1, 1);
        //    operation.DateTo = new DateTime(2013, 1, 1);
        //    operation.SiteID = "006";
        //    var adapterAdditionalParameters = CreateAdapterAdditionalParameters(true); // For testing purpose, can be changed to false

        //    var result = adapter.GetPropertyInfo(operation, accessMatrix, adapterAdditionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetPropertyInfo.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("PropertyRegAdapter", "PropertyInfoRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("PropertyRegAdapter", "PropertyInfoResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsNotNull(result);
        //}

        //[TestMethod]
        //public void PropertyRegAdapter_GetPropertyInfoNULL()
        //{
        //    PropertyRegAdapter adapter = new PropertyRegAdapter();

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(PropertyInfoResponseType));
        //    PropertyInfoRequestType operation = new PropertyInfoRequestType();
        //    //operation.PropertyLot = "247406";
        //    operation.PropertyID = "09002200100000433958000";
        //    operation.DateFrom = new DateTime(2000, 1, 1);
        //    operation.DateTo = new DateTime(2013, 1, 1);
        //    operation.SiteID = "006";
        //    var adapterAdditionalParameters = CreateAdapterAdditionalParameters(true); // For testing purpose, can be changed to false

        //    var result = adapter.GetPropertyInfo(operation, accessMatrix, adapterAdditionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetPropertyInfo.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("PropertyRegAdapter", "PropertyInfoRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("PropertyRegAdapter", "PropertyInfoResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsNotNull(result);
        //}

        //[TestMethod]
        //public void PropertyRegAdapter_PropertySearch()
        //{
        //    PropertyRegAdapter adapter = new PropertyRegAdapter();

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(PropertySearchResponseType));
        //    PropertySearchRequestType operation = new PropertySearchRequestType();
        //    operation.SiteID = "001";
        //    var adapterAdditionalParameters = CreateAdapterAdditionalParameters(true); // For testing purpose, can be changed to false

        //    var result = adapter.PropertySearch(operation, accessMatrix, adapterAdditionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("PropertySearch.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("PropertyRegAdapter", "PropertySearchRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("PropertyRegAdapter", "PropertySearchResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsNotNull(result);
        //}
        
        //[TestMethod]
        //public void PropertyRegAdapter_PropertySearchNULL()
        //{
        //    PropertyRegAdapter adapter = new PropertyRegAdapter();

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(PropertySearchResponseType));
        //    PropertySearchRequestType operation = new PropertySearchRequestType();
        //    operation.SiteID = "000";
        //    var adapterAdditionalParameters = CreateAdapterAdditionalParameters(true); // For testing purpose, can be changed to false

        //    var result = adapter.PropertySearch(operation, accessMatrix, adapterAdditionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("PropertySearch.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("PropertyRegAdapter", "PropertySearchRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("PropertyRegAdapter", "PropertySearchResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsNotNull(result);
        //}

        //[TestMethod]
        //public void PropertyRegAdapter_GetSites()
        //{
        //    PropertyRegAdapter adapter = new PropertyRegAdapter();

        //    var accessMatrix = AccessMatrix.CreateForType(typeof(GetSitesResponseType));
        //    GetSitesRequestType operation = new GetSitesRequestType();
        //    var adapterAdditionalParameters = CreateAdapterAdditionalParameters(true); // For testing purpose, can be changed to false

        //    var result = adapter.GetSites(operation, accessMatrix, adapterAdditionalParameters);
        //    using (StreamWriter outfile = new StreamWriter("GetSites.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("PropertyRegAdapter", "GetSitesResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsNotNull(result);
        //}
        
        //private TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters CreateAdapterAdditionalParameters(bool fullCallContext = false)
        //{
        //    var result = new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //    {
        //        CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext()
        //        {
        //            Remark = "RegiXTest",
        //        },
        //        ClientIPAddress = "172.12.33.56",
        //        OrganizationUnit = "ТехноЛогика", // Logged in db
        //        ApiServiceCallId = Guid.NewGuid().GetHashCode(), // Logged in db
        //    };

        //    if (fullCallContext)
        //    {
        //        // Logged in db:
        //        result.CallContext.AdministrationName = "Общ. Троян";
        //        result.CallContext.EmployeeIdentifier = "defaultuser@domain.com";
        //        result.CallContext.EmployeeNames = "Веси Кр";
        //        result.CallContext.EmployeePosition = "Developer";
        //        result.CallContext.ResponsiblePersonIdentifier = "Responsible Person Identifier";
        //    }

        //    return result;
        //} 
    }
}


