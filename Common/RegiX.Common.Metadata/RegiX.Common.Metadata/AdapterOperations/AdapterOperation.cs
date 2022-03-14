using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace TechnoLogica.RegiX.Common.Metadata.AdapterOperations
{
    [GeneratedCode("Xsd2Code", "3.4.0.30000")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://egov.bg/RegiX/RegiXClientMetadata")]
    [XmlRootAttribute(Namespace = "http://egov.bg/RegiX/RegiXClientMetadata", IsNullable = true)]
    public class AdapterOperation
    {
        private string codeField;

        private string controllerNameField;

        private string displayOperationNameField;

        private bool isActiveField;

        private bool isActiveFieldSpecified;

        private string namespaceField;

        private string operationNameField;

        private List<Parameter> parametersField;

        private string requestObjectNameField;

        private string requestXSLTField;

        private string resourceField;

        private string responseXSLTField;

        private string urlField;

        /// <summary>
        ///     AdapterOperation class constructor
        /// </summary>
        public AdapterOperation()
        {
            parametersField = new List<Parameter>();
        }

        [XmlElementAttribute(Order = 0)]
        public string OperationName
        {
            get => operationNameField;
            set => operationNameField = value;
        }

        [XmlElementAttribute(Order = 1)]
        public string Code
        {
            get => codeField;
            set => codeField = value;
        }

        [XmlElementAttribute(Order = 2)]
        public string ControllerName
        {
            get => controllerNameField;
            set => controllerNameField = value;
        }

        [XmlElementAttribute(Order = 3)]
        public string Resource
        {
            get => resourceField;
            set => resourceField = value;
        }

        [XmlElementAttribute(Order = 4)]
        public string RequestObjectName
        {
            get => requestObjectNameField;
            set => requestObjectNameField = value;
        }

        [XmlElementAttribute(Order = 5)]
        public string Namespace
        {
            get => namespaceField;
            set => namespaceField = value;
        }

        [XmlElementAttribute(Order = 6)]
        public string URL
        {
            get => urlField;
            set => urlField = value;
        }

        [XmlElementAttribute(Order = 7)]
        public string ResponseXSLT
        {
            get => responseXSLTField;
            set => responseXSLTField = value;
        }

        [XmlElementAttribute(Order = 8)]
        public string RequestXSLT
        {
            get => requestXSLTField;
            set => requestXSLTField = value;
        }

        [XmlElementAttribute(Order = 9)]
        public bool IsActive
        {
            get => isActiveField;
            set => isActiveField = value;
        }

        [XmlIgnoreAttribute]
        public bool IsActiveSpecified
        {
            get => isActiveFieldSpecified;
            set => isActiveFieldSpecified = value;
        }

        [XmlElementAttribute(Order = 10)]
        public string DisplayOperationName
        {
            get => displayOperationNameField;
            set => displayOperationNameField = value;
        }

        [XmlArrayAttribute(Order = 11)]
        [XmlArrayItemAttribute(IsNullable = false)]
        public List<Parameter> Parameters
        {
            get => parametersField;
            set => parametersField = value;
        }
    }
}