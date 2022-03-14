//using AutoMapper;
//using TechnoLogica.RegiX.Admin.API.Common.Settings;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using TechnoLogica.RegiX.Admin.IoC.Configuration.AutoMapper;

namespace TechnoLogica.RegiX.Admin.IoC.Configuration.DI
{
    public static class ServiceCollectionExtensions
    {
        //public static AppSettings ConfigureBusinessServices(this IServiceCollection services, IConfiguration configuration)
        //{            
        //    var appSettingsSection = configuration.GetSection(nameof(AppSettings));
        //    if (appSettingsSection == null)
        //        throw new Exception("No appsettings section has been found");

        //    var appSettings = appSettingsSection.Get<AppSettings>();

        //    if (!appSettings.IsValid())
        //        throw new Exception("No valid settings.");

        //    services.Configure<AppSettings>(appSettingsSection);

        //    //Automap settings
        //    services.AddAutoMapper();
        //    new MappingConfigurationsHelper().ConfigureMapper();
        //    return appSettings;
        //}
    }
}
