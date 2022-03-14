using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TechnoLogica.RegiX.Common.Metadata.AdapterOperations;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common.Utils;
using static TechnoLogica.RegiX.Client.API.RegiXCoreClient;
using System.Diagnostics;

namespace TechnoLogica.RegiX.Client.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/enum-from-operation")] //required for default versioning
    [Route("api/v{version:apiVersion}/enum-from-operation")]
    [Authorize]
    public class EnumFromOperationController : ControllerBase
    {
        private readonly IDistributedCache distributedCache;
        RegiXClientSettings RegiXClientSettings { get; set; }

        public EnumFromOperationController(
            RegiXClientSettings regiXClientSettings, IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache;
            RegiXClientSettings = regiXClientSettings;
        }

        [HttpGet("getRegistryAgencies")]
        [AllowAnonymous]
        public async Task<IActionResult> GetRegistryAgencies(bool hasEmptyValue)
        {
            var result = new List<EnumValue>();
            try
            {
                string operation = "TechnoLogica.RegiX.PropertyRegAdapter.APIService.IPropertyRegAPI.GetSites";
                GetSitesResponseType agencies = null;
                var agenciesTask = RetrieveValues<GetSitesResponseType>(operation);
                agenciesTask.Wait();
                agencies = agenciesTask.Result;

                var registryAgenciesList = new List<EnumValue>();

                if (agencies != null && agencies.site != null)
                {
                    foreach (var ag in agencies.site)
                    {
                        registryAgenciesList.Add(new EnumValue()
                        {
                            DisplayText = ag.siteName,
                            Value = ag.siteID?.Trim()
                        });
                    }
                }

                registryAgenciesList = registryAgenciesList.OrderBy(x => x.DisplayText).ToList();

                if (registryAgenciesList.Count > 0)
                {
                    WriteResultToFile(
                        nameof(EnumFromOperationController.GetRegistryAgencies), registryAgenciesList.XmlSerialize());
                    result = registryAgenciesList;
                }
                else
                {
                    result = FetchFromFile(nameof(EnumFromOperationController.GetRegistryAgencies));
                }

            }
            catch(Exception ex)
            {
                result = FetchFromFile(nameof(EnumFromOperationController.GetRegistryAgencies));
            }

            if (hasEmptyValue)
            {
                result.Insert(0, (new EnumValue()
                {
                    DisplayText = "Всички служби по вписванията",
                    Value = ""
                }));
            }

            return Ok(result);
        }

        private List<EnumValue> FetchFromFile(string fileName)
        {
            string fileFullName = fileName + ".xml";
            if (System.IO.File.Exists(WorkingDir.FullName +Path.DirectorySeparatorChar +  fileFullName))
            {
                var result = System.IO.File.ReadAllText(WorkingDir.FullName + fileFullName);
                return result.XmlDeserialize<List<EnumValue>>();
            }

            return null;
        }

        private static DirectoryInfo _workingDir;
        private static DirectoryInfo WorkingDir
        {
            get
            {
                if (_workingDir == null)
                {
                    _workingDir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                }
                return _workingDir;
            }
        }

        private bool WriteResultToFile(string fileName, string xml)
        {
            string fileFullName = fileName + ".xml";
            string fullPath = WorkingDir.FullName + Path.DirectorySeparatorChar +  fileFullName;

            try
            {
                System.IO.File.WriteAllText(fullPath, xml);
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                try
                {
                    RemoveReadOnly(fullPath);
                    System.IO.File.WriteAllText(fullPath, xml);
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        private void RemoveReadOnly(string path)
        {
            FileAttributes attributes = System.IO.File.GetAttributes(path);

            if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            {
                // Make the file RW
                attributes = RemoveAttribute(attributes, FileAttributes.ReadOnly);
                System.IO.File.SetAttributes(path, attributes);
            }
        }

        private FileAttributes RemoveAttribute(FileAttributes attributes, FileAttributes attributesToRemove)
        {
            return attributes & ~attributesToRemove;
        }


        private async Task<T> RetrieveValues<T>(string operation)
            where T : class
        {
            using (var client = new RegiXCoreClient(EndpointConfiguration.BasicHttpBindingSecurityClientCertificate))
            {
                client.ClientCredentials.ClientCertificate.SetCertificate(
                    StoreLocation.LocalMachine,
                    StoreName.My,
                    X509FindType.FindByThumbprint,
                    RegiXClientSettings.SystemCallContext.CertificateThumbprint);

                var result = await
                    client.ExecuteAsync(
                        new Core.Interfaces.TransportObjects.RequestWrapper()
                        {
                            Request = new ServiceRequestData()
                            {
                                Argument = new GetSitesRequestType().XmlSerialize().ToXmlElement(),
                                Operation = operation,
                                CallbackURL = RegiXClientSettings.RegiXClientCallbackURL,
                                CallContext = new Common.DataContracts.CallContext()
                                {
                                    ServiceURI = RegiXClientSettings.SystemCallContext.ServiceURI,
                                    ServiceType = RegiXClientSettings.SystemCallContext.ServiceType,
                                    EmployeeIdentifier = RegiXClientSettings.SystemCallContext.EmployeeIdentifier,
                                    EmployeeNames = RegiXClientSettings.SystemCallContext.EmployeeNames,
                                    EmployeeAditionalIdentifier = RegiXClientSettings.SystemCallContext.EmployeeAditionalIdentifier,
                                    EmployeePosition = RegiXClientSettings.SystemCallContext.EmployeePosition,
                                    AdministrationOId = RegiXClientSettings.SystemCallContext.AdministrationOId,
                                    AdministrationName = RegiXClientSettings.SystemCallContext.AdministrationName,
                                    ResponsiblePersonIdentifier = RegiXClientSettings.SystemCallContext.ResponsiblePersonIdentifier,
                                    LawReason = RegiXClientSettings.SystemCallContext.LawReason,
                                    Remark = RegiXClientSettings.SystemCallContext.Remark
                                },
                                ReturnAccessMatrix = RegiXClientSettings.SystemCallContext.ReturnAccessMatrix,
                                SignResult = RegiXClientSettings.SystemCallContext.SignResult
                            }
                        });
                if (!result.Result.HasError)
                {
                    var t = result.Result.Data.Response.Response;
                    return result.Result.Data.Response.Response.Deserialize<T>();
                }
                else
                {
                    return null;
                }
            }
        }
    }

    public class EnumWrapper
    {
        public string Name { get; set; }

        public List<EnumValue> EnumValues { get; set; }
    }


    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18034")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://egov.bg/RegiX/AV/PropertyReg/GetSitesRequest")]
    [System.Xml.Serialization.XmlRootAttribute("GetSitesRequest", Namespace = "http://egov.bg/RegiX/AV/PropertyReg/GetSitesRequest", IsNullable = false)]
    public partial class GetSitesRequestType
    {

        private string dummyField;

        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string dummy
        {
            get
            {
                return this.dummyField;
            }
            set
            {
                this.dummyField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.26800")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://egov.bg/RegiX/AV/PropertyReg/GetSitesResponse")]
    [System.Xml.Serialization.XmlRootAttribute("GetSitesResponse", Namespace = "http://egov.bg/RegiX/AV/PropertyReg/GetSitesResponse", IsNullable = false)]
    public partial class GetSitesResponseType
    {

        private List<site> siteField;

        /// <summary>
        /// GetSitesResponseType class constructor
        /// </summary>
        public GetSitesResponseType()
        {
            this.siteField = new List<site>();
        }

        [System.Xml.Serialization.XmlElementAttribute("site", Order = 0)]
        public List<site> site
        {
            get
            {
                return this.siteField;
            }
            set
            {
                this.siteField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.26800")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://egov.bg/RegiX/AV/PropertyReg/GetSitesResponse")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://egov.bg/RegiX/AV/PropertyReg/GetSitesResponse", IsNullable = true)]
    public partial class site
    {

        private string siteIDField;

        private string siteNameField;

        private System.DateTime siteStartDateField;

        private bool siteStartDateFieldSpecified;

        /// <summary>
        /// Идентификатор на служба по вписвания
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Идентификатор на служба по вписвания")]
        public string siteID
        {
            get
            {
                return this.siteIDField;
            }
            set
            {
                this.siteIDField = value;
            }
        }

        /// <summary>
        /// Служба по вписвания
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Служба по вписвания")]
        public string siteName
        {
            get
            {
                return this.siteNameField;
            }
            set
            {
                this.siteNameField = value;
            }
        }

        /// <summary>
        /// Най-ранна дата, за която има данни в електронния регистър
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Най-ранна дата, за която има данни в електронния регистър")]
        public System.DateTime siteStartDate
        {
            get
            {
                return this.siteStartDateField;
            }
            set
            {
                this.siteStartDateField = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool siteStartDateSpecified
        {
            get
            {
                return this.siteStartDateFieldSpecified;
            }
            set
            {
                this.siteStartDateFieldSpecified = value;
            }
        }
    }

    public static class ObjectExtensions
    {

        public static T XmlDeserialize<T>(this string serializedObject)
            where T : class
        {
            return XmlDeserialize(serializedObject, typeof(T)) as T;
        }

        /// <summary>
        /// Deserializes the provided string to the desired object
        /// </summary>
        /// <param name="serializedObject">Serialized object</param>
        /// <param name="type">Type of the serialized object</param>
        /// <returns>Deserialzed object</returns>
        public static object XmlDeserialize(this string serializedObject, Type type)
        {
            if (string.IsNullOrEmpty(serializedObject))
            {
                return null;
            }
            using (StringReader sr = new StringReader(serializedObject))
            {
                XmlSerializer serializer = new XmlSerializer(type);
                return serializer.Deserialize(sr);
            }
        }

        /// <summary>
        /// Serializes an object to XML and returns string
        /// </summary>
        /// <param name="obj">The object that contains the data to be serialized</param>
        /// <returns>The serialized object</returns>
        public static string XmlSerialize(this Object obj)
        {
            if (obj != null)
            {
                using (MemoryStream ms = new MemoryStream())
                using (StreamReader sr = new StreamReader(ms))
                {
                    XmlSerializer serializer = new XmlSerializer(obj.GetType());
                    serializer.Serialize(ms, obj);
                    ms.Seek(0, SeekOrigin.Begin);
                    return sr.ReadToEnd();
                }
            }
            else
            {
                return string.Empty;
            }
        }
    }
}