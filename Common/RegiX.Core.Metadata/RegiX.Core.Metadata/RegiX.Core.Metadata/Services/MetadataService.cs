using RegiX.Core.Metadata.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.ReflectionModel;
using System.Linq;
using System.Reflection;
using TechnoLogica.RegiX.Adapters.Common.Attributes;
using TechnoLogica.RegiX.Adapters.Common.Utils;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Core.Data.Interfaces;
using TechnoLogica.RegiX.Core.Data.Interfaces.Models;

namespace RegiX.Core.Metadata.Services
{

    [Export(typeof(IMetadataService))]
    public class MetadataService : IMetadataService
    {
        public IEnumerable<AdapterVersion> GetRegisteredAdapters()
        {
            var apis = Composition.CompositionContainer.GetExportedValues<IAPIService>();

            var result = apis.Select(a =>
            {
                var assembly = a.GetType().Assembly.GetName();

                return new AdapterVersion
                {
                    AdapterAssembly = assembly.Name + ".dll",
                    VersionOfAdapter = assembly.Version.ToString(),
                    AdapterName = assembly.FullName.ToString(),
                };
            });
            return result;
        }

        public IEnumerable<AdapterVersion> GetNotRegisteredAdapters()
        {
            var regixDataService = Composition.CompositionContainer.GetExportedValue<IRegiXData>();
            var allAdapters = regixDataService.GetAllAdapters(); // From db
            var registeredAdapters = this.GetRegisteredAdapters();//From RegiX's Core
            var registeredAdapterAssemblies = allAdapters.Select(x => x.AdapterAssembly);
            var notRegistered = registeredAdapters.Where(x => !registeredAdapterAssemblies.Contains(x.AdapterAssembly));

            var result = notRegistered.Select(x => new AdapterVersion
            {
                AdapterAssembly = x.AdapterAssembly,
                AdapterContract = x.AdapterContract,
                AdapterName = x.AdapterName.Split(',')[0],
                VersionOfAdapter = x.VersionOfAdapter
            }).ToList();

            return result;
        }

        //Returns registered adapter with difference in versions between the core and DB
        public IEnumerable<AdapterVersion> GetRegisteredAdaptersWithDiffVersions()
        {
            var regixDataService = Composition.CompositionContainer.GetExportedValue<IRegiXData>();

            var allAdapters = regixDataService.GetAllAdapters(); // From db
            var registeredAdapters = this.GetRegisteredAdapters();
            var registeredAdapterAssemblies = registeredAdapters.Select(x => x.AdapterAssembly);

            var registeredFromDb = allAdapters
                .Where(x => registeredAdapterAssemblies.Contains(x.AdapterAssembly))
                .Select(x => new AdapterVersion
                {
                    AdapterAssembly = x.AdapterAssembly,
                    AdapterContract = x.AdapterContract,
                    AdapterName = x.AdapterName,
                    VersionOfAdapter = x.VersionOfAdapter
                }).ToList();

            var registeredAdaptersWithDiffVersions = GetRegisteredAdaptersWithDiffVersions(registeredFromDb, registeredAdapters);

            return registeredAdaptersWithDiffVersions;
        }

        public IEnumerable<AdapterInfo> GetAdaptersInfo()
        {
            var apis = Composition.CompositionContainer.GetExportedValues<IAPIService>();

            var adaptersFullName = apis
                .Select(a
                        => a.GetType()
                        .FullName
                        .Replace(a.GetType().Name, "I" + a.GetType().Name))
                .ToList();

            var result = new List<AdapterInfo>();

            foreach (var fullName in adaptersFullName)
            {
                result.Add(this.GetAdapterInfo(fullName));
            }

            return result;
        }

        public IEnumerable<Adapter> GetFullAdapterInformation(string adapterFullName)
        {
            var apis = Composition.CompositionContainer.GetExportedValues<IAPIService>();
            var foundApIs =
                apis.Where(
                    a =>
                    {
                        var assemblyName = a.GetType().Assembly.GetName();
                        string adapterName = $"{ assemblyName.Name} { assemblyName.Version}";
                        return adapterName == adapterFullName;
                    }
                ).ToList();

            var result =
                foundApIs
                .Select(
                    a => a.GetType().GetAPIServiceInterface()
                )
                .Select(
                    t =>
                    {
                        DescriptionAttribute descriptionAttribute =
                            t.GetCustomAttributes(false).Where(ca => ca is DescriptionAttribute).SingleOrDefault() as DescriptionAttribute;
                        string description = "";
                        if (descriptionAttribute != null)
                        {
                            description = descriptionAttribute.Description;
                        }
                        var registerAdapter = new Adapter
                        {
                            Name = t.Name.Substring(1),
                            Contract = t.FullName,
                            Description = description,
                            BindingType = "BasicHttpBinding",
                            AdapterUrl = $"http://localhost:54319/{t.Name}.svc",
                            BindingConfigName = "DefaultAdapterClientBinding",
                            Assembly = $"{ t.GetType().Assembly.GetName().Name }.dll",
                            AdapterOperations = GetAdapterOperations(t)
                        };
                        return registerAdapter;
                    });
            return result.ToList();
        }

