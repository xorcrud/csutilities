﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.237
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CSUtilities.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Exceptions {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Exceptions() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CSUtilities.Resources.Exceptions", typeof(Exceptions).Assembly);
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
        ///   Looks up a localized string similar to Type &apos;{0}&apos; must be derived from System.Attribute or System.Attribute itself..
        /// </summary>
        internal static string AttributeExtensions_NonAttribute {
            get {
                return ResourceManager.GetString("AttributeExtensions_NonAttribute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The model name &apos;{0}&apos; of the CommerceEntity didn&apos;t match the expected model name &apos;{1}&apos; for the current mapper..
        /// </summary>
        internal static string Entity_WrongModel {
            get {
                return ResourceManager.GetString("Entity_WrongModel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Type {0} is not an enum..
        /// </summary>
        internal static string EnumHelper_NotAnEnum {
            get {
                return ResourceManager.GetString("EnumHelper_NotAnEnum", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value &quot;{0}&quot; is not defined within type {1}..
        /// </summary>
        internal static string EnumHelper_ValueNotDefined {
            get {
                return ResourceManager.GetString("EnumHelper_ValueNotDefined", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The EndLogging component is not registred within a FullTextSearch query context.
        ///
        ///SOLUTION:
        ///
        ///1) Go to ChannelConfiguration.config, search for:
        ///   &quot;End Full Text Search Logging&quot;
        ///
        ///2) Remove the component registration as this is not registred correctly.
        ///
        ///3) Then locate the following element:
        ///
        ///&lt;MessageHandler name=&quot;CommerceQueryOperation_CatalogEntity&quot;
        ///
        ///2) Register the EndLogging component as the last Component, like below:
        ///
        ///&lt;OperationSequence&gt;
        ///   &lt;!-- other components here --&gt;
        ///   &lt;Component na [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string FullTextSearchEndLoggingComponentWronglyRegistred {
            get {
                return ResourceManager.GetString("FullTextSearchEndLoggingComponentWronglyRegistred", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The ModelMappingAttribute wasn&apos;t found on the object beeing mapped! or the ModelName is empty.
        /// </summary>
        internal static string Mapping_ModelNotFound {
            get {
                return ResourceManager.GetString("Mapping_ModelNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No BeginLogging component registred. 
        ///
        ///SOLUTION:
        ///
        ///1) Go to ChannelConfiguration.config, locate the following element:
        ///
        ///&lt;MessageHandler name=&quot;CommerceQueryOperation_CatalogEntity&quot;
        ///
        ///2) Register the BeginLogging component as the first Component, like below:
        ///
        ///&lt;OperationSequence&gt;
        ///   &lt;Component name=&quot;Begin Full Text Search Logging&quot; type=&quot;CSUtilities.Providers.Components.FullTextSearch.BeginLogging, CSUtilities, Version=1.0.0.0, Culture=neutral, PublicKeyToken=06dc92500529a411&quot; /&gt;
        ///   &lt;!-- other compone [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string NoFullTextSearchBeginLoggingComponentRegistred {
            get {
                return ResourceManager.GetString("NoFullTextSearchBeginLoggingComponentRegistred", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No LoggingStorage provider registred. 
        ///
        ///SOLUTION:
        ///
        ///1) Go to web.config, locate the following element:
        ///
        ///&lt;GlobalServiceConfiguration&gt;
        ///   &lt;Services&gt;
        ///
        ///2) Add a new Service registration:
        ///
        ///&lt;Service
        ///   contract=&quot;CSUtilities.Providers.Components.FullTextSearch.ILoggingStorageProvider, CSUtilities, Version=1.0.0.0, Culture=neutral, PublicKeyToken=06dc92500529a411&quot;
        ///   implementation=&quot;&lt;your-class-implementing-ILoggingStorageProvider-interface-here&quot;/&gt;
        ///
        ///3) You are done. Test by executing a new FullTextSea [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string NoFullTextSearchLoggingSearchProviderRegistred {
            get {
                return ResourceManager.GetString("NoFullTextSearchLoggingSearchProviderRegistred", resourceCulture);
            }
        }
    }
}
