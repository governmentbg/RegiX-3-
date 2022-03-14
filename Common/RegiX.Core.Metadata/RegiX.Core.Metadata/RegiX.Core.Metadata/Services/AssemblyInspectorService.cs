using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Mono.Cecil;
using Mono.Cecil.Cil;
using RegiX.Core.Metadata.Dto;
using RegiX.Core.Metadata.Models;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;

namespace RegiX.Core.Metadata.Services
{
    public class AssemblyInspectorService
    {
        public Registers Register { get; set; }

        public Administrations Administration { get; set; }

        public AdapterDataDto InspectAssembly(
            string assemblyName)
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            var assembly = AppDomain.CurrentDomain.GetAssemblies()
                .FirstOrDefault(a => a.GetName().Name == assemblyName);

            var assemblyDefinition = AssemblyDefinition.ReadAssembly(assembly.Location);
            
            var registerObjects = new List<RegisterObjects>();

            var registerAdapters =
                assembly
                    .GetTypes()
                    .Where(
                        t =>
                            t.IsInterface &&
                            t.GetInterfaces().Any(ti => ti.FullName == typeof(IAdapterService).FullName))
                    .Select(
                        t =>
                        {
                            var descriptionAttribute =
                                t.GetCustomAttributes(false).Where(ca => ca is DescriptionAttribute).SingleOrDefault()
                                    as DescriptionAttribute;
                            var description = "";
                            if (descriptionAttribute != null) description = descriptionAttribute.Description;


                            var registerAdapter = new RegisterAdapters();
                            registerAdapter.Name = t.Name.Substring(1);
                            registerAdapter.Contract = t.FullName;
                            registerAdapter.Description = description;
                            registerAdapter.BindingType = "BasicHttpBinding";
                            registerAdapter.AdapterUrl = string.Format("http://localhost:54319/{0}.svc",
                                GetImplementationName(assembly, t));
                            registerAdapter.BindingConfigName = "DefaultAdapterClientBinding";
                            registerAdapter.Registers = Register;
                            registerAdapter.Assembly = assembly.GetName().Name + ".dll";


                            foreach (var operation in GetAdapterOperations(t, registerObjects, registerAdapter))
                                if (registerAdapter.AdapterOperations.Where(ao => ao.Name == operation.Name).Count() ==
                                    0)
                                {
                                    registerAdapter.AdapterOperations.Add(operation);
                                    operation.RegisterObjects.RegisterAdapterId =
                                        registerAdapter.RegisterAdapterId;
                                }

                            return registerAdapter;
                        })
                    .ToList();

            var apiServices =
                assembly
                    .GetTypes()
                    .Where(
                        t =>
                            t.IsInterface &&
                            t.GetInterfaces().Any(ti => ti.FullName == typeof(IAPIService).FullName))
                    .Select(
                        t =>
                        {
                            var descriptionAttribute =
                                t.GetCustomAttributes(false).Where(ca => ca is DescriptionAttribute).SingleOrDefault()
                                    as DescriptionAttribute;
                            var description = "";
                            if (descriptionAttribute != null) description = descriptionAttribute.Description;

                            ApiServices apiService = null;

                            if (apiService == null)
                            {
                                apiService = new ApiServices();
                                apiService.Name = t.Name.Substring(1);
                                apiService.Code = apiService.Name;
                                apiService.Contract = t.FullName;
                                apiService.Description = description;
                                apiService.ServiceUrl = string.Format("http://localhost/RegiX/{0}.svc",
                                    GetImplementationName(assembly, t));
                                apiService.IsComplex = registerAdapters.Count == 0;
                                apiService.Assembly = assembly.GetName().Name + ".dll";
                                apiService.Administrations = Administration;
                                apiService.Enabled = true;
                            }

                            GetAddApiServiceOperations(t, registerAdapters, assemblyDefinition, apiService);
                            return apiService;
                        })
                    .ToList();

            AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;

