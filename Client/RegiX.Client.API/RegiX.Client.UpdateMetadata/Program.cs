using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories;
using TechnoLogica.RegiX.Client.Repositories.Contracts;
using TechnoLogica.RegiX.Client.Repositories.Impl;
using TechnoLogica.RegiX.Client.Services.Contracts;
using TechnoLogica.RegiX.Client.Services.Services;

namespace RegiX.Client.UpdateMetadata
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration configuration =
                new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();
            MetadataSyncService.REGIX_INFO_URL = configuration.GetValue<string>("RegiXInfoURL");

            var serviceProvider = new ServiceCollection()
                      .AddLogging( opt => {
                          opt.AddConsole(
                              options => 
                              { 
                                  options.LogToStandardErrorThreshold = LogLevel.Debug;
                                  options.TimestampFormat = "yyyy-MM-dd hh:mm:ss ";
                              }
                          );
                      })
                      .AddSingleton<IMetadataSyncService, MetadataSyncService>()
                      .AddSingleton<IRegistersRepository, RegistersRepository>()
                      .AddSingleton<IAuthoritiesRepository, AuthoritiesRepository>()
                      .AddSingleton<IAdapterOperationsRepository, AdapterOperationsRepository>()
                      .AddSingleton<IUserContext, UserContext>()
                      .AddDbContext<RegiXClientContext>(
                            options => options.UseSqlServer(configuration.GetConnectionString("RegiXClientDatabase"))
                        )
                      .BuildServiceProvider();

            var syncService = serviceProvider.GetService<IMetadataSyncService>();
            syncService.UpdateMetadata();
        }
    }

    class UserContext : IUserContext
    {
        public int? UserId => null;

        public string UserName => "UpdateMetadataClient";

        public int? AdministrationID => null;

        public string[] Role => new string[] { };

        public string PublicUserIdentifier => throw new NotImplementedException();

        public string PublicUserIdentifierType => throw new NotImplementedException();

        public int[] RoleID => new int[] { };

        public bool IsPublic => throw new NotImplementedException();

        public bool IsGlobalAdmin => throw new NotImplementedException();

        public bool IsAdmin => throw new NotImplementedException();
    }
}
