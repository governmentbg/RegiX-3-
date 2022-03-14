﻿using System.ComponentModel.Composition;
using System.Web;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.CoreServices
{
    [Export(typeof(IBinDirectoryLocator))]
    public class BinDirectoryLocator : IBinDirectoryLocator
    {
        public string GetBinDirectory()
        {
            return HttpRuntime.BinDirectory;
        }
    }
}