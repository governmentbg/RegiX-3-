using Infosys.RegiX.CRCAdapter.AdapterService;
using Infosys.RegiX.CRCAdapter.CRC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;

namespace Infosys.RegiX.CRCAdapter.Test
{
    [TestClass]
    public class CRCAdapterTest : AdapterTest<AdapterService.CRCAdapter, ICRCAdapter>
    {
        //[TestMethod]
        public void FindAllMeasurementsTest()
        {
            AdapterService.CRCAdapter crcAdapter = new AdapterService.CRCAdapter();

            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters()
            {
                SignResult = false,
                ReturnAccessMatrix = true
            };

            CRCFindAllRequestType request = new CRCFindAllRequestType
            {
                DateFrom = new DateTime(2021, 6, 20, 0, 0, 0, DateTimeKind.Utc),
                DateTo = new DateTime(2021, 6, 30, 0, 0, 0, DateTimeKind.Utc)
            };

            var result = crcAdapter.FindAllMeasurements(request, AccessMatrix.CreateForType(typeof(CRCFindAllResponseType)), additionalParameters);

            Assert.IsTrue(result.Data.Response.Measurement.Count >= 0);
            //string xml = result.Data.Response.XmlSerialize();
           
            Console.WriteLine(result.Data.Response.XmlSerialize());
        }
    }
}