            var result = CreateAdapterDataDto(registerAdapters, apiServices, registerObjects);
            return result;
        }

        private AdapterDataDto CreateAdapterDataDto(List<RegisterAdapters> registerAdapters, List<ApiServices> apiServices, List<RegisterObjects> registerObjectsList)
        {
            var registeredAdapter = registerAdapters[0];
            var apiService = apiServices[0];

            var result = new AdapterDataDto
            {
                NotRegisterAdapterInfo = new AdapterDto
                {
                    AdapterUrl = registeredAdapter.AdapterUrl,
                    Assembly = registeredAdapter.Assembly,
                    BindingConfigName = registeredAdapter.BindingConfigName,
                    BindingType = registeredAdapter.BindingType,
                    Contract = registeredAdapter.Contract,
                    Description = registeredAdapter.Description,
                    Name = registeredAdapter.Name,
                    AdapterOperations = registeredAdapter.AdapterOperations.Select(ao => new AdapterOperationDto
                    {
                        Description = ao.Description,
                        Name = ao.Name,
                        RegisterObjectFullName = ao?.RegisterObjects?.FullName
                    }),
                    RegisterObjects = registerObjectsList.Select(ro => new RegisterObjectDto
                    {
                        Name = ro.Name,
                        FullName = ro.FullName,
                        Description = ro.Description,
                        RegisterObjectElements = ro.RegisterObjectElements.Select(oe => new RegisterObjectElementDto
                        {
                            Name = oe.Name,
                            Description = oe.Description,
                            PathToRoot = oe.PathToRoot
                        })
                    })

                },
                NotRegisterApiService = new ApiServicesDto
                {
                    Code = apiService.Code,
                    Contract = apiService.Contract,
                    Description = apiService.Description,
                    Name = apiService.Name,
                    ServiceUrl = apiService.ServiceUrl,
                    ApiServiceOperations = apiService.ApiServiceOperations.Select(aso => new ApiServiceOperationDto
                    {
                        Name = aso.Name,
                        Code = aso.Code,
                        Description = aso.Description,
                    })
                },
                NotRegisterApiServiceAdapterOperations = AddApiServiceOperations(registeredAdapter, apiService)
            };

            return result;
        }

        private IEnumerable<ApiServiceAdapterOperationDto> AddApiServiceOperations(RegisterAdapters registeredAdapter, ApiServices apiService)
        {
            var result = new List<ApiServiceAdapterOperationDto>();

            List<string> adapterOperations = new List<string>();
            List<string> apiServiceOperations = new List<string>();

            foreach (var operation in registeredAdapter.AdapterOperations)
            {
                adapterOperations.Add(registeredAdapter.Contract + "." + operation.Name);
            }

            foreach (var operation in apiService.ApiServiceOperations)
            {
                apiServiceOperations.Add(apiService.Contract + "." + operation.Name);
            }

            foreach (var fullNameOperation in adapterOperations)
            {
                var operation = fullNameOperation.Substring(fullNameOperation.LastIndexOf('.'));
                var currApiServiceOperation = apiServiceOperations.FirstOrDefault(x => x.EndsWith(operation));

                var apiServiceAdapterOperation = new ApiServiceAdapterOperationDto
                {
                    AdapterFullName = fullNameOperation,
                    ApiServiceFullName = currApiServiceOperation
                };
                result.Add(apiServiceAdapterOperation);
            }

            return result;
        }

        private string GetImplementationName(Assembly assembly, Type i)
        {
            return assembly.GetTypes().Where(t => t.GetInterfaces().Any(ti => ti == i)).First().Name;
        }

