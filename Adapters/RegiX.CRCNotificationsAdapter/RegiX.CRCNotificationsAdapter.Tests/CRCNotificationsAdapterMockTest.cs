using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.CRCNotificationsAdapter.AdapterService;
using TechnoLogica.RegiX.CRCNotificationsAdapter.Mocks;

namespace TechnoLogica.CRCNotificationsAdapter.Tests
{
    [TestClass]
    public class CRCNotificationsAdapterMockTest : MockTest<CRCNotificationsAdapterMock, ICRCNotificationsAdapter>
    {
    }
}
