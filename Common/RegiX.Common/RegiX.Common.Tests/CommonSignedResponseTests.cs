using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.RegiX.Common.DataContracts;

namespace RegiX.Common.Tests
{
    [TestClass]
    public class CommonSignedResponseTests
    {
        [TestMethod]
        public void ToServiceresultDataTest()
        {
            var testVal = new CommonSignedResponse<CommonSignedResponseTests, CommonSignedResponseTests>();
            testVal.IsReady = false;
            testVal.VerificationCode = "somecode";
            var serviceResultData = testVal.ToServiceResultDataSigned();
            Assert.IsNotNull(serviceResultData);

        }

    }
}
