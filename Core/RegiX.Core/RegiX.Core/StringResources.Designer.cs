﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TechnoLogica.RegiX.Core {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class StringResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal StringResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TechnoLogica.RegiX.Core.StringResources", typeof(StringResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Argument of operation &apos;{0}&apos; couldn&apos;t be cast to service request data!.
        /// </summary>
        internal static string ArgumentOfOperationCouldntBeCastToServiceRequestData {
            get {
                return ResourceManager.GetString("ArgumentOfOperationCouldntBeCastToServiceRequestData", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Operation with name:&apos;{0}&apos; could not be found!.
        /// </summary>
        internal static string OperationNotFound {
            get {
                return ResourceManager.GetString("OperationNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Operation &apos;{0}&apos; should have at least one argument!.
        /// </summary>
        internal static string OperationShouldHaveAtLeastOneArgument {
            get {
                return ResourceManager.GetString("OperationShouldHaveAtLeastOneArgument", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Result of operation &apos;{0}&apos; couldn&apos;t be cast to IProvideServiceResultData!.
        /// </summary>
        internal static string ResultOfOperationCouldntBeCastToIProvideServiceResultData {
            get {
                return ResourceManager.GetString("ResultOfOperationCouldntBeCastToIProvideServiceResultData", resourceCulture);
            }
        }
    }
}
