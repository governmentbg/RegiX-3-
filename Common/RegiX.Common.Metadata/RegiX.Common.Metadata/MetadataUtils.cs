using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using TechnoLogica.RegiX.Common.Metadata.AdapterOperations;
using TechnoLogica.RegiX.Common.Utils;

namespace TechnoLogica.RegiX.Common.Metadata
{
    public class MetadataUtils
    {
        public static XmlElement CreateXML(JObject jsonObject, AdapterOperation operationMetadata, IUserContext userContext = null)
        {
            XmlDocument doc = new XmlDocument();
            var rootElement = doc.CreateElement(operationMetadata.RequestObjectName, operationMetadata.Namespace);

            doc.AppendChild(rootElement);
            AppendChildren(rootElement, operationMetadata.Parameters, jsonObject, userContext);

            return doc.DocumentElement;
        }

        public static XmlElement CreateXML(JObject jsonObject, string operationMetadata, IUserContext userContext = null)
        {
            var operationMetadataObejct = operationMetadata.XmlDeserialize<AdapterOperation>();
            return CreateXML(jsonObject, operationMetadataObejct, userContext);
        }

        private static void AppendChildren(XmlElement parentElement, IEnumerable<IParameter> parametersMeta, JToken data, IUserContext userContext, bool isArrayElement = false)
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
                                AppendChildren(docElement, metaParam.ChildIParamteters, element, userContext, true);
                            }
                        }
                        else
                        {
                            // the document element is added if there are child parameters
                            parentElement.AppendChild(docElement);
                            AppendChildren(                                
                                docElement,
                                metaParam.ChildIParamteters,
                                (isArrayElement) ? data?.First : data?.Value<JToken>(elementName),
                                userContext
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
                                        var date = data?.Value<DateTime>(elementName).ToString("yyyy-MM-dd");
                                        docElement.InnerText = date;
                                        break;
                                    }
                                case "DateTime":
                                    {
                                        var date = data?.Value<DateTime>(elementName).ToString("yyyy-MM-dd'T'HH:mm:ssZ");
                                        docElement.InnerText = date;
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
                        if (userContext!= null && 
                            userContext.IsPublic && 
                            metaParam.ParameterInfo.IdentifierTypeSpecified
                            )
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
                                        if (userContext.PublicUserIdentifierType == "EGN")
                                        {
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