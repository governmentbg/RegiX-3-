using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegiX.Adapters.FileParameterStore;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.GraoLEAdapter.AdapterService;

namespace TechnoLogica.RegiX.GraoLEAdapter.Tests
{
    [TestClass]
    public class GraoLEAdapterTest : AdapterTest<LEAdapter, ILEAdapter>
    {
        //public GraoLEAdapterTest()
        //{
        //    AggregateCatalog catalog = new AggregateCatalog();
        //    catalog.Catalogs.Add(new AssemblyCatalog(typeof(AdapterService.LEAdapter).Assembly));
        //    catalog.Catalogs.Add(new AssemblyCatalog(typeof(FileParameterStoreImplementation).Assembly));
        //    catalog.Catalogs.Add(new TypeCatalog(typeof(BinDirectoryLocator)));
        //    CompositionContainer result = new CompositionContainer(catalog, true);
        //    result.ComposeExportedValue(result);
        //    Composition.CompositionContainer = result;
        //}

        //[TestMethod]
        //public void LocationsTest()
        //{
        //    LEAdapter le = new LEAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(LocationsResponseType));
        //    LocationsRequestType searchParams = new LocationsRequestType();
        //    searchParams.StartDate = new DateTime(1900, 1, 1);
        //    // searchParams.StartDateSpecified = true;
        //    //  searchParams.EndDateSpecified = true;
        //    searchParams.EndDate = new DateTime(4000, 1, 1);

        //    var result = le.LocationsSearch(searchParams, accessMatrix, new AdapterAdditionalParameters());

        //    using (StreamWriter outfile = new StreamWriter("Locations.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }
        //    //XmlWrite(res, "MaritalStatus.xml", "XMLSchemas/MaritalStatusResponse.xsd", "http://egov.bg/RegiX/GRAO/BR/MaritalStatusResponse");

        //    XsltUtils.RunXsltAndWriteHtml("GraoLEAdapter", "LocationsRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("GraoLEAdapter", "LocationsResponse", result.Data.Response.XmlSerialize());
        //    Assert.IsTrue(true);
        //}
    }
}
