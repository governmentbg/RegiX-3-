using System;
using System.Collections.Generic;
using System.Text;

namespace RegiX.Processors.PDFResponseProcessor
{
    public interface IEOPdfLicenseKeyResolver
    {
        /// <summary>
        /// EO PDF license key
        /// <summary>
        string LicenseKey { get; }
    }
}
