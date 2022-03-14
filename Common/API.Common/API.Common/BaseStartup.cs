using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using TechnoLogica.API.Common.Attributes;
using TechnoLogica.API.Common.Infrastructure;
using TechnoLogica.API.Common.Settings;
using TechnoLogica.API.Common.Swagger;
using TechnoLogica.API.DataContracts;
using TechnoLogica.API.Services;
using TechnoLogica.Common.DataProtection;

namespace TechnoLogica.API.Common
{
    public class BaseStartup<IService, IRepository>
    {
        public IConfiguration Configuration { get; private set; }
        public IWebHostEnvironment HostingEnvironment { get; private set; }
        protected AppSettings _appSettings;

        private const string CORSPolicy = "CORSPolicy";
        private const string MediaTypeHeader = "application/prs.mock-odata";
        //version
        private const int Major = 1;
        private const int Minor = 0;

        public BaseStartup(IConfiguration configuration, IWebHostEnvironment env)
        {
            HostingEnvironment = env;
            Configuration = configuration;
        }

        public virtual Assembly[] CompositionAssemblies { get => new Assembly[] { }; }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            ConfigureBusinessServices(services);
            ConfigureMaxPageSize();
            ConfigureVersionedApiExplorer(services);
            ConfigureApiVersioning(services);
            ConfigureServicesScan(services);
            ConfigureRepositoryScan(services);
            ConfigureJsonSerializerSettings(services);
            ConfigureOData(services);
            ConfigureSwagger(services);
            ConfigureCORS(services);
            ConfigureAuthorization(services);
            ConfigureOAuthTokenConsumption(services);
            ConfigureRouting(services);
            ConfigureComposition(services);
            ConfigureDataProtection(services);
        }

        private void ConfigureMaxPageSize()
        {
            if (_appSettings.MaxPageSize.HasValue)
            {
                BaseServiceConstants.MaxPageSize = _appSettings.MaxPageSize.Value;
            }
        }

        private void ConfigureDataProtection(IServiceCollection services)
        {
            var dataProtectionBuilder =
               services
               .AddDataProtection();
            if (_appSettings.SigningCredential != null)
            {
                dataProtectionBuilder = 
                    dataProtectionBuilder
                    .ProtectKeysWithCertificate(_appSettings.SigningCredential.GetX509Certificate2());
            }
            var serviceProvider = services.BuildServiceProvider();
            var compositionContainer = serviceProvider.GetService<CompositionContainer>();
            var dataProtectionStore = compositionContainer.GetExportedValueOrDefault<IDataProtectionKeyStoreProvider>();
            if (dataProtectionStore != null)
            {
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                dataProtectionStore.AddPersistance(dataProtectionBuilder, Configuration, loggerFactory);
            }
            var dataProtectionProvider = services.BuildServiceProvider().GetService<IDataProtectionProvider>();
            compositionContainer.ComposeExportedValue(dataProtectionProvider);
        }

        private void ConfigureComposition(IServiceCollection services)
        {
            AggregateCatalog catalog = new AggregateCatalog();
            foreach (var compositionAssembly in CompositionAssemblies)
            {
                catalog.Catalogs.Add(
                    new AssemblyCatalog(compositionAssembly)
                    );
            }
            CompositionContainer compositionContainer = new CompositionContainer(catalog, true);
            compositionContainer.ComposeExportedValue(Configuration);
            compositionContainer.ComposeExportedValue(compositionContainer);
            services.AddSingleton(typeof(CompositionContainer), compositionContainer);
        }

