using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories;
using TechnoLogica.RegiX.Client.Repositories.Impl;

namespace RegiX.Client.Repositories.Tests
{
    [TestClass]
    public class UsersFavouriteReportsRepositoryTest
    {
        [TestMethod]
        public void SelectAll_ExistingUser()
        {
            var dbContext = new TestDataContextFactory().Create();

            Mock<IUserContext> contextMock = new Mock<IUserContext>();
            contextMock.SetupGet(u => u.UserId).Returns(1);

            var repository = new UsersFavouriteReportsRepository(dbContext, contextMock.Object);
            var result = repository.SelectAll();

            Assert.IsTrue(result.Count() == 1, $"Expected 1 got { result.Count()}");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SelectAll_NoUser()
        {
            var dbContext = new TestDataContextFactory().Create();

            Mock<IUserContext> contextMock = new Mock<IUserContext>();
            contextMock.SetupGet(u => u.UserId).Returns((int?)null);

            var repository = new UsersFavouriteReportsRepository(dbContext, contextMock.Object);
            var result = repository.SelectAll();
        }
    }

}
