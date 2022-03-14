using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.DaeuReportsAdapter;
using TechnoLogica.RegiX.DaeuReportsAdapter.AdapterService;

namespace RegiX.DaeuReportsAdapterTests
{
    //[TestClass]
    //public class SearchByIdentifierTests
    //{
    //    [TestMethod]
    //    public void SearchByIdentifierTests_Success()
    //    {
    //        DaeuReportsAdapter adapter = new DaeuReportsAdapter();
    //        var result = adapter.SearchByIdentifier(
    //            new SearchByIdentifierRequestType() {
    //                Identifier = "123456789",
    //                IdentifierType = IdentifierType.EIK }, 
    //            AccessMatrix.CreateForType(typeof(SearchByIdentifierResponse)),
    //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
    //        );
    //        Assert.IsTrue(result.Data.Response.ExecutedCalls.Count > 0);
    //        Console.WriteLine(result.Data.Response.XmlSerialize());
    //    }

    //    [TestMethod]
    //    public void SearchByIdentifierTests_Success_NoData()
    //    {
    //        DaeuReportsAdapter adapter = new DaeuReportsAdapter();
    //        var result = adapter.SearchByIdentifier(
    //            new SearchByIdentifierRequestType()
    //            {
    //                Identifier = "1234567",
    //                IdentifierType = IdentifierType.EIK
    //            },
    //            AccessMatrix.CreateForType(typeof(SearchByIdentifierResponse)),
    //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
    //        );
    //        Assert.IsTrue(result.Data.Response.ExecutedCalls.Count == 0);
    //    }

    //    [TestMethod]
    //    public void SearchByIdentifierTests_Success_NoDataForPeriod()
    //    {
    //        DaeuReportsAdapter adapter = new DaeuReportsAdapter();
    //        var result = adapter.SearchByIdentifier(
    //            new SearchByIdentifierRequestType()
    //            {
    //                Identifier = "123456789",
    //                IdentifierType = IdentifierType.EIK,
    //                DateFrom = DateTime.Now,
    //                DateFromSpecified = true
    //            },
    //            AccessMatrix.CreateForType(typeof(SearchByIdentifierResponse)),
    //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
    //        );
    //        Assert.IsTrue(result.Data.Response.ExecutedCalls.Count == 0);
    //        Console.WriteLine(result.Data.Response.XmlSerialize());
    //    }

    //    [TestMethod]
    //    public void SearchByIdentifierTests_Success_ExactlyOne()
    //    {
    //        DaeuReportsAdapter adapter = new DaeuReportsAdapter();
    //        var result = adapter.SearchByIdentifier(
    //            new SearchByIdentifierRequestType()
    //            {
    //                Identifier = "123456789",
    //                IdentifierType = IdentifierType.EIK,
    //                DateTo = new DateTime(2016,07,21),
    //                DateToSpecified = true
    //            },
    //            AccessMatrix.CreateForType(typeof(SearchByIdentifierResponse)),
    //            new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
    //        );
    //        Assert.IsTrue(result.Data.Response.ExecutedCalls.Count == 1);
    //        Console.WriteLine(result.Data.Response.XmlSerialize());
    //    }
    //}
}
