using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegiX.Adapters.Mocks;
using RegiX.GraoNBDAdapter.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.GraoNBDAdapter.AdapterService;

namespace TechnoLogica.RegiX.GraoNBDAdapter.Tests
{
    [TestClass]
    public class NBDMockTest : MockTest<NBDAdapterMock, INBDAdapter>
    {
    }
}
