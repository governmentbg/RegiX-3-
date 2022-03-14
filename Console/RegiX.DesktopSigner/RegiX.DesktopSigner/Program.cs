using RegiX.SecureBlackBox.CertFinder.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.SecureBlackBoxSigner;

namespace RegiX.DesktopSigner
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new TypeCatalog(typeof(UICertificateFinder), typeof(UICertificateFinderX), typeof(Signer), typeof(BlackBoxSettings)));
            CompositionContainer result = new CompositionContainer(catalog, true);
            result.ComposeExportedValue(result);
            Composition.CompositionContainer = result;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
