﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bookcase.Properties {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Bookcase.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Autor.
        /// </summary>
        internal static string AuthorText {
            get {
                return ResourceManager.GetString("AuthorText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Wszystkie.
        /// </summary>
        internal static string FilterTypeAll {
            get {
                return ResourceManager.GetString("FilterTypeAll", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Nieposiadane.
        /// </summary>
        internal static string FilterTypeNotOwned {
            get {
                return ResourceManager.GetString("FilterTypeNotOwned", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Niezaczęte.
        /// </summary>
        internal static string FilterTypeNotRead {
            get {
                return ResourceManager.GetString("FilterTypeNotRead", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Przeczytane.
        /// </summary>
        internal static string FilterTypeRead {
            get {
                return ResourceManager.GetString("FilterTypeRead", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Zaczęte.
        /// </summary>
        internal static string FilterTypeStarted {
            get {
                return ResourceManager.GetString("FilterTypeStarted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Gatunek.
        /// </summary>
        internal static string GenreText {
            get {
                return ResourceManager.GetString("GenreText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ic_question_mark {
            get {
                object obj = ResourceManager.GetObject("ic_question_mark", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tytuł.
        /// </summary>
        internal static string TitleText {
            get {
                return ResourceManager.GetString("TitleText", resourceCulture);
            }
        }
    }
}
