using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Description;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Technologica.WcfCustom
{
    public class XmlSchemaAnnotations
    {
        /// <summary>
        /// Намира се XmlSchemaExporter-a и му се дописват Annotation-и и MinOccurs, в зависимост от Nillable характеристиката
        /// </summary>
        /// <param name="exporter"></param>
        /// <param name="context"></param>
        public static void Export(WsdlExporter exporter, WsdlEndpointConversionContext context)
        {
            Type schemaExporterType = Type.GetType("System.Xml.Serialization.XmlSchemaExporter, System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
            object schemaExp = null;
            if (exporter.State.TryGetValue(schemaExporterType, out schemaExp))
            {
                XmlSchemas schemas = (XmlSchemas)schemaExp.GetType().GetField("schemas", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(schemaExp);

                foreach (XmlSchema schema in schemas)
                {
                    OverrideElementsAnnotationAndNullableRecursive(schema.Elements.Values.OfType<XmlSchemaElement>(), String.Empty);//, allElements, allComplexTypes);
                }
            }
        }

        /// <summary>
        /// Рекурсивно обхожда списъка с елементи и им добавя Annotation, който се извлича от xml-a на съответния клас/пропърти. Търсенето е по име
        /// Освен това оправя и MinOccurs, в зависимост от стойността на IsNillable
        /// </summary>
        /// <param name="inElements">Списък с елементи за които да се извърши операцията</param>
        /// <param name="ComplexTypeName">Име на комплексния тип, от който са елементите. Възможно е и да е празен/null</param>
        public static void OverrideElementsAnnotationAndNullableRecursive(IEnumerable<XmlSchemaElement> inElements, string ComplexTypeName)//, List<XmlSchemaElement> resultElements, List<XmlSchemaComplexType> resutlTypes)
        {
            //проверка за празен списък(това би било дъното на рекурсията)
            if (inElements != null && inElements.Count() > 0)
            {
                foreach (XmlSchemaElement el in inElements)
                {
                    //Ако е конфигуриран елемента да не е Nillable, тогава му слагаме MinOccurs = 1
                    if (!el.IsNillable)
                    {
                        if (el.MinOccurs != 1)
                        {
                            el.MinOccurs = 1;
                        }
                    }
                    //Aко елемента е Nillabe, тогава му слагаме MinOccurs = 0
                    else
                    {
                        if (el.MinOccurs != 0)
                        {
                            el.MinOccurs = 0;
                        }
                    }

                    //Добавяме анотация на документа, ако открием в xml-документацията на асемблито такава
                    el.Annotation = CreateAnnotation(XmlDocumentation.LoadStartsWith(el, ComplexTypeName));
                   
                    //Ако елемента е от комплексен тип, то добавяме анотация и на комплексния тип
                    if (el.ElementSchemaType is XmlSchemaComplexType)
                    {
                        XmlSchemaComplexType type = (XmlSchemaComplexType)el.ElementSchemaType;
                        type.Annotation = CreateAnnotation(XmlDocumentation.LoadStartsWith(el, null));
                        
                        if (type.ContentTypeParticle is XmlSchemaSequence)
                        {
                            //За елементите на комплексния тип извикваме рекурсивно, като подаваме името му
                            OverrideElementsAnnotationAndNullableRecursive((type.ContentTypeParticle as System.Xml.Schema.XmlSchemaSequence).Items.OfType<XmlSchemaElement>(), type.QualifiedName.Name);
                        }                        
                    }
                }
            }
        }

        /// <summary>
        /// Създава обект за антотация от XElement, получен от обхождането на xml-документацията на реферираното асембли
        /// </summary>
        /// <param name="element">Елемент, намерен в xml-документацията на assembly</param>
        /// <returns>Обект, за анотация на XmlSchemaElement</returns>
        public static XmlSchemaAnnotation CreateAnnotation(XElement element)
        {
            if (element != null)
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(element.ToString());
                XmlSchemaAnnotation annotation = new XmlSchemaAnnotation();
                XmlSchemaDocumentation documentation = new XmlSchemaDocumentation();
                documentation.Markup = doc.DocumentElement.ChildNodes.Cast<XmlNode>().ToArray();
                annotation.Items.Add(documentation);
                return annotation;
            }
            else
            {
                return null;
            }
        }
    }
}