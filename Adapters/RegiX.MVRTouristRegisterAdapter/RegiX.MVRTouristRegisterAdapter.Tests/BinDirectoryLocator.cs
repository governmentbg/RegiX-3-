using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.Adapters.TestUtils
{
    [Export(typeof(IBinDirectoryLocator))]
    public class BinDirectoryLocator : IBinDirectoryLocator
    {
        public string GetBinDirectory()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}