        private void ConfigureRouting(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        private void ConfigureCORS(IServiceCollection services)
        {
            //CORS configuration 
            if (_appSettings.IsValid())
            {
                if (_appSettings.CORS.Enabled)
                {
                    services.AddCors(options =>
                    {
                        options.AddPolicy(CORSPolicy,
                            builder =>
                            {
                                builder
                                    .WithOrigins(_appSettings.CORS.Origins);
                                if (_appSettings.CORS.Header.Equals("*"))
                                {
                                    builder.AllowAnyHeader();
                                }
                                else
                                {
                                    builder.WithHeaders(_appSettings.CORS.Header);
                                }
                                if (_appSettings.CORS.Method.Equals("*"))
                                {
                                    builder.AllowAnyMethod();
                                }
                                else
                                {
                                    builder.WithHeaders(_appSettings.CORS.Method);
                                }
                            });
                    });
                }
            }
        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            //Swagger configuration
            if (_appSettings.IsValid())
            {
                if (_appSettings.Swagger.Enabled)
                {
                    // Register the Swagger generator, defining 1 or more Swagger documents
                    services.AddSwaggerGen(options =>
                    {
                        // resolve the IApiVersionDescriptionProvider service
                        // note: that we have to build a temporary service provider here because one has not been created yet
                        var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

                        // add a swagger document for each discovered API version
                        // note: you might choose to skip or document deprecated API versions differently
                        foreach (var description in provider.ApiVersionDescriptions)
                        {
                            options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
                        }

                        //// add a custom operation filter which sets default values
                        options.OperationFilter<SwaggerDefaultValues>();

                        //// integrate xml comments
                        options.IncludeXmlComments(XmlCommentsFilePath, includeControllerXmlComments: true);

                    });
                    //  services.AddSwaggerGenNewtonsoftSupport(); // explicit opt-in
                }
            }
        }

        private static void ConfigureOData(IServiceCollection services)
        {
            services.AddOData().EnableApiVersioning();
            services.AddODataQueryFilter();

            //configuration to make swagger work with odata
            services.AddMvc(op =>
            {
                foreach (var formatter in op.OutputFormatters
                    .OfType<ODataOutputFormatter>()
                    .Where(it => !it.SupportedMediaTypes.Any()))
                {
                    formatter.SupportedMediaTypes.Add(
                        new MediaTypeHeaderValue(MediaTypeHeader));
                }
                foreach (var formatter in op.InputFormatters
                    .OfType<ODataInputFormatter>()
                    .Where(it => !it.SupportedMediaTypes.Any()))
                {
                    formatter.SupportedMediaTypes.Add(
                        new MediaTypeHeaderValue(MediaTypeHeader));
                }
            });
        }

        private void ConfigureJsonSerializerSettings(IServiceCollection services)
        {
            var mvcBuilder = services
                .AddMvc(opt => opt.Filters.Add(typeof(CustomFilterAttribute)))
                .AddNewtonsoftJson(opt =>
                        opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                );
            //.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            if (_appSettings.IsValid())
            {
                if (_appSettings.PascalCaseOutput.Enabled)
                {
                    mvcBuilder.AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
                }
                if (_appSettings.NullValueHandling.HasValue)
                {
                    mvcBuilder.AddNewtonsoftJson(options => options.SerializerSettings.NullValueHandling = _appSettings.NullValueHandling.Value);
                }
            }

        }

        private static void ConfigureRepositoryScan(IServiceCollection services)
        {
            // Configuration for repositories scan
            services.Scan(scan => scan
                    .FromAssemblyOf<IRepository>()
                    .AddClasses()
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());
        }

        private static void ConfigureServicesScan(IServiceCollection services)
        {
            // Configuration for services scan
            services.Scan(scan => scan
                    .FromAssemblyOf<IService>()
                    .AddClasses()
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());
        }

        private static void ConfigureApiVersioning(IServiceCollection services)
        {
            //API Version
            services.AddApiVersioning(
                o =>
                {
                    //o.Conventions.Controller<UserController>().HasApiVersion(1, 0);
                    o.ReportApiVersions = true;
                    o.AssumeDefaultVersionWhenUnspecified = true;
                    o.DefaultApiVersion = new ApiVersion(Major, Minor);
                    o.ApiVersionReader = new UrlSegmentApiVersionReader();
                }
            );
        }

        private static void ConfigureVersionedApiExplorer(IServiceCollection services)
        {
            //API Explorer (for API Versioning)
            // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
            // note: the specified format code will format the version as "'v'major[.minor][-status]"
            services.AddVersionedApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";

                    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                    // can also be used to control the format of the API version in route templates
                    options.SubstituteApiVersionInUrl = true;
                });
        }

        private void ConfigureBusinessServices(IServiceCollection services)
        {
            //Business settings
            _appSettings = services.ConfigureBusinessServices(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            ILoggerFactory loggerFactory,
            IApiVersionDescriptionProvider provider)
        {
            app.UseExeptionHandling(env, loggerFactory, Configuration);

            app.UseHttpsRedirection();

            // Swagger section
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            if (_appSettings.IsValid())
            {
                if (_appSettings.Swagger.Enabled)
                {
                    app.UseSwaggerConfig(provider);
                }
            }

            app.UseAuthentication();

            if (_appSettings.IsValid())
            {
                if (_appSettings.CORS.Enabled)
                {
                    app.UseCors(CORSPolicy);
                }
            }

            app.UseMvc(
                routeBuilder =>
                {
                    routeBuilder.EnableDependencyInjection();
                }
            );
        }

        string XmlCommentsFilePath
        {
            get
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var fileName = this.GetType().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }

        private void ConfigureAuthorization(IServiceCollection services)
        {
            if (_appSettings.IsValid() && (_appSettings.Authentication?.Enabled ?? false))
            {
                services.AddAuthorization();
                services
                    .AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                    .AddIdentityServerAuthentication(options =>
                    {
                        options.Authority = _appSettings.Authentication.TokenIssuer;
                        options.ApiName = _appSettings.Authentication.APIName;
                        options.ApiSecret = _appSettings.Authentication.APISecret;
                        options.EnableCaching = false; // Do not cache credentials - always rely on identity server
                    });
            }
        }

        OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = $"{_appSettings.API.Title} {description.ApiVersion}",
                Version = description.GroupName,
                Description = _appSettings.API.Description
                //Contact = new Contact() { Name = "Bill Mei", Email = "bill.mei@somewhere.com" },
                //TermsOfService = "Shareware",
                //License = new License() { Name = "MIT", Url = "https://opensource.org/licenses/MIT" }
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }

        private void ConfigureOAuthTokenConsumption(IServiceCollection services)
        {

            if (_appSettings.IsValid() && (_appSettings.OAuthSecurity?.Enabled ?? false))
            {
                services.AddAuthorization();

                string audienceId = _appSettings.OAuthSecurity.AudienceId;  //the expected audience id 
                string issuer = _appSettings.OAuthSecurity.Issuer;   //this issuer has to be the same as the issuer in the token 
                var secret = _appSettings.OAuthSecurity.AudienceSecret;

                services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(cfg =>
                    {
                        cfg.RequireHttpsMetadata = false;
                        cfg.SaveToken = true;

                        var tokenValidationParameters = new TokenValidationParameters
                        {
                            ValidIssuer = issuer,
                            ValidAudience = audienceId,
                            IssuerSigningKey = new SymmetricSecurityKey(WebEncoders.Base64UrlDecode(secret)),
                            ValidateLifetime = true,
                            ClockSkew = TimeSpan.Zero
                        };


                        cfg.TokenValidationParameters = tokenValidationParameters;
                    });
            }
        }
    }
}
