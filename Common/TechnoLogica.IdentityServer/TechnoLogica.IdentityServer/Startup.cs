using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TechnoLogica.Authentication.Common;
using TechnoLogica.Common;
using TechnoLogica.Mail;

namespace TechnoLogica.IdentityServer
{

    public class Startup
    {
        private const string CORSPolicy = "CORSPolicy";
        public static string CSP_FRAME_ANCESTORS = "";
        public static string CSP_JS_HASH = "";

        public IConfiguration Configuration { get; set; }

        public IWebHostEnvironment Environment { get; }
        public ILoggerFactory LoggerFactory { get; set; }

        protected IdentityServer IdentityServerSettings { get; private set; }

        public Startup(IWebHostEnvironment environment, IConfiguration config, ILoggerFactory loggerFactory)
        {
            Environment = environment;
            Configuration = config;
            LoggerFactory = loggerFactory;
            IdentityServerSettings = Configuration.GetSettings<IdentityServer>();
        }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            var part = new AssemblyPart(this.GetType().Assembly);

            services.AddSingleton(IdentityServerSettings);

            services.AddControllersWithViews()
                    .ConfigureApplicationPartManager(apm => apm.ApplicationParts.Add(part))
                    .AddNewtonsoftJson();

            CompositionContainer compositionContainer = CreateContainer(services, IdentityServerSettings, Environment.ContentRootPath);

            AddDataProtection(services, compositionContainer);

            AddDistributedCache(services, compositionContainer);

            AddAuthenticationProviders(services, compositionContainer);

            ConfigureCORS(services, IdentityServerSettings.CORS);

            services.AddMvc(options => options.EnableEndpointRouting = false);

            var builder = services.AddIdentityServer(options =>
            {
                if (IdentityServerSettings.CookieLifetime.HasValue)
                {
                    options.Authentication.CookieLifetime = IdentityServerSettings.CookieLifetime.Value;
                }
                if (IdentityServerSettings.CookieSlidingExpiration.HasValue)
                {
                    options.Authentication.CookieSlidingExpiration = IdentityServerSettings.CookieSlidingExpiration.Value;
                }
            })
                    .AddCustomAuthorizeRequestValidator<CustomAuthorizeRequestValidator>()
                    .AddProfileService<ProfileService>()
                    .AddInMemoryIdentityResources(Configuration.GetSection("IdentityServer:IdentityResources"))
                    .AddInMemoryApiScopes(Configuration.GetSection("IdentityServer:ApiScopes"))
                    .AddInMemoryApiResources(Configuration.GetSection("IdentityServer:ApiResources"))
                    .AddInMemoryClients(Configuration.GetSection("IdentityServer:Clients"));

            var operationalStore = compositionContainer.GetExportedValueOrDefault<IOperationalStore>();

            if (operationalStore != null)
            {
                operationalStore.AddOperationalStore(builder, Configuration);
            }

            ConfigureAuthenticationProfiles(services, compositionContainer);
            services.AddTransient<UserValidator>();
            services.AddTransient<IMailService, MailService>();

            if (Environment.IsDevelopment())
            {
                builder.AddDeveloperSigningCredential();
                CSP_FRAME_ANCESTORS = "http://localhost:4200";
            }
            else
            {
                builder.AddSigningCredential(IdentityServerSettings.SigningCredential.GetX509Certificate2());
                CSP_FRAME_ANCESTORS = IdentityServerSettings.CspFrameAncestors;
            }

            CSP_JS_HASH = IdentityServerSettings.CspJSHash;
        }

        private void AddDistributedCache(IServiceCollection services, CompositionContainer compositionContainer)
        {
            var distributedCacheProvider = compositionContainer.GetExportedValueOrDefault<IDistributionCacheProvider>();
            if (distributedCacheProvider != null)
            {
                distributedCacheProvider.AddDistributedCache(services, Configuration);
            }
        }

