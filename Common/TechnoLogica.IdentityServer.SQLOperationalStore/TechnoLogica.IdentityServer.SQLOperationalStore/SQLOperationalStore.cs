using IdentityServer4.KeyManagement.EntityFramework;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.Authentication.Common;
using TechnoLogica.Common;

namespace TechnoLogica.IdentityServer.SQLOperationalStore
{
    [Export(typeof(IOperationalStore))]
    [Export(typeof(IDataProtectionKeyStoreProvider))]
    [Export(typeof(IDistributionCacheProvider))]
    public class SQLOperationalStore : IOperationalStore, IDataProtectionKeyStoreProvider, IDistributionCacheProvider
    {

        public void AddOperationalStore(IIdentityServerBuilder builder, IConfiguration configuration)
        {
            builder.AddOperationalStore(
                    options =>
                {
                    var storeSettings = configuration.GetSettings<OperationalStore>();
                    options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(configuration.GetConnectionString(storeSettings.ConnectionStringName));
                    options.EnableTokenCleanup = storeSettings.EnableClenaup;
                    if (storeSettings.CleanupInterval != 0)
                    {
                        options.TokenCleanupInterval = storeSettings.CleanupInterval;
                    }
                }
            );
        }

        public IDataProtectionBuilder AddPersistance(IDataProtectionBuilder builder, IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            var storeSettings = configuration.GetSettings<OperationalStore>();
            string dataProtectionConnectionString = configuration.GetConnectionString(storeSettings.DataProtectionConnectionStringName ?? "DataProtection");
            return builder.PersistKeysToDatabase(new DatabaseKeyManagementOptions
            {
                ConfigureDbContext = b => b.UseSqlServer(dataProtectionConnectionString),
                LoggerFactory = loggerFactory,
            });
        }

        public void AddDistributedCache(IServiceCollection services, IConfiguration configuration)
        {
            var storeSettings = configuration.GetSettings<OperationalStore>();
            string distributedCacheConnectionString = configuration.GetConnectionString(storeSettings.DistributedCacheConnectionStringName ?? "DistributedCache");
            services.AddDistributedSqlServerCache(options =>
            {
                options.ConnectionString = distributedCacheConnectionString;
                options.SchemaName = "dbo";
                options.TableName = "DistributedCache";
            });
        }
    }
}
