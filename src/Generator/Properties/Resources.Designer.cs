﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Thor.Generator.Properties {
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
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Thor.Generator.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to The provided file or directory &apos;{0}&apos; does not exist..
        /// </summary>
        internal static string FileOrDirectoryNotExists {
            get {
                return ResourceManager.GetString("FileOrDirectoryNotExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No file or directory name was provided..
        /// </summary>
        internal static string NoFileOrDirectoryName {
            get {
                return ResourceManager.GetString("NoFileOrDirectoryName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No source project was provided..
        /// </summary>
        internal static string NoSourceProject {
            get {
                return ResourceManager.GetString("NoSourceProject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No template export directory was provided..
        /// </summary>
        internal static string NoTemplateExportDirectory {
            get {
                return ResourceManager.GetString("NoTemplateExportDirectory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No template file was provided..
        /// </summary>
        internal static string NoTemplateFile {
            get {
                return ResourceManager.GetString("NoTemplateFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No template name was provided..
        /// </summary>
        internal static string NoTemplateName {
            get {
                return ResourceManager.GetString("NoTemplateName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The specified template file &apos;{0}&apos; does not exist..
        /// </summary>
        internal static string TemplateFileNotExists {
            get {
                return ResourceManager.GetString("TemplateFileNotExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A template with the specified name &apos;{0}&apos; could not be found..
        /// </summary>
        internal static string TemplateNotExists {
            get {
                return ResourceManager.GetString("TemplateNotExists", resourceCulture);
            }
        }
    }
}