        private void GetAddApiServiceOperations(Type t, List<RegisterAdapters> registerAdapters,
            AssemblyDefinition assemblyDefinition, ApiServices apiService)
        {
            var apiServiceType =
                assemblyDefinition.MainModule.Types.Where(td =>
                    td.Interfaces.Where(tr =>
                        tr.InterfaceType.FullName == typeof(IAPIService).FullName ||
                        tr.InterfaceType.FullName == t.FullName).Count() == 2 && !td.IsInterface).SingleOrDefault();
            if (apiServiceType != null)
                foreach (var operation in apiServiceType.Methods.Where(m => !m.IsConstructor))
                {
                    DescriptionAttribute descriptionAttribute = null;
                    try
                    {
                        descriptionAttribute =
                            t.GetMethod(operation.Name).GetCustomAttributes(false).Where(a => a is DescriptionAttribute)
                                .Cast<DescriptionAttribute>().FirstOrDefault();
                    }
                    catch (NullReferenceException e)
                    {
                        continue;
                       //TODO: Find out why ! GetMetaDataXML
                    }
                    
                    var description = "";

                    if (descriptionAttribute != null) description = descriptionAttribute.Description;

                    var apiServiceOperation = apiService.ApiServiceOperations.Where(aso => aso.Name == operation.Name)
                        .FirstOrDefault();

                    if (apiServiceOperation == null)
                    {
                        apiServiceOperation = new ApiServiceOperations();
                        apiServiceOperation.Name = operation.Name;
                        apiServiceOperation.Description = description;
                        apiServiceOperation.ApiServices = apiService;
                        apiServiceOperation.Code = operation.Name;

                        apiService.ApiServiceOperations.Add(apiServiceOperation);


                        var operationCall = operation.Body.Instructions.Where(i => i.OpCode.Code == Code.Callvirt
                                                                                   && i.Operand is GenericInstanceMethod
                                                                                   && (i.Operand as
                                                                                       GenericInstanceMethod).Name ==
                                                                                   "Execute").FirstOrDefault();
                        //TODO; Refer AdapterClient
                        if (operationCall != null &&
                            operationCall.Operand is GenericInstanceMethod &&
                            (operationCall.Operand as GenericInstanceMethod).DeclaringType.Name == "IAdapterClient" &&
                            (operationCall.Operand as GenericInstanceMethod).Name == "Execute"
                        )
                        {
                            var pushStringLiteral = operation.Body.Instructions.Where(i => i.OpCode.Code == Code.Ldtoken
                                                                                           && i.Operand is
                                                                                               MethodDefinition
                            ).FirstOrDefault();
                            var stringOperand = pushStringLiteral.Operand as string;
                            //string contract = stringOperand.Substring(0, stringOperand.LastIndexOf("."));
                            //string methodName = stringOperand.Substring(stringOperand.LastIndexOf(".")+1);

                            var contract = (pushStringLiteral.Operand as MethodDefinition).DeclaringType.FullName;
                            var methodName = (pushStringLiteral.Operand as MethodDefinition).Name;

                            var registerAdapter =
                                registerAdapters.Where(ra => ra.Contract == contract).SingleOrDefault();
                            if (registerAdapter != null)
                            {
                                var adapterOperation = registerAdapter.AdapterOperations
                                    .Where(o => o.Name == methodName).SingleOrDefault();
                                if (adapterOperation != null)
                                {
                                    var apiServiceAdapterOperation = new ApiServiceAdapterOperations();
                                    apiServiceAdapterOperation.AdapterOperations = adapterOperation;
                                    apiServiceAdapterOperation.ApiServiceOperations = apiServiceOperation;
                                    apiServiceOperation.ApiServiceAdapterOperations.Add(apiServiceAdapterOperation);
                                }
                            }
                        }
                    }
                }
        }

