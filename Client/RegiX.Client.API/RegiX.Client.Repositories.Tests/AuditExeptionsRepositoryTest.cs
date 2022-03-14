using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using TechnoLogica.RegiX.Client.Repositories;
using TechnoLogica.RegiX.Client.Repositories.Impl;

namespace RegiX.Client.Repositories.Tests
{
    [TestClass]
    public class AuditExeptionsRepositoryTest
    {
        [TestMethod]
        public void SelectAll_ExistingAuditExeption()
        {
            var dbContext = new TestDataContextFactory().Create();

            Mock<IUserContext> contextMock = new Mock<IUserContext>();
            contextMock.SetupGet(u => u.UserId).Returns(1);
            contextMock.SetupGet(u => u.AdministrationID).Returns(1);

            var repository = new AuditExceptionsRepository(dbContext, contextMock.Object);
            var result = repository.SelectAll();

            Assert.IsTrue(result.Count() == 2, $"Expected 2 got { result.Count()}");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SelectAll_NoAdministration()
        {
            var dbContext = new TestDataContextFactory().Create();
            Mock<IUserContext> contextMock = new Mock<IUserContext>();

            contextMock.SetupGet(u => u.AdministrationID).Returns((int?)null);

            var repository = new AuditExceptionsRepository(dbContext, contextMock.Object);

            var result = repository.SelectAll();
        }
    }
}