        public AdapterDataDto GetAllAdapterData(string adapterName)
        {
            var assembly =
                Composition
                    .CompositionContainer
                    .Catalog
                    .Parts
                    .Where(
                        p => p.ExportDefinitions.Any(
                                 e => e.ContractName == typeof(IAdapterService).FullName
                             ) && ReflectionModelServices.GetPartType(p).Value.Assembly.GetName().Name == adapterName)
                    .Select(ed => ReflectionModelServices.GetPartType(ed).Value)
                    .FirstOrDefault();

            var result =
                new AssemblyInspectorService()
                    .InspectAssembly(assembly?.Assembly.GetName().Name);

            return result;
        }


        private AdapterInfo GetAdapterInfo(string id)
        {
            var api = Composition.CompositionContainer.GetExportedValue<IAPIService>(id);
            return new AdapterInfo()
            {
                Name = api.GetType().Assembly.GetName().Name,
                Interface = api.GetType().GetAPIServiceInterface().FullName,
                Version = $"{api.GetType().Assembly.GetName().Version.Major}.{api.GetType().Assembly.GetName().Version.Minor}.{api.GetType().Assembly.GetName().Version.Build}",
                //   Description = ServicesController.GetAPIDescription(api),
                Operations = GetOperations(api)
            };
        }

        private IEnumerable<Operation> GetAdapterOperations(Type t)
        {
            return
                  t
                  .GetMethods()
                  .Select(
                      mi =>
                      {
                          var descriptionAttribute =
                            mi.GetCustomAttributes(false).Where(a => a is DescriptionAttribute).Cast<DescriptionAttribute>().FirstOrDefault();
                          string description = "";
                          if (descriptionAttribute != null)
                          {
                              description = descriptionAttribute.Description;
                          }
                          Operation adapterOperation =
                              new Operation()
                              {
                                  Name = mi.Name,
                                  Description = description,
                                  RegisterObject = GetRegisterObject(mi.ReturnType)
                              };
                          return adapterOperation;
                      }
                      )
                  .ToList();
        }

        private RegisterObject GetRegisterObject(Type registerObjectType)
        {
            Type responseForAmType = FindAmType(registerObjectType);

            string description = "";
            DescriptionAttribute descAttribute =
                responseForAmType.GetCustomAttributes(typeof(DescriptionAttribute), false).Cast<DescriptionAttribute>().FirstOrDefault();
            if (descAttribute != null)
            {
                description = descAttribute.Description;
            }

            RegisterObject registerObject = new RegisterObject();
            registerObject.Name = responseForAmType.Name;
            registerObject.FullName = responseForAmType.FullName;
            registerObject.Description = description;
            registerObject.RegisterObjectElements = new List<RegisterObjectElements>();
            GetAddRegisterObjectElement(responseForAmType.GetProperties(), "", registerObject);
            return registerObject;
        }

        private static Type FindAmType(Type registerObjectType)
        {
            Type responseForAmType = registerObjectType;
            if (registerObjectType.IsGenericType && registerObjectType.FullName.Contains("TechnoLogica.RegiX.Common.TransportObjects.ServiceResultDataSigned"))
            {
                Type[] typeArguments = registerObjectType.GetGenericArguments();
                Type responseType = typeArguments[1];
                //за изключения с custom AccessMatrix
                Type tryFindExeption = responseType.Assembly.GetType(responseType.FullName + "_AM");
                if (tryFindExeption != null)
                {
                    responseForAmType = tryFindExeption;//return CreateRegisterObjectResponseType(tryFindExeption);
                }
                else
                {
                    responseForAmType = responseType;//return CreateRegisterObjectResponseType(typeArguments[1]);
                }
            }

            return responseForAmType;
        }

