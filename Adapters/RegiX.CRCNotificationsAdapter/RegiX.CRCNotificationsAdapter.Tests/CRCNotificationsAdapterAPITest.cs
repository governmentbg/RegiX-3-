using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.CRCNotificationsAdapter.APIService;

namespace TechnoLogica.CRCNotificationsAdapter.Tests
{
    [TestClass]
    public class CRCNotificationsAdapterAPITest : APITest<CRCNotificationsAPI, ICRCNotificationsAPI>
    {
    }
}
