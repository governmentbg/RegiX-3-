using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories;

namespace RegiX.Client.Repositories.Tests
{
    class TestDataContextFactory
    {
        private readonly DbContextOptions<RegiXClientContext> _options;
        private IUserContext UserContext { get; set; }

        public TestDataContextFactory()
        {
            var builder = new DbContextOptionsBuilder<RegiXClientContext>();
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            builder.UseSqlite(connection);
            builder.EnableSensitiveDataLogging();
            var userContextMock = new Mock<IUserContext>();
            userContextMock.SetupGet(u => u.UserId).Returns(1);
            userContextMock.SetupGet(u => u.UserName).Returns("test_user");
            UserContext = userContextMock.Object;
            using (var ctx = new RegiXClientContext(builder.Options, UserContext))
            {
                ctx.Database.EnsureCreated();
                AddDefaultData(ctx);
            }

            _options = builder.Options;
        }
        public RegiXClientContext Create() => new RegiXClientContext(_options, UserContext);
        private static void AddDefaultData(RegiXClientContext ctx)
        {
            // Execute SQL comand is used because ID = 0 couldn't be inserted as entity
            var rowCount = ctx.Database.ExecuteSqlCommand("INSERT INTO AUTHORITIES('ID', 'NAME', 'ACRONYM', 'CREATED_BY', 'CREATED_ON', 'IS_MULTITENANT_AUTHORITY') VALUES (0, 'ROOT', 'ROOT', 'SYSTEM', '2019-12-01', 1)");
            ctx.Authorities.Add(new Authorities() { Id = 1, Name = "Administration", Acronym = "AD", IsMultitenantAuthority = true });
            ctx.Authorities.Add(new Authorities() { Id = 2, Name = "AdministrationTwo", Acronym = "ADTwo", IsMultitenantAuthority = true });

            ctx.Users.Add(new Users() { Id = 1, UserName = "basic_user", Name = "Basic User", IsActive = true });
            ctx.Users.Add(new Users() { Id = 2, UserName = "public_user", Name = "Public User", IsActive = true });
            ctx.Users.Add(new Users() { Id = 3, UserName = "admin_user", Name = "Admin User", IsActive = true });
            ctx.Users.Add(new Users() { Id = 4, UserName = "global_admin_user", Name = "GlobalAdmin User", IsActive = true });

            ctx.Roles.Add(new Roles() { Id = 1, Name = "Basic role", AuthorityId = 1 });
            ctx.Roles.Add(new Roles() { Id = 2, Name = "Administrator", AuthorityId = 1 });
            ctx.Roles.Add(new Roles() { Id = 3, Name = "Global Administrator", AuthorityId = 0 });

            ctx.Registers.Add(new Registers() { Id = 1, AuthorityId = 1, Name = "Test Register" });
            ctx.Registers.Add(new Registers() { Id = 2, AuthorityId = 1, Name = "DemoRegister" });

            ctx.AdapterOperations.Add(new AdapterOperations() { Id = 1, RegisterId = 1, OperationName = "OperationName", DisplayOperationName = "Operation", ControllerName = "Controller", RequestObjectName = "RequestObject", Namespace = "TechnoLogica" });

            ctx.Reports.Add(new Reports() { Id = 1, Name = "Report", AdapterOperationId = 1, AuthorityId = 1 });
            ctx.Reports.Add(new Reports() { Id = 2, Name = "ReportTwo", AdapterOperationId = 1, AuthorityId = 1 });

            ctx.AuditExceptions.Add(new AuditExceptions() { Id = 1, AuthorityId = 1, UserId = 1 });
            ctx.AuditExceptions.Add(new AuditExceptions() { Id = 2, AuthorityId = 1, UserId = 1 });
            ctx.AuditExceptions.Add(new AuditExceptions() { Id = 3, AuthorityId = 2, UserId = 1 });

            ctx.AuditReportExecutions.Add(new AuditReportExecutions() { Id = 1, AuthorityId = 1, UserId = 1, ReportId = 1 });
            ctx.AuditReportExecutions.Add(new AuditReportExecutions() { Id = 2, AuthorityId = 1, UserId = 1, ReportId = 1 });
            ctx.AuditReportExecutions.Add(new AuditReportExecutions() { Id = 3, AuthorityId = 2, UserId = 1, ReportId = 1 });

            ctx.AuditTables.Add(new AuditTables() { Id = 1, UserId = 1, AuthorityId = 1, Action = "Created", TableName = "Users", TableId = 1 });

            ctx.Set<UsersFavouriteReports>().Add(new UsersFavouriteReports() { Id = 1, UserId = 1, ReportId = 1 });
            ctx.Set<UsersFavouriteReports>().Add(new UsersFavouriteReports() { Id = 2, UserId = 2, ReportId = 1 });

            ctx.UsersToRoles.Add(new UsersToRoles() {RoleId = 1, UserId = 1});
            ctx.UsersToRoles.Add(new UsersToRoles() {RoleId = 2, UserId = 1});

            ctx.SaveChanges();
        }

       

        
    }
}