        private void GetAddRegisterObjectElement(PropertyInfo[] properties, string path, RegisterObject registerObject)
        {
            foreach (PropertyInfo propertyInfo in properties)
            {
                if (!propertyInfo.Name.EndsWith("Specified"))
                {
                    string currentPath = string.IsNullOrEmpty(path) ? propertyInfo.Name : string.Format("{0}.{1}", path, propertyInfo.Name);
                    string description = "";
                    DescriptionAttribute descAttribute = propertyInfo.GetCustomAttributes(typeof(DescriptionAttribute), false).Cast<DescriptionAttribute>().FirstOrDefault();
                    if (descAttribute != null)
                    {
                        description = descAttribute.Description;
                    }

                    RegisterObjectElements objectElement = new RegisterObjectElements();
                    objectElement.Name = propertyInfo.Name;
                    objectElement.PathToRoot = currentPath;
                    objectElement.Description = description;

                    registerObject.RegisterObjectElements.Add(objectElement);
                    if (propertyInfo.PropertyType.Namespace != "System" &&
                        propertyInfo.PropertyType.Namespace != "System.Xml" &&
                        !(propertyInfo.PropertyType.IsArray &&
                        (propertyInfo.PropertyType.GetElementType().Namespace == "System" ||
                        propertyInfo.PropertyType.GetElementType().Namespace == "System.Xml")) &&
                        !(propertyInfo.PropertyType.IsGenericType &&
                        (propertyInfo.PropertyType.GetGenericArguments()[0].Namespace == "System" ||
                        propertyInfo.PropertyType.GetGenericArguments()[0].Namespace == "System.Xml")))
                    {
                        Type childType = propertyInfo.PropertyType;
                        if (propertyInfo.PropertyType.IsGenericType)
                        {
                            childType = childType.GetGenericArguments()[0];
                        }
                        else if (propertyInfo.PropertyType.IsArray)
                        {
                            childType = childType.GetElementType();
                        }
                        GetAddRegisterObjectElement(childType.GetProperties(), currentPath, registerObject);
                    }
                }
            }
        }

        private static IEnumerable<AdapterVersion> GetRegisteredAdaptersWithDiffVersions(IEnumerable<AdapterVersion> registeredFromDb, IEnumerable<IAdapterVersion> registeredAdapters)
        {
            var registeredAdaptersWithDiffVersions = new List<AdapterVersion>();

            foreach (var adapter in registeredFromDb)
            {
                var adapterCore = registeredAdapters.FirstOrDefault(a => a.AdapterAssembly == adapter.AdapterAssembly);

                if (adapterCore.VersionOfAdapter != adapter.VersionOfAdapter)
                {
                    registeredAdaptersWithDiffVersions.Add(adapter);
                }
            }

            return registeredAdaptersWithDiffVersions;
        }

        private static IEnumerable<OperationInfo> GetOperations(IAPIService api)
        {
            return
                api
                    .GetType()
                    .GetAPIServiceInterface()
                    .GetMethods()
                    .Select(
                        m =>
                            new OperationInfo()
                            {
                                FullName = m.Name,
                                RequestXSD = api.GetRequestXSD(m.Name),
                                ResponseXSD = api.GetResponseXSD(m.Name),
                                SampleRequestXML = api.GetSampleRequest(m.Name),
                                SampleResponseXML = api.GetSampleResponse(m.Name),
                                CommonXSD = api.GetCommonXSD(m.Name),
                                CommonXSDNames = api.GetCommonXSDNames(m.Name),
                                MetaDataXML = api.GetMetaDataXML(m.Name),
                                RequestXslt = api.GetRequestXslt(m.Name),
                                ResponseXslt = api.GetResponseXslt(m.Name),
                                Description =
                                    ((DescriptionAttribute)
                                    m
                                    .GetCustomAttributes()
                                    .FirstOrDefault(a => (a is DescriptionAttribute))
                                    ).Description,
                                Request = GetRequest(m),
                                Response = GetResponse(m)
                            }
                    ).ToList();
        }

        private static Parameter GetResponse(MethodInfo m)
        {
            Parameter response = new Parameter();
            Type responseForAmType = FindAmType(m.ReturnParameter.ParameterType);
            GetAddRegisterObjectElement(responseForAmType.GetProperties(), response);
            response.Name = m.ReturnParameter.ParameterType.GetGenericArguments()[1].Name;

            string description = "Отговор";
            DescriptionAttribute descAttribute = responseForAmType.GetCustomAttributes(typeof(DescriptionAttribute), false).Cast<DescriptionAttribute>().FirstOrDefault();
            if (descAttribute != null)
            {
                description = descAttribute.Description;
            }
            response.Description = description;
            return response;
        }

