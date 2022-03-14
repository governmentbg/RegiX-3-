using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace TechnoLogica.RegiX.Common.Metadata.AdapterOperations
{
    public interface IParameter
    {
        ParameterInfo ParameterInfo { get; }
        IEnumerable<IParameter> ChildIParamteters { get;  }
    }

    [GeneratedCode("Xsd2Code", "3.4.0.30000")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://egov.bg/RegiX/RegiXClientMetadata")]
    [XmlRootAttribute(Namespace = "http://egov.bg/RegiX/RegiXClientMetadata", IsNullable = true)]
    public class Parameter : IParameter
    {
        private List<ParameterParameter> childParamtetersField;

        private ParameterInfo parameterInfoField;

        /// <summary>
        ///     Parameter class constructor
        /// </summary>
        public Parameter()
        {
            childParamtetersField = new List<ParameterParameter>();
            parameterInfoField = new ParameterInfo();
        }

        [XmlElementAttribute(Order = 0)]
        public ParameterInfo ParameterInfo
        {
            get => parameterInfoField;
            set => parameterInfoField = value;
        }

        [XmlArrayAttribute(Order = 1)]
        [XmlArrayItemAttribute("Parameter", IsNullable = false)]
        public List<ParameterParameter> ChildParamteters
        {
            get => childParamtetersField;
            set => childParamtetersField = value;
        }

        [XmlIgnore]
        public IEnumerable<IParameter> ChildIParamteters { get => this.ChildParamteters; }

    }

    [GeneratedCode("Xsd2Code", "3.4.0.30000")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://egov.bg/RegiX/RegiXClientMetadata")]
    public class ParameterParameter : IParameter
    {
        private List<ParameterParameterParameter> childParamtetersField;

        private ParameterInfo parameterInfoField;

        /// <summary>
        ///     ParameterParameter class constructor
        /// </summary>
        public ParameterParameter()
        {
            childParamtetersField = new List<ParameterParameterParameter>();
            parameterInfoField = new ParameterInfo();
        }

        [XmlElementAttribute(Order = 0)]
        public ParameterInfo ParameterInfo
        {
            get => parameterInfoField;
            set => parameterInfoField = value;
        }

        [XmlArrayAttribute(Order = 1)]
        [XmlArrayItemAttribute("Parameter", IsNullable = false)]
        public List<ParameterParameterParameter> ChildParamteters
        {
            get => childParamtetersField;
            set => childParamtetersField = value;
        }

        [XmlIgnore]
        public IEnumerable<IParameter> ChildIParamteters { get => this.ChildParamteters; }
    }

    [GeneratedCode("Xsd2Code", "3.4.0.30000")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://egov.bg/RegiX/RegiXClientMetadata")]
    public class ParameterParameterParameter : IParameter
    {
        private List<ParameterParameterParameterParameter> childParamtetersField;

        private ParameterInfo parameterInfoField;

        /// <summary>
        ///     ParameterParameterParameter class constructor
        /// </summary>
        public ParameterParameterParameter()
        {
            childParamtetersField = new List<ParameterParameterParameterParameter>();
            parameterInfoField = new ParameterInfo();
        }

        [XmlElementAttribute(Order = 0)]
        public ParameterInfo ParameterInfo
        {
            get => parameterInfoField;
            set => parameterInfoField = value;
        }

        [XmlArrayAttribute(Order = 1)]
        [XmlArrayItemAttribute("Parameter", IsNullable = false)]
        public List<ParameterParameterParameterParameter> ChildParamteters
        {
            get => childParamtetersField;
            set => childParamtetersField = value;
        }

        [XmlIgnore]
        public IEnumerable<IParameter> ChildIParamteters { get => this.ChildParamteters; }
    }

    [GeneratedCode("Xsd2Code", "3.4.0.30000")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://egov.bg/RegiX/RegiXClientMetadata")]
    public class ParameterParameterParameterParameter : IParameter
    {
        private List<ParameterParameterParameterParameterParameter> childParamtetersField;

        private ParameterInfo parameterInfoField;

        /// <summary>
        ///     ParameterParameterParameterParameter class constructor
        /// </summary>
        public ParameterParameterParameterParameter()
        {
            childParamtetersField = new List<ParameterParameterParameterParameterParameter>();
            parameterInfoField = new ParameterInfo();
        }

        [XmlElementAttribute(Order = 0)]
        public ParameterInfo ParameterInfo
        {
            get => parameterInfoField;
            set => parameterInfoField = value;
        }

        [XmlArrayAttribute(Order = 1)]
        [XmlArrayItemAttribute("Parameter", IsNullable = false)]
        public List<ParameterParameterParameterParameterParameter> ChildParamteters
        {
            get => childParamtetersField;
            set => childParamtetersField = value;
        }

        [XmlIgnore]
        public IEnumerable<IParameter> ChildIParamteters { get => this.ChildParamteters; }
    }

    [GeneratedCode("Xsd2Code", "3.4.0.30000")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://egov.bg/RegiX/RegiXClientMetadata")]
    public class ParameterParameterParameterParameterParameter : IParameter
    {
        private List<ParameterParameterParameterParameterParameterParameter> childParamtetersField;

        private ParameterInfo parameterInfoField;

        /// <summary>
        ///     ParameterParameterParameterParameterParameter class constructor
        /// </summary>
        public ParameterParameterParameterParameterParameter()
        {
            childParamtetersField = new List<ParameterParameterParameterParameterParameterParameter>();
            parameterInfoField = new ParameterInfo();
        }

        [XmlElementAttribute(Order = 0)]
        public ParameterInfo ParameterInfo
        {
            get => parameterInfoField;
            set => parameterInfoField = value;
        }

        [XmlArrayAttribute(Order = 1)]
        [XmlArrayItemAttribute("Parameter", IsNullable = false)]
        public List<ParameterParameterParameterParameterParameterParameter> ChildParamteters
        {
            get => childParamtetersField;
            set => childParamtetersField = value;
        }

        [XmlIgnore]
        public IEnumerable<IParameter> ChildIParamteters { get => this.ChildParamteters; }
    }

    [GeneratedCode("Xsd2Code", "3.4.0.30000")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://egov.bg/RegiX/RegiXClientMetadata")]
    public class ParameterParameterParameterParameterParameterParameter : IParameter
    {
        private List<ParameterParameterParameterParameterParameterParameterParameter> childParamtetersField;

        private ParameterInfo parameterInfoField;

        /// <summary>
        ///     ParameterParameterParameterParameterParameterParameter class constructor
        /// </summary>
        public ParameterParameterParameterParameterParameterParameter()
        {
            childParamtetersField = new List<ParameterParameterParameterParameterParameterParameterParameter>();
            parameterInfoField = new ParameterInfo();
        }

        [XmlElementAttribute(Order = 0)]
        public ParameterInfo ParameterInfo
        {
            get => parameterInfoField;
            set => parameterInfoField = value;
        }

        [XmlArrayAttribute(Order = 1)]
        [XmlArrayItemAttribute("Parameter", IsNullable = false)]
        public List<ParameterParameterParameterParameterParameterParameterParameter> ChildParamteters
        {
            get => childParamtetersField;
            set => childParamtetersField = value;
        }

        [XmlIgnore]
        public IEnumerable<IParameter> ChildIParamteters { get => this.ChildParamteters; }
    }

    [GeneratedCode("Xsd2Code", "3.4.0.30000")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://egov.bg/RegiX/RegiXClientMetadata")]
    public class ParameterParameterParameterParameterParameterParameterParameter : IParameter
    {
        private List<ParameterParameterParameterParameterParameterParameterParameterParameter> childParamtetersField;

        private ParameterInfo parameterInfoField;

        /// <summary>
        ///     ParameterParameterParameterParameterParameterParameterParameter class constructor
        /// </summary>
        public ParameterParameterParameterParameterParameterParameterParameter()
        {
            childParamtetersField =
                new List<ParameterParameterParameterParameterParameterParameterParameterParameter>();
            parameterInfoField = new ParameterInfo();
        }

        [XmlElementAttribute(Order = 0)]
        public ParameterInfo ParameterInfo
        {
            get => parameterInfoField;
            set => parameterInfoField = value;
        }

        [XmlArrayAttribute(Order = 1)]
        [XmlArrayItemAttribute("Parameter", IsNullable = false)]
        public List<ParameterParameterParameterParameterParameterParameterParameterParameter> ChildParamteters
        {
            get => childParamtetersField;
            set => childParamtetersField = value;
        }

        [XmlIgnore]
        public IEnumerable<IParameter> ChildIParamteters { get => this.ChildParamteters; }
    }

    [GeneratedCode("Xsd2Code", "3.4.0.30000")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://egov.bg/RegiX/RegiXClientMetadata")]
    public class ParameterParameterParameterParameterParameterParameterParameterParameter : IParameter
    {
        private List<ParameterParameterParameterParameterParameterParameterParameterParameterParameter>
            childParamtetersField;

        private ParameterInfo parameterInfoField;

        /// <summary>
        ///     ParameterParameterParameterParameterParameterParameterParameterParameter class constructor
        /// </summary>
        public ParameterParameterParameterParameterParameterParameterParameterParameter()
        {
            childParamtetersField =
                new List<ParameterParameterParameterParameterParameterParameterParameterParameterParameter>();
            parameterInfoField = new ParameterInfo();
        }

        [XmlElementAttribute(Order = 0)]
        public ParameterInfo ParameterInfo
        {
            get => parameterInfoField;
            set => parameterInfoField = value;
        }

        [XmlArrayAttribute(Order = 1)]
        [XmlArrayItemAttribute("Parameter", IsNullable = false)]
        public List<ParameterParameterParameterParameterParameterParameterParameterParameterParameter> ChildParamteters
        {
            get => childParamtetersField;
            set => childParamtetersField = value;
        }

        [XmlIgnore]
        public IEnumerable<IParameter> ChildIParamteters { get => this.ChildParamteters; }
    }

    [GeneratedCode("Xsd2Code", "3.4.0.30000")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://egov.bg/RegiX/RegiXClientMetadata")]
    public class ParameterParameterParameterParameterParameterParameterParameterParameterParameter : IParameter
    {
        private object childParamtetersField;

        private ParameterInfo parameterInfoField;

        /// <summary>
        ///     ParameterParameterParameterParameterParameterParameterParameterParameterParameter class constructor
        /// </summary>
        public ParameterParameterParameterParameterParameterParameterParameterParameterParameter()
        {
            parameterInfoField = new ParameterInfo();
        }

        [XmlElementAttribute(Order = 0)]
        public ParameterInfo ParameterInfo
        {
            get => parameterInfoField;
            set => parameterInfoField = value;
        }

        [XmlElementAttribute(Order = 1)]
        public object ChildParamteters
        {
            get => childParamtetersField;
            set => childParamtetersField = value;
        }

        [XmlIgnore]
        public IEnumerable<IParameter> ChildIParamteters { get => this.ChildParamteters as IEnumerable<IParameter>; }
    }
}