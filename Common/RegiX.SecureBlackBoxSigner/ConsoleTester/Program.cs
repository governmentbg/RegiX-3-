using RegiX.SecureBlackBox.CertFinder.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.SecureBlackBoxSigner;

namespace ConsoleTester
{
    [Export(typeof(IAddTimestamp))]
    class AddTimeStamp : IAddTimestamp
    {
        public bool AddTimestamp => false;

        public string TimestampServer => "";
    }


    [Export(typeof(ISecureBlackBoxLicenseKeyResolver))]
    class KeyResolver : ISecureBlackBoxLicenseKeyResolver
    {
        public string LicenseKey => "###";
    }

    class Program
    {


        static void Main(string[] args)
        {

            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new TypeCatalog(typeof(UICertificateFinder), typeof(Signer), typeof(AddTimeStamp), typeof(KeyResolver), typeof(UICertificateFinderX)));

            CompositionContainer result = new CompositionContainer(catalog, true);
            result.ComposeExportedValue(result);
            Composition.CompositionContainer = result;


            var signer = Composition.CompositionContainer.GetExportedValue<ISigner>();
            //var serviceresultData = File.ReadAllText("Result.pdf.xml").XmlDeserialize<ServiceResultData>();
            //signer.Sign(serviceresultData);
            //File.WriteAllText("Result.pdf.signed.xml", serviceresultData.XmlSerialize().ToXmlElement().OuterXml);
            //File.WriteAllBytes("Result.pdf", serviceresultData.Data.Response.Response.Deserialize<BinaryArgument>().Binary);


            var serviceresultData = File.ReadAllText("ServiceResultdata.xml").XmlDeserialize<ServiceResultData>();
            signer.Sign(serviceresultData);
            File.WriteAllText("ServiceResultdata.signed.xml", serviceresultData.XmlSerialize().ToXmlElement().OuterXml);
        }
    }
}
