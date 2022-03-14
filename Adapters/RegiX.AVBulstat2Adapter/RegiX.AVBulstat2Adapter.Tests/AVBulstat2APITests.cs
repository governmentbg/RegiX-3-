using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.AVBulstat2Adapter.APIService;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.AVBulstat2Adapter.Tests
{
    [TestClass]
    public class AVBulstat2APITests : APITest<AVBulstat2API, IAVBulstat2API>
    {
    }
}
