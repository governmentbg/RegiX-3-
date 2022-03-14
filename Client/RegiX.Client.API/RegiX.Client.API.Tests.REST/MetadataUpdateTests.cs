using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Impl;
using TechnoLogica.RegiX.Client.Services.Services;

namespace TechnoLogica.RegiX.Client.API.Tests.REST
{   
    [TestClass]
    public class MetadataUpdateTests
    {
        [TestMethod]
        public void GetAuthoritiesTest()
        {
            //var service = new MetadataSyncService(
            //    new RegistersRepository(new RegiXClientContext()),
            //    new AuthoritiesRepository(new RegiXClientContext()),
            //    new AdapterOperationsRepository(new RegiXClientContext()),
            //    new Logger<MetadataSyncService>(new LoggerFactory()));

            //service.UpdateMetadata();//TODO : Save the changes to DB and finish updatemetadata
        }
    }
}