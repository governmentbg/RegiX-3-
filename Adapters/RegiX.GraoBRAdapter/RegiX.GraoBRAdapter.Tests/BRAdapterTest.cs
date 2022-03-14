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
using TechnoLogica.RegiX.GraoBRAdapter.AdapterService;

namespace TechnoLogica.RegiX.GraoBRAdapter.Tests
{
    [TestClass]
    public class BRAdapterTest : AdapterTest<BRAdapter, IBRAdapter>
    {
    //    public BRAdapterTest()
    //    {
    //        AggregateCatalog catalog = new AggregateCatalog();
    //        catalog.Catalogs.Add(new AssemblyCatalog(typeof(AdapterService.BRAdapter).Assembly));
    //        catalog.Catalogs.Add(new AssemblyCatalog(typeof(FileParameterStoreImplementation).Assembly));
    //        catalog.Catalogs.Add(new TypeCatalog(typeof(BinDirectoryLocator)));
    //        CompositionContainer result = new CompositionContainer(catalog, true);
    //        result.ComposeExportedValue(result);
    //        Composition.CompositionContainer = result;
    //    }

    //    [TestMethod]
    //    public void GraoBRMaritalStatusTest()
    //    {
    //        BRAdapter gr = new BRAdapter();
    //        var accessMatrix = AccessMatrix.CreateForType(typeof(MaritalStatusResponseType));
    //        MaritalStatusRequestType searchParams = new MaritalStatusRequestType { EGN = "8506258485" };
    //        var result = gr.MaritalStatusSearch(searchParams, accessMatrix, new AdapterAdditionalParameters());
    //        using (StreamWriter outfile = new StreamWriter("MaritalStatus.xml", false, System.Text.Encoding.UTF8))
    //        {
    //            outfile.Write(result.XmlSerialize());
    //        }
    //        //XmlWrite(res, "MaritalStatus.xml", "XMLSchemas/MaritalStatusResponse.xsd", "http://egov.bg/RegiX/GRAO/BR/MaritalStatusResponse");

    //        XsltUtils.RunXsltAndWriteHtml("GraoBRAdapter", "MaritalStatusRequest", result.Data.Request.XmlSerialize());
    //        XsltUtils.RunXsltAndWriteHtml("GraoBRAdapter", "MaritalStatusResponse", result.Data.Response.XmlSerialize());
    //        Assert.IsTrue(true);
    //    }

    //    [TestMethod]
    //    public void GraoBRMaritalStatusSpouseChildrenTest()
    //    {
    //        BRAdapter gr = new BRAdapter();
    //        var accessMatrix = AccessMatrix.CreateForType(typeof(MaritalStatusResponseType));
    //        MaritalStatusSpouseChildrenRequestType searchParams = new MaritalStatusSpouseChildrenRequestType { EGN = "8506258485" };
    //        var result = gr.MaritalStatusSpouseChildrenSearch(searchParams, accessMatrix, new AdapterAdditionalParameters());
    //        using (StreamWriter outfile = new StreamWriter("MaritalStatusSpouseChildren.xml", false, System.Text.Encoding.UTF8))
    //        {
    //            outfile.Write(result.XmlSerialize());
    //        }
    //        //XmlWrite(res, "MaritalStatus.xml", "XMLSchemas/MaritalStatusResponse.xsd", "http://egov.bg/RegiX/GRAO/BR/MaritalStatusResponse");

    //        //  XsltUtils.RunXsltAndWriteHtml("GraoBRAdapter", "MaritalStatusRequest", result.Data.Request.XmlSerialize());
    //        //   XsltUtils.RunXsltAndWriteHtml("GraoBRAdapter", "MaritalStatusResponse", result.Data.Response.XmlSerialize());
    //        Assert.IsTrue(true);
    //    }

    //    [TestMethod]
    //    public void GraoBRSpouseTest()
    //    {
    //        BRAdapter gr = new BRAdapter();
    //        var accessMatrix = AccessMatrix.CreateForType(typeof(SpouseResponseType));
    //        SpouseRequestType searchParams = new SpouseRequestType { EGN = "8506258485" };
    //        var result = gr.SpouseSearch(searchParams, accessMatrix, new AdapterAdditionalParameters());
    //        using (StreamWriter outfile = new StreamWriter("Spouse.xml", false, System.Text.Encoding.UTF8))
    //        {
    //            outfile.Write(result.XmlSerialize());
    //        }
    //        //XmlWrite(res, "MaritalStatus.xml", "XMLSchemas/MaritalStatusResponse.xsd", "http://egov.bg/RegiX/GRAO/BR/MaritalStatusResponse");

    //        XsltUtils.RunXsltAndWriteHtml("GraoBRAdapter", "SpouseRequest", result.Data.Request.XmlSerialize());
    //        XsltUtils.RunXsltAndWriteHtml("GraoBRAdapter", "SpouseResponse", result.Data.Response.XmlSerialize());
    //        Assert.IsTrue(true);
    //    }

    //    [TestMethod]
    //    public void GraoBRMarriageTest()
    //    {
    //        BRAdapter gr = new BRAdapter();
    //        var accessMatrix = AccessMatrix.CreateForType(typeof(MarriageResponseType));
    //        MarriageRequestType searchParams = new MarriageRequestType { EGN = "8506258485" };
    //        var result = gr.MarriageSearch(searchParams, accessMatrix, new AdapterAdditionalParameters());
    //        using (StreamWriter outfile = new StreamWriter("Marriage.xml", false, System.Text.Encoding.UTF8))
    //        {
    //            outfile.Write(result.XmlSerialize());
    //        }
    //        //XmlWrite(res, "MaritalStatus.xml", "XMLSchemas/MaritalStatusResponse.xsd", "http://egov.bg/RegiX/GRAO/BR/MaritalStatusResponse");
    //        XsltUtils.RunXsltAndWriteHtml("GraoBRAdapter", "MarriageRequest", result.Data.Request.XmlSerialize());
    //        XsltUtils.RunXsltAndWriteHtml("GraoBRAdapter", "MarriageResponse", result.Data.Response.XmlSerialize());
    //        Assert.IsTrue(true);
    //    }

    //    [TestMethod]
    //    public void GraoBRMarriageNotFoundTest()
    //    {
    //        BRAdapter gr = new BRAdapter();
    //        var accessMatrix = AccessMatrix.CreateForType(typeof(MarriageResponseType));
    //        MarriageRequestType searchParams = new MarriageRequestType { EGN = "XXX" };
    //        var result = gr.MarriageSearch(searchParams, accessMatrix, new AdapterAdditionalParameters());
    //        using (StreamWriter outfile = new StreamWriter("MarriageNotFound.xml", false, System.Text.Encoding.UTF8))
    //        {
    //            outfile.Write(result.XmlSerialize());
    //        }
    //        //XmlWrite(res, "MaritalStatus.xml", "XMLSchemas/MaritalStatusResponse.xsd", "http://egov.bg/RegiX/GRAO/BR/MaritalStatusResponse");
    //        Assert.IsTrue(true);
    //    }

    }
}
