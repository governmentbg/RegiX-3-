//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RegiX.Core.STSIntegration.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://92.247.29.196:9443/egov-sts/jaxws-sts/sts")]
        public string STSAddress {
            get {
                return ((string)(this["STSAddress"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("sts.egov.bg")]
        public string STSIdentity {
            get {
                return ((string)(this["STSIdentity"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("LocalMachine")]
        public global::System.Security.Cryptography.X509Certificates.StoreLocation STSServiceCertificateStoreLocation {
            get {
                return ((global::System.Security.Cryptography.X509Certificates.StoreLocation)(this["STSServiceCertificateStoreLocation"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("TrustedPeople")]
        public global::System.Security.Cryptography.X509Certificates.StoreName STSServiceCertificateStoreName {
            get {
                return ((global::System.Security.Cryptography.X509Certificates.StoreName)(this["STSServiceCertificateStoreName"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("FindByThumbprint")]
        public global::System.Security.Cryptography.X509Certificates.X509FindType STSServiceCertificateX509FindType {
            get {
                return ((global::System.Security.Cryptography.X509Certificates.X509FindType)(this["STSServiceCertificateX509FindType"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("FC3ACE9EF9C204CBEF98D89818686F9E2EA3F5A9")]
        public string STSServiceCertificateValue {
            get {
                return ((string)(this["STSServiceCertificateValue"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("LocalMachine")]
        public global::System.Security.Cryptography.X509Certificates.StoreLocation STSClientCertificateStoreLocation {
            get {
                return ((global::System.Security.Cryptography.X509Certificates.StoreLocation)(this["STSClientCertificateStoreLocation"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("My")]
        public global::System.Security.Cryptography.X509Certificates.StoreName STSClientCertificateStoreName {
            get {
                return ((global::System.Security.Cryptography.X509Certificates.StoreName)(this["STSClientCertificateStoreName"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("FindByThumbprint")]
        public global::System.Security.Cryptography.X509Certificates.X509FindType STSClientCertificateX509FindType {
            get {
                return ((global::System.Security.Cryptography.X509Certificates.X509FindType)(this["STSClientCertificateX509FindType"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("FEB8132C82D38E0A8A43D94D8CF1B5A35499BE2E")]
        public string STSClientCertificateValue {
            get {
                return ((string)(this["STSClientCertificateValue"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Sign")]
        public string STSProtectionLevel {
            get {
                return ((string)(this["STSProtectionLevel"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool STSValidationEnable {
            get {
                return ((bool)(this["STSValidationEnable"]));
            }
        }
    }
}
