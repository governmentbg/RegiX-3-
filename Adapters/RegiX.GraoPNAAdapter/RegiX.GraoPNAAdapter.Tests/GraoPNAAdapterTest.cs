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
using TechnoLogica.RegiX.GraoPNAAdapter.AdapterService;

namespace TechnoLogica.RegiX.GraoPNAAdapter.Tests
{
    [TestClass]
    public class GraoPNAAdapterTest : AdapterTest<PNAAdapter, IPNAAdapter>
    {

        //public GraoPNAAdapterTest()
        //{
        //    AggregateCatalog catalog = new AggregateCatalog();
        //    catalog.Catalogs.Add(new AssemblyCatalog(typeof(PNAAdapter).Assembly));
        //    catalog.Catalogs.Add(new AssemblyCatalog(typeof(FileParameterStoreImplementation).Assembly));
        //    catalog.Catalogs.Add(new TypeCatalog(typeof(BinDirectoryLocator)));
        //    CompositionContainer result = new CompositionContainer(catalog, true);
        //    result.ComposeExportedValue(result);
        //    Composition.CompositionContainer = result;
        //}

        //[TestMethod]
        //public void GraoPNAPermanentAddressTest()
        //{
        //    PNAAdapter gr = new PNAAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(PermanentAddressResponseType));
        //    PermanentAddressRequestType searchParams = new PermanentAddressRequestType { EGN = "8506258485", SearchDate = new DateTime(2012, 12, 12) };
        //    var result = gr.PermanentAddressSearch(searchParams, accessMatrix, new AdapterAdditionalParameters());
        //    using (StreamWriter outfile = new StreamWriter("PermanentAddress.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }
        //    //XmlWrite(res, "MaritalStatus.xml", "XMLSchemas/MaritalStatusResponse.xsd", "http://egov.bg/RegiX/GRAO/BR/MaritalStatusResponse");
        //    XsltUtils.RunXsltAndWriteHtml("GraoPNAAdapter", "PermanentAddressRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("GraoPNAAdapter", "PermanentAddressResponse", result.Data.Response.XmlSerialize());
        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void GraoPNATemporaryAddressTest()
        //{
        //    PNAAdapter gr = new PNAAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(TemporaryAddressResponseType));
        //    TemporaryAddressRequestType searchParams = new TemporaryAddressRequestType { EGN = "8506258485", SearchDate = new DateTime(2012, 12, 12) };
        //    var result = gr.TemporaryAddressSearch(searchParams, accessMatrix, new AdapterAdditionalParameters());
        //    using (StreamWriter outfile = new StreamWriter("TemporaryAddress.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    XsltUtils.RunXsltAndWriteHtml("GraoPNAAdapter", "TemporaryAddressRequest", result.Data.Request.XmlSerialize());
        //    XsltUtils.RunXsltAndWriteHtml("GraoPNAAdapter", "TemporaryAddressResponse", result.Data.Response.XmlSerialize());
        //    //XmlWrite(res, "MaritalStatus.xml", "XMLSchemas/MaritalStatusResponse.xsd", "http://egov.bg/RegiX/GRAO/BR/MaritalStatusResponse");
        //    Assert.IsTrue(true);
        //}

    }
}
