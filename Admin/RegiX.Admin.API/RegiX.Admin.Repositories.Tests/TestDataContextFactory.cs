using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using TechnoLogica.RegiX.Admin.Infrastructure;
//using Remotion.Linq.Parsing.Structure.NodeTypeProviders;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.Repositories.Tests
{
    public class TestDataContextFactory
    {
        private readonly DbContextOptions<RegiXContext> _options;
        private readonly IUserContext userContext;

        public TestDataContextFactory()
        {
            var builder = new DbContextOptionsBuilder<RegiXContext>();
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            builder.UseSqlite(connection);
            builder.EnableSensitiveDataLogging();
            var mock = new Mock<IUserContext>();
            mock.SetupGet(uc => uc.UserName).Returns("testUser");
            userContext = mock.Object;
            using (var ctx = new RegiXContext(builder.Options, userContext))
            {
                ctx.Database.EnsureCreated();
                AddDefaultData(ctx);
            }
            _options = builder.Options;
        }

        public RegiXContext Create() => new RegiXContext(_options, userContext);

        private static void AddDefaultData(RegiXContext ctx)
        {
            //var rowCount = ctx.Database.ExecuteSqlCommand("INSERT INTO ADMINISTRATIONS('ADMINISTRATION_ID', 'NAME', 'DESCRIPTION', 'DEPTH', 'ACRONYM', 'CODE', 'CREATED_ON', 'CREATED_BY', 'UPDATED_ON', 'UPDATED_BY', 'PUBLICLY_VISIBLE', 'ADMINISTRATION_TYPE_ID') VALUES (0, 'AdministrationName', 'AN', 0,'AN', 'AN', '2016-06-23 15:35:43.067', 'bbotev', '2017-06-23 15:55:43.067', 'bbotev', 1, 1)");

            //Administrations
            ctx.Administrations.Add(new Administrations() {AdministrationId = 1, Name = "Administration", Acronym = "AD"});
            ctx.Administrations.Add(new Administrations() {AdministrationId = 2, Name = "AdministrationTwo", Acronym = "ADT"});

            //Users
            ctx.Users.Add(new Users()
            {
                UserId = 1,
                IsAdmin = true,
                AdministrationId = 1,
                UserName = "UserNameTest",
                Name = "UserNameTest",
                Active = true,
                IsAnonymous = false,
                Password = "32#!A14G",
                Email = "test@mail.com",
                IsApproved = true,
                IsLockedOut = false,
                CreateDate = new DateTime(2015,03,05)
            });
            ctx.Users.Add(new Users() 
                { 
                    UserId = 3, 
                    IsAdmin = true,
                    UserName = "UserNameTestThree",
                    Name = "UserNameTestThree",
                    Active = true,
                    IsAnonymous = false, 
                    Password = "32#!A14G",
                    Email = "test@mail.com", 
                    IsApproved = true,
                    IsLockedOut = false, 
                    CreateDate = new DateTime(2015, 03, 05)
                });//Global Admin has no administration ID

            //AuditExceptions
            ctx.AuditExceptions.Add(new AuditExceptions(){AuditExceptionId = 1, UserId = 1});
            ctx.AuditExceptions.Add(new AuditExceptions(){AuditExceptionId = 2, UserId = 1});
            ctx.AuditExceptions.Add(new AuditExceptions(){AuditExceptionId = 3, UserId = 2});

            //Registers
            ctx.Registers.Add(new Registers() {RegisterId = 1, AdministrationId = 1,Name = "Register"});
            ctx.Registers.Add(new Registers() {RegisterId = 2, AdministrationId = 2, Name = "RegisterTwo"});

            //ApiServiceConsumers
            ctx.ApiServiceConsumers.Add(new ApiServiceConsumers(){ApiServiceConsumerId = 1, Name = "ApiServiceConsumerName", AdministrationId = 1});
            ctx.ApiServiceConsumers.Add(new ApiServiceConsumers(){ApiServiceConsumerId = 2, Name = "ApiServiceConsumerNameTwo", AdministrationId = 2});

            //ApiServices
            ctx.ApiServices.Add(new ApiServices(){ApiServiceId = 1, Name = "ApiServiceName", ServiceUrl = "TestServiceURL", Contract = "Contract.Test",AdministrationId = 1, IsComplex = true, Assembly = "TestAssembly.dll", Enabled = true});
            ctx.ApiServices.Add(new ApiServices(){ApiServiceId = 2, Name = "ApiServiceNameTwo", ServiceUrl = "TestServiceURL", Contract = "Contract.Test",AdministrationId = 2, IsComplex = true, Assembly = "TestAssembly.dll", Enabled = true});

            //RegisterAdapters
            ctx.RegisterAdapters.Add(new RegisterAdapters(){RegisterAdapterId = 1, RegisterId = 1, Name = "RegisterAdapterName", AdapterUrl = "AdapterURL", BindingConfigName = "BindingConfigName",Contract = "ContractName", BindingType = "BindingType", Assembly = "TestAssembly.dll" });
            ctx.RegisterAdapters.Add(new RegisterAdapters(){RegisterAdapterId = 2, RegisterId = 2, Name = "RegisterAdapterName", AdapterUrl = "AdapterURL", BindingConfigName = "BindingConfigName",Contract = "ContractName", BindingType = "BindingType", Assembly = "TestAssembly.dll" });

            //AdapterHealthFunctions
            ctx.AdapterHealthFunctions.Add(new AdapterHealthFunctions(){AdapterHealthFunctionId = 1, Code = "CodeTest", RegisterAdapterId = 1});
            ctx.AdapterHealthFunctions.Add(new AdapterHealthFunctions(){AdapterHealthFunctionId = 2, Code = "CodeTest", RegisterAdapterId = 2});

            //AdapterHealthResults
            ctx.AdapterHealthResults.Add(new AdapterHealthResults() {AdapterHealthResultId = 1, RegisterAdapterId = 1, AdapterHealthFunctionId = 1,ExecuteTime = new DateTime(2019,02,02)});
            ctx.AdapterHealthResults.Add(new AdapterHealthResults() {AdapterHealthResultId = 2, RegisterAdapterId = 2, AdapterHealthFunctionId = 1,ExecuteTime = new DateTime(2019,02,02)});

            //AdapterOperations
            ctx.AdapterOperations.Add(new AdapterOperations() {AdapterOperationId = 1, RegisterAdapterId = 1, Name = "AdapterOperationName"});
            ctx.AdapterOperations.Add(new AdapterOperations() {AdapterOperationId = 2, RegisterAdapterId = 2, Name = "AdapterOperationName"});

            ctx.AdapterPingResults.Add(new AdapterPingResults()
            {
                AdapterPingResultId = 1,
                ExecuteTime = new DateTime(2019, 03, 02),
                Timeout = 0,
                RegisterAdapterId = 1
            });
            ctx.AdapterPingResults.Add(new AdapterPingResults()
            {
                AdapterPingResultId = 2,
                ExecuteTime = new DateTime(2019, 03, 02),
                Timeout = 0,
                RegisterAdapterId = 2
            });

            ctx.SaveChanges();
        }
    }
}