        private static Parameter GetRequest(MethodInfo m)
        {
            Parameter request = new Parameter();
            Type requestType = m.GetParameters()[0].ParameterType.GetGenericArguments()[0];
            GetAddRegisterObjectElement(requestType.GetProperties(), request);
            request.Name = requestType.Name;
            string description = "Заявка";
            DescriptionAttribute descAttribute = requestType.GetCustomAttributes(typeof(DescriptionAttribute), false).Cast<DescriptionAttribute>().FirstOrDefault();
            if (descAttribute != null)
            {
                description = descAttribute.Description;
            }
            request.Description = "Заявка";
            return request;
        }

        private static void GetAddRegisterObjectElement(PropertyInfo[] properties, Parameter parameter)
        {
            foreach (PropertyInfo propertyInfo in properties)
            {
                if (!propertyInfo.Name.EndsWith("Specified"))
                {
                    Parameter child = new Parameter();

                    child.Name = propertyInfo.Name;
                    string description = "";
                    DescriptionAttribute descAttribute = propertyInfo.GetCustomAttributes(typeof(DescriptionAttribute), false).Cast<DescriptionAttribute>().FirstOrDefault();
                    if (descAttribute != null)
                    {
                        description = descAttribute.Description;
                    }

                    child.Description = description;
                    if (parameter.Children == null)
                    {
                        parameter.Children = new List<Parameter>();
                    }
                    parameter.Children.Add(child);

                    if (propertyInfo.PropertyType.Namespace != "System" &&
                        propertyInfo.PropertyType.Namespace != "System.Xml" &&
                        !(propertyInfo.PropertyType.IsArray &&
                        (propertyInfo.PropertyType.GetElementType().Namespace == "System" ||
                        propertyInfo.PropertyType.GetElementType().Namespace == "System.Xml")) &&
                        !(propertyInfo.PropertyType.IsGenericType &&
                        (propertyInfo.PropertyType.GetGenericArguments()[0].Namespace == "System" ||
                        propertyInfo.PropertyType.GetGenericArguments()[0].Namespace == "System.Xml")))
                    {
                        Type childType = propertyInfo.PropertyType;
                        if (propertyInfo.PropertyType.IsGenericType)
                        {
                            childType = childType.GetGenericArguments()[0];
                        }
                        else if (propertyInfo.PropertyType.IsArray)
                        {
                            childType = childType.GetElementType();
                        }
                        GetAddRegisterObjectElement(childType.GetProperties(), child);
                    }
                }
            }
        }

    }

    /// <summary>
    /// Patch for Common XSD file names
    /// </summary>
    public static class IAPIServiceExtensions
    {
        public static string[] GetCommonXSDNames(this IAPIService apiService, string operationName)
        {
            var operation = apiService.GetType().GetAPIServiceInterface().GetMethods().FirstOrDefault(mi => mi.Name == operationName);
            InfoAttribute info = (InfoAttribute)operation.GetCustomAttributes().FirstOrDefault(a => a is InfoAttribute);
            if (info != null  && !string.IsNullOrEmpty(info.CommonXSD))
            {
                return info.CommonXSD.Split(';');
            }
            else if (apiService.GetCommonXSD(operationName).Length > 0)
            {
                return new string[] { operationName + "Common.xsd" };
            }
            else
            {
                return new string[] { };
            }
        }
    }


    public class AdapterVersion : IAdapterVersion
    {
        public string AdapterName { get; set; }
        public string AdapterContract { get; set; }
        public string AdapterAssembly { get; set; }
        public string VersionOfAdapter { get; set; }
    }

    public class Adapter
    {
        public string Name { get; internal set; }
        public string Contract { get; internal set; }
        public string Description { get; internal set; }
        public string BindingType { get; internal set; }
        public string AdapterUrl { get; internal set; }
        public string BindingConfigName { get; internal set; }
        public string Assembly { get; internal set; }
        public object AdapterOperations { get; internal set; }
    }

    public class Operation
    {
        public string Name { get; internal set; }
        public string Description { get; internal set; }
        public RegisterObject RegisterObject { get; internal set; }
    }


    public class RegisterObject
    {
        public string Name { get; internal set; }
        public string FullName { get; internal set; }
        public string Description { get; internal set; }
        public List<RegisterObjectElements> RegisterObjectElements { get; internal set; }
    }

    public class RegisterObjectElements
    {
        public string Name { get; internal set; }
        public string PathToRoot { get; internal set; }
        public string Description { get; internal set; }
    }
}
