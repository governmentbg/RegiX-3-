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
using TechnoLogica.RegiX.GraoNMAdapter.AdapterService;

namespace TechnoLogica.RegiX.GraoNMAdapter.Tests
{
    [TestClass]
    public class GraoNMAdapterTest : AdapterTest<NMAdapter, INMAdapter>
    {
        //public GraoNMAdapterTest()
        //{
        //    AggregateCatalog catalog = new AggregateCatalog();
        //    catalog.Catalogs.Add(new AssemblyCatalog(typeof(NMAdapter).Assembly));
        //    catalog.Catalogs.Add(new AssemblyCatalog(typeof(FileParameterStoreImplementation).Assembly));
        //    catalog.Catalogs.Add(new TypeCatalog(typeof(BinDirectoryLocator)));
        //    CompositionContainer result = new CompositionContainer(catalog, true);
        //    result.ComposeExportedValue(result);
        //    Composition.CompositionContainer = result;
        //}

        //[TestMethod]
        //public void SettlementPlacesTest()
        //{
        //    NMAdapter le = new NMAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(SettlementPlacesResponseType));
        //    SettlementPlacesRequestType searchParams = new SettlementPlacesRequestType();
        //    searchParams.StartDate = new DateTime(1900, 1, 1);
        //    searchParams.EndDate = new DateTime(4000, 1, 1);

        //    var result = le.SettlementPlacesSearch(searchParams, accessMatrix, new AdapterAdditionalParameters());

        //    using (StreamWriter outfile = new StreamWriter("SettlementPlaces.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }
        //    //XmlWrite(res, "MaritalStatus.xml", "XMLSchemas/MaritalStatusResponse.xsd", "http://egov.bg/RegiX/GRAO/BR/MaritalStatusResponse");

        //    XsltUtils.RunXsltAndWriteHtml("GraoNMAdapter", "SettlementPlacesRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("GraoNMAdapter", "SettlementPlacesResponse", result.Data.Response.XmlSerialize());
        //    Assert.IsTrue(true);
        //}

    }
}