        private void AddDataProtection(IServiceCollection services, CompositionContainer compositionContainer)
        {
            AddDataProtection(services, compositionContainer, IdentityServerSettings, Configuration, LoggerFactory);
        }

        public void AddDataProtection(IServiceCollection services, CompositionContainer compositionContainer, IdentityServer identityServerSettings, IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            var dataProtectionBuilder = services.AddDataProtection()
                                                .ProtectKeysWithCertificate(identityServerSettings.SigningCredential.GetX509Certificate2());

            var dataProtectionStore = compositionContainer.GetExportedValueOrDefault<IDataProtectionKeyStoreProvider>();

            if (dataProtectionStore != null)
            {
                dataProtectionStore.AddPersistance(dataProtectionBuilder, configuration, loggerFactory);
            }

            var dataProtectionProvider = services.BuildServiceProvider().GetService<IDataProtectionProvider>();
            compositionContainer.ComposeExportedValue(dataProtectionProvider);
        }

        private void ConfigureAuthenticationProfiles(IServiceCollection services, CompositionContainer compositionContainer)
        {
            var authenticationProfiles = compositionContainer.GetExportedValues<IAuthenticationProfile>();
            foreach (var authenticationProfile in authenticationProfiles)
            {
                authenticationProfile.Configure(services, Configuration);
            }
        }

        private void AddAuthenticationProviders(IServiceCollection services, CompositionContainer compositionContainer)
        {
            var authenticationProviders = compositionContainer.GetExportedValues<IAuthenticationProvider>();
            foreach (var authenticationProvider in authenticationProviders)
            {
                authenticationProvider.AddAuthentication(services, Configuration);
            }
        }

        private CompositionContainer CreateContainer(IServiceCollection services, IdentityServer identityServerSettings, string rootPath)
        {
            AggregateCatalog catalog = new AggregateCatalog();

            foreach (string module in identityServerSettings.CompositionModules)
            {
                catalog.Catalogs.Add(new DirectoryCatalog(rootPath, module));
            }

            CompositionContainer compositionContainer = new CompositionContainer(catalog, true);
            compositionContainer.ComposeExportedValue(Configuration);
            compositionContainer.ComposeExportedValue(compositionContainer);
            services.AddSingleton(typeof(CompositionContainer), compositionContainer);
            return compositionContainer;
        }

        private void ConfigureCORS(IServiceCollection services, CORSSettings cors)
        {
            if (cors != null && cors.Enabled)
            {
                services.AddCors(options =>
                {
                    options.AddPolicy(CORSPolicy, builder =>
                    {
                        builder.WithOrigins(cors.Origins);
                        if (cors.Headers.Length == 1 && cors.Headers[0].Equals("*"))
                        {
                            builder.AllowAnyHeader();
                        }
                        else
                        {
                            builder.WithHeaders(cors.Headers);
                        }
                        if (cors.Methods.Length == 1 && cors.Methods[0].Equals("*"))
                        {
                            builder.AllowAnyMethod();
                        }
                        else
                        {
                            builder.WithHeaders(cors.Methods);
                        }
                    });
                });
            }
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (IdentityServerSettings.SSLOffloaded)
            {
                app.Use((context, next) =>
                {
                    context.Request.Scheme = "https";
                    return next();
                });
            }

            if (IdentityServerSettings.UseForwardHeaders)
            {
                app.UseForwardedHeaders(new ForwardedHeadersOptions
                {
                    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
                });
            }

            if (string.IsNullOrEmpty(IdentityServerSettings.MappingPath))
            {
                ConfigureApplication(app);
            }
            else
            {
                app.Map(IdentityServerSettings.MappingPath, idServer =>
                {
                    ConfigureApplication(idServer);
                });
            }
        }

        private void ConfigureApplication(IApplicationBuilder app)
        {
            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseStaticFiles();

            if (IdentityServerSettings.CORS != null && IdentityServerSettings.CORS.Enabled)
            {
                app.UseCors(CORSPolicy);
            }

            app.UseMvcWithDefaultRoute();
        }
    }
}
