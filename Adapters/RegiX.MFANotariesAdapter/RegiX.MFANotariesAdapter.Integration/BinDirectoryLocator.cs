using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Common;
using System.Web;

namespace TechnoLogica.RegiX.MFANotariesAdapter.Integration
{
    [Export(typeof(IBinDirectoryLocator))]
    public class BinDirectoryLocator : IBinDirectoryLocator
    {
        public static string BIN_DIRECTORY;

        public string GetBinDirectory()
        {
            return BIN_DIRECTORY;
        }
    }
}