        private List<AdapterOperations> GetAdapterOperations(Type t, List<RegisterObjects> registerObjects,
            RegisterAdapters registerAdapter)
        {
            return
                t
                    .GetMethods()
                    .Select(
                        mi =>
                        {
                            var descriptionAttribute =
                                mi.GetCustomAttributes(false).Where(a => a is DescriptionAttribute)
                                    .Cast<DescriptionAttribute>().FirstOrDefault();
                            var description = "";
                            if (descriptionAttribute != null) description = descriptionAttribute.Description;
                            var adapterOperation = registerAdapter.AdapterOperations.Where(a => a.Name == mi.Name)
                                .FirstOrDefault();
                            if (adapterOperation == null)
                            {
                                adapterOperation = new AdapterOperations();
                                adapterOperation.Name = mi.Name;
                                adapterOperation.Description = description;
                                adapterOperation.RegisterObjects = GetRegisterObject(registerObjects, mi.ReturnType);
                            }

                            return adapterOperation;
                        }
                    )
                    .ToList();
        }

        private RegisterObjects GetRegisterObject(List<RegisterObjects> registerObjects, Type registerObjectType)
        {
            var registerObject = registerObjects.Where(ro => ro.FullName == registerObjectType.FullName)
                .SingleOrDefault();
            if (registerObject == null)
            {
                //TODO: CHECK registerObjectsInDB
                registerObject = GetCreateRegisterObject(registerObjectType);
                registerObjects.Add(registerObject);
            }

            return registerObject;
        }

        private RegisterObjects GetCreateRegisterObject(Type registerObjectType)
        {
            var responseForAmType = registerObjectType;
            if (registerObjectType.IsGenericType &&
                registerObjectType.FullName.Contains(typeof(CommonSignedResponse<,>).FullName))
            {
                var typeArguments = registerObjectType.GetGenericArguments();
                var responseType = typeArguments[1];
                //за изключения с custom AccessMatrix
                var tryFindExeption = responseType.Assembly.GetType(responseType.FullName + "_AM");
                if (tryFindExeption != null)
                    responseForAmType = tryFindExeption; //return CreateRegisterObjectResponseType(tryFindExeption);
                else
                    responseForAmType = responseType; //return CreateRegisterObjectResponseType(typeArguments[1]);
            }

            return GetCreateRegisterObjectResponseType(responseForAmType);
        }

        private RegisterObjects GetCreateRegisterObjectResponseType(Type registerObjectType)
        {
            var description = "";
            var descAttribute =
                registerObjectType.GetCustomAttributes(typeof(DescriptionAttribute), false).Cast<DescriptionAttribute>()
                    .FirstOrDefault();
            if (descAttribute != null) description = descAttribute.Description;

            var registerObject = new RegisterObjects();
            registerObject.Name = registerObjectType.Name;
            registerObject.FullName = registerObjectType.FullName;
            registerObject.Description = description;
            GetAddRegisterObjectElement(registerObjectType.GetProperties(), "", registerObject);
            return registerObject;
        }

        private void GetAddRegisterObjectElement(PropertyInfo[] properties, string path, RegisterObjects registerObject)
        {
            foreach (var propertyInfo in properties)
                if (!propertyInfo.Name.EndsWith("Specified"))
                {
                    var currentPath = string.IsNullOrEmpty(path)
                        ? propertyInfo.Name
                        : string.Format("{0}.{1}", path, propertyInfo.Name);
                    var description = "";
                    var descAttribute = propertyInfo.GetCustomAttributes(typeof(DescriptionAttribute), false)
                        .Cast<DescriptionAttribute>().FirstOrDefault();
                    if (descAttribute != null) description = descAttribute.Description;

                    var objectElement = new Models.RegisterObjectElements();
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
                        var childType = propertyInfo.PropertyType;
                        if (propertyInfo.PropertyType.IsGenericType)
                            childType = childType.GetGenericArguments()[0];
                        else if (propertyInfo.PropertyType.IsArray) childType = childType.GetElementType();
                        GetAddRegisterObjectElement(childType.GetProperties(), currentPath, registerObject);
                    }
                }
        }

        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var assemblyName = args.Name.Substring(0, args.Name.IndexOf(",")) + ".dll";
            return Assembly.LoadFrom(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, assemblyName));
        }
    }
}