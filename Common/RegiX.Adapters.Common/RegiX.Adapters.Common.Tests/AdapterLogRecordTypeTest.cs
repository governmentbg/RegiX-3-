using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.DummyAdapter;

namespace RegiX.Adapters.Common.Tests
{
    [TestClass]
    public class AdapterLogRecordTypeTest
    {
        [TestMethod]
        public void TestLogRecordXMLSerialize()
        {
            var logRecord = new AdapterLogRecordType();
            logRecord.ApiServiceCallId = 3;
            logRecord.ApiServiceCallIdSpecified = true;
            logRecord.Argument = new ExampleResponse()
            {
                IntData = 3,
                StringData = "asdf",
                ListData = new List<ListElementType>()
                {
                    new ListElementType()
                    {
                        Address = "address",
                        Area = "area",
                        Town = "town"
                    }
                }
            }.XmlSerialize().ToXmlElement();
            var res = logRecord.XmlSerialize();
        }
    }
}
