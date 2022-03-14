#region Namespaces
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.ServiceModel;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Linq;
using System.Linq;
using System.ServiceModel.Description;
using System.Runtime.Serialization;
using System.Xml.Serialization;
#endregion

namespace Technologica.WcfCustom
{

    /// <summary>
    /// Plumbing class
    /// </summary>
    public class DocumentationAttribute : Attribute,
        IServiceBehavior,
        IContractBehavior, IOperationBehavior,
        IWsdlExportExtension
    {
        #region Private Fields
        //ContractDescription _contractDescription;
        OperationDescription _operationDescription;
        #endregion

        #region Properties
        /// <summary>
        /// enable annotation and documentation process
        /// </summary>
        public bool Enable { get; set; }

        /// <summary>
        /// Documentation text
        /// </summary>
        public string Documentation { get; set; }

        /// <summary>
        /// valid if the extension is applied
        /// </summary>
       // public bool IsBehaviorExtensions { get; set; }

        /// <summary>
        /// Enable xml documentation from the source code (///)
        /// </summary>
      //  public bool ExportXmlDoc { get; set; }

        /// <summary>
        /// Export annotation in the DataContract as xml formatted text, otherwise IXmlSerializable object XElement
        /// </summary>
      //  public bool ExportAsText { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public DocumentationAttribute()
            : this(string.Empty, true)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="documentation"></param>
        public DocumentationAttribute(string documentation)
            : this(documentation, true)
        {
        }
        public DocumentationAttribute(string documentation, bool bExportXmlDoc)
        {
            this.Documentation = documentation;
           // this.ExportXmlDoc = bExportXmlDoc;
            this.Enable = true;
           // this.ExportAsText = false;
           // this.IsBehaviorExtensions = false;
        }
        #endregion

        #region IServiceBehavior Members
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ServiceEndpoint endpoint in serviceDescription.Endpoints)
            {
                var doc = endpoint.Contract.Behaviors.Find<DocumentationAttribute>();
                if (doc != null)
                {
                    doc.Enable = this.Enable;
                   // doc.ExportAsText = this.ExportAsText;
                   // doc.IsBehaviorExtensions = true;
                }

                foreach (OperationDescription operation in endpoint.Contract.Operations)
                {
                    doc = operation.Behaviors.Find<DocumentationAttribute>();
                    if (doc != null)
                    {
                        doc.Enable = this.Enable;
                   //     doc.ExportAsText = this.ExportAsText;
                   //     doc.IsBehaviorExtensions = true;
                    }
                }
            }
        }
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
        #endregion

        #region IOperationBehavior Members
        public void AddBindingParameters(OperationDescription description, System.ServiceModel.Channels.BindingParameterCollection parameters)
        {
        }
        public void ApplyClientBehavior(OperationDescription description, System.ServiceModel.Dispatcher.ClientOperation proxy)
        {
        }
        public void ApplyDispatchBehavior(OperationDescription description, System.ServiceModel.Dispatcher.DispatchOperation dispatch)
        {
            if (this.Enable)
            {
                _operationDescription = description;
            }
        }
        public void Validate(OperationDescription description)
        {
        }
        #endregion

        #region IContractBehavior Members
        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }
        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
        }
        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.DispatchRuntime dispatchRuntime)
        {
            //if (this.Enable)
            //{
            //    _contractDescription = contractDescription;
            //}
        }
        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
        }
        #endregion

        #region IWsdlExportExtension Members
        public void ExportContract(WsdlExporter exporter, WsdlContractConversionContext context)
        {
        }


        public void ExportEndpoint(WsdlExporter exporter, WsdlEndpointConversionContext context)
        {
            if (this.Enable)
            {
                #region Wsdl:Documentation
                // [ServiceContract]
                var serviceAttribute = context.Endpoint.Contract.ContractType.GetCustomAttributes(typeof(DocumentationAttribute), false).FirstOrDefault() as DocumentationAttribute;
                if (serviceAttribute != null)
                {
                    context.WsdlPort.Service.Documentation = serviceAttribute.Documentation;
                    XmlDocumentation.Load(context.WsdlPort.Service.DocumentationElement, context.Endpoint.Contract.ContractType, serviceAttribute);
                    XmlSchemaAnnotations.Export(exporter, context);
                }

                // [OperationContract]
                if (_operationDescription != null)
                {
                    var op = context.GetOperationBinding(_operationDescription);
                    var opAttribute = _operationDescription.SyncMethod.GetCustomAttributes(typeof(DocumentationAttribute), false).FirstOrDefault() as DocumentationAttribute;
                    if (opAttribute != null)
                    {
                        op.Documentation = opAttribute.Documentation;
                        XmlDocumentation.Load(op.DocumentationElement, _operationDescription.SyncMethod, opAttribute);
                    }

                    if (op.Output != null)
                    {
                        var retAttribute = _operationDescription.SyncMethod.ReturnTypeCustomAttributes.GetCustomAttributes(typeof(DocumentationAttribute), false).FirstOrDefault() as DocumentationAttribute;
                        if (retAttribute != null)
                            op.Output.Documentation = retAttribute.Documentation;
                    }
                    if (op.Input != null)
                    {
                        foreach (var item in _operationDescription.SyncMethod.GetParameters())
                        {
                            var attr = item.GetCustomAttributes(typeof(DocumentationAttribute), false).FirstOrDefault() as DocumentationAttribute; ;
                            if (attr != null)
                            {
                                // only one parameter can be used in this binding
                                op.Input.Documentation = attr.Documentation;
                                break;
                            }
                        }
                    }
                }
                #endregion
            }
        }
        #endregion
    }
}
