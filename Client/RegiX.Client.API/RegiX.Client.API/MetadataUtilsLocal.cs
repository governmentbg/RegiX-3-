using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using TechnoLogica.RegiX.Client.Repositories;
using TechnoLogica.RegiX.Common.Metadata.AdapterOperations;
using TechnoLogica.RegiX.Common.Utils;

namespace TechnoLogica.RegiX.Client.API
{
    public class MetadataUtilsLocal
    {
        public static XmlElement CreateXML(IUserContext userContext, JObject jsonObject, AdapterOperation operationMetadata)
        {
            XmlDocument doc = new XmlDocument();
            var rootElement = doc.CreateElement(operationMetadata.RequestObjectName, operationMetadata.Namespace);

            doc.AppendChild(rootElement);
            AppendChildren(userContext, rootElement, operationMetadata.Parameters, jsonObject);

            return doc.DocumentElement;
        }

        public static XmlElement CreateXML(IUserContext userContext, JObject jsonObject, string operationMetadata)
        {
            var operationMetadataObejct = operationMetadata.XmlDeserialize<AdapterOperation>();
            return CreateXML(userContext, jsonObject, operationMetadataObejct);
        }

        private static void AppendChildren(IUserContext userContext, XmlElement parentElement, IEnumerable<IParameter> parametersMeta, JToken data, bool isArrayElement = false)
        {
            var orderedMetaParams = parametersMeta.OrderBy(x => x.ParameterInfo.OrderNumber);

            foreach (var metaParam in orderedMetaParams)
            {
                bool isXmlElement = metaParam.ParameterInfo.IsXmlElement;

                if (isXmlElement)
                {
                    string elementName = metaParam.ParameterInfo.ParameterName;
                    var docElement = parentElement.OwnerDocument.CreateElement(elementName, metaParam.ParameterInfo.Namespace ?? parentElement.NamespaceURI);

                    if (metaParam.ChildIParamteters.Any())
                    {
                        if (metaParam.ParameterInfo.ParameterType.Type == "Array")
                        { 
                            var arrayValues = data?.Value<JToken>(elementName).Children();
                            parentElement.AppendChild(docElement);
                            foreach (var element in arrayValues)
                            {
                                AppendChildren(userContext, docElement, metaParam.ChildIParamteters, element, true);
                            }
                        }
                        else
                        {
                            // the document element is added if there are child parameters
                            parentElement.AppendChild(docElement);
                            AppendChildren(
                                userContext, 
                                docElement, 
                                metaParam.ChildIParamteters,
                                (isArrayElement) ? data?.First : data?.Value<JToken>(elementName)
                            );
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(data?.Value<string>(elementName)))
                        {
                            // the document element is added if the element has value
                            parentElement.AppendChild(docElement);
                            string type = metaParam.ParameterInfo.ParameterType.Type;

                            switch (type)
                            {
                                case "bool":
                                    {
                                        docElement.InnerText = data?.Value<bool>(elementName).ToString();
                                        break;
                                    }
                                case "string":
                                    {
                                        docElement.InnerText = data?.Value<string>(elementName);
                                        break;
                                    }
                                case "int":
                                    {
                                        docElement.InnerText = data?.Value<int>(elementName).ToString();
                                        break;
                                    }
                                case "Date":
                                    {
                                        var date = data?.Value<DateTime>(elementName);
                                        docElement.InnerText = date.HasValue ? date.Value.ToLocalTime().ToString("yyyy-MM-dd") : null;
                                        break;
                                    }
                                case "DateTime":
                                    {
                                        var date = data?.Value<DateTime>(elementName);
                                        docElement.InnerText = date.HasValue ? date.Value.ToLocalTime().ToString("yyyy-MM-dd'T'HH:mm:sszzz") : null;
                                        break;
                                    }
                                case "decimal":
                                    {
                                        docElement.InnerText = data?.Value<decimal>(elementName).ToString();
                                        break;
                                    }
                                case "File":
                                    {
                                        // data should be base64
                                        docElement.InnerText = data?.Value<string>(elementName).ToString();
                                        break;
                                    }
                                default:
                                    {
                                        docElement.InnerText = data?.Value<string>(elementName).ToString();
                                        break;
                                    }
                            }
                        }                        
                        // TODO: Refactor this...
                        if (userContext.IsPublic && metaParam.ParameterInfo.IdentifierTypeSpecified)
                        {
                            if (string.IsNullOrEmpty(data?.Value<string>(elementName)))
                            {
                                // the document element is added if the element has no value (it has no provided 
                                // value but it is identitifer and the user is public so the value should be provided)
                                parentElement.AppendChild(docElement);
                            }
                            docElement.InnerText = string.Empty;
                            switch (metaParam.ParameterInfo.IdentifierType)
                            {
                                case 1: // EGN
                                {
                                    if (userContext.PublicUserIdentifierType == "EGN") {
                                        docElement.InnerText = userContext.PublicUserIdentifier;
                                    }                                    
                                    break;
                                }
                                case 2: // LNCH
                                    {
                                        if (userContext.PublicUserIdentifierType == "LNCH")
                                        {
                                            docElement.InnerText = userContext.PublicUserIdentifier;
                                        }
                                        break;
                                    }
                                case 3: // EGN_LNCH
                                {
                                        docElement.InnerText = userContext.PublicUserIdentifier;
                                        break;
                                }
                                case 5: // EGN_EIK
                                {
                                    if (userContext.PublicUserIdentifierType == "EGN")
                                    {
                                        docElement.InnerText = userContext.PublicUserIdentifier;
                                    }
                                    break;
                                }
                                case 7: // ALL
                                {
                                    byte? idType = userContext.PublicUserIdentifierType == "EGN" ? 1 /*EGN*/ : userContext.PublicUserIdentifierType == "LNCH" ? 2 /*LNCH*/ : (byte?)null;
                                    var enumValues =
                                        metaParam.ParameterInfo.ParameterType.EnumValues
                                        .Where(ev => ev.IdentifierType == idType)
                                        .ToList();
                                    if (enumValues.Count() == 1)
                                    {
                                        docElement.InnerText = enumValues[0].Value;
                                    }
                                    if (metaParam.ParameterInfo.ParameterType.Type?.ToLower() == "string")
                                    {
                                        docElement.InnerText = userContext.PublicUserIdentifier;
                                    }
                                    break;
                                }
                            }

                        }
                    }
                }
            }
        }
    }
}
