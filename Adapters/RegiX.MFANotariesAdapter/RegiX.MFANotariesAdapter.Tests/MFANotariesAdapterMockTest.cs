using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.MFANotariesAdapter.AdapterService;
using TechnoLogica.RegiX.MFANotariesAdapter.Mocks;

namespace TechnoLogica.RegiX.MFANotariesAdapter.Tests
{
    [TestClass]
    public class MFANotariesAdapterMockTest : MockTest<MFANotariesAdapterMock, IMFANotariesAdapter>
    {
    }
}
