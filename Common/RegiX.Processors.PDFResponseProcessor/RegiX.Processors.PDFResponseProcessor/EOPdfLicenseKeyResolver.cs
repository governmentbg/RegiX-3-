using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Text;

namespace RegiX.Processors.PDFResponseProcessor
{
    [Export(typeof(IEOPdfLicenseKeyResolver))]
    public class EOPdfLicenseKeyResolver : IEOPdfLicenseKeyResolver
    {
        public string LicenseKey => ConfigurationManager.AppSettings["EOPdfLicenseKey"];
    }
}
