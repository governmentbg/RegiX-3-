using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.Adapters.Mocks.Tests
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
