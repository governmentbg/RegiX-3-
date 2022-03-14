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
using TechnoLogica.RegiX.GraoCivilStatusActsAdapter.AdapterService;
using TechnoLogica.RegiX.GraoCivilStatusActsAdapter.XMLSchemas;

namespace TechnoLogica.RegiX.GraoCivilStatusActsAdapter.Tests
{
    [TestClass]
    public class GraoCivilStatusActsAdapterTest : AdapterTest<AdapterService.GraoCivilStatusActsAdapter, IGraoCivilStatusActsAdapter>
    {

        public GraoCivilStatusActsAdapterTest()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(AdapterService.GraoCivilStatusActsAdapter).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(FileParameterStoreImplementation).Assembly));
            catalog.Catalogs.Add(new TypeCatalog(typeof(BinDirectoryLocator)));
            CompositionContainer result = new CompositionContainer(catalog, true);
            result.ComposeExportedValue(result);
            Composition.CompositionContainer = result;
        }


        [TestMethod]
        public void GetMarriageCertificateTest()
        {
            AdapterService.GraoCivilStatusActsAdapter gr = new AdapterService.GraoCivilStatusActsAdapter();
            var accessMatrix = AccessMatrix.CreateForType(typeof(MarriageCertificateResponseType));
            MarriageCertificateRequestType searchParams = new MarriageCertificateRequestType { Egn = "8506258485", SearchDate = new DateTime(2012, 12, 12) };

            var result = gr.GetMarriageCertificate(searchParams, accessMatrix, new AdapterAdditionalParameters());

            using (StreamWriter outfile = new StreamWriter("GraoCivilStatusActsAdapter.xml", false, System.Text.Encoding.UTF8))
            {
                outfile.Write(result.XmlSerialize());
            }

            //  XsltUtils.RunXsltAndWriteHtml("GraoPNAAdapter", "TemporaryAddressRequest", result.Data.Request.XmlSerialize());
            //   XsltUtils.RunXsltAndWriteHtml("GraoPNAAdapter", "TemporaryAddressResponse", result.Data.Response.XmlSerialize());
            //XmlWrite(res, "MaritalStatus.xml", "XMLSchemas/MaritalStatusResponse.xsd", "http://egov.bg/RegiX/GRAO/BR/MaritalStatusResponse");
            Assert.IsTrue(true);
        }

    }
}
