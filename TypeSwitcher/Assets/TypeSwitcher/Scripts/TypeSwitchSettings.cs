using System;
using System.Text.RegularExpressions;
using Object = UnityEngine.Object;

namespace TypeSwitcher
{
    public class TypeSwitchSettings
    {
        /// <summary>
        /// The base class - only derived classes will be shown
        /// </summary>
        public Type BaseType { get; set; } = typeof(Object);
        
        /// <summary>
        /// Hide the base class in the dropdown
        /// </summary>
        public bool ExcludeBaseType { get; set; } = true;

        /// <summary>
        /// Strings to remove from displayed paths
        /// </summary>
        public string[] HideInPath { get; set; }

        /// <summary>
        /// Whether the whole path should be in title case (putting spaces between words)
        /// </summary>
        public bool TitleCasePath { get; set; } = true;

        /// <summary>
        /// Whether to add the TypeCategory property as a folder in the path
        /// </summary>
        public bool CategoryInPath { get; set; } = true;
        
        /// <summary>
        /// Specify how to get the path of a type, instead of just the type name (default)
        /// </summary>
        public Func<Type, string> PathGetter { get; set; }

        public string GetTypeName(Type type)
        {
            var path = PathGetter != null ? PathGetter(type) : type.Name;

            if (HideInPath != null)
            {
                foreach (var toIgnore in HideInPath)
                {
                    path = path.Replace(toIgnore, "");
                }
            }

            if (TitleCasePath)
            {
                path = Regex.Replace(path, "[A-Z]", " $0").Trim();
            }

            return path;
        }

        public string GetTypePath(Type type)
        {
            var path = GetTypeName(type);

            if (CategoryInPath)
            {
                var attributes = type.GetAttributes<TypeCategoryAttribute>();

                foreach (var attribute in attributes)
                {
                    var category = attribute.CategoryString;

                    if (!string.IsNullOrEmpty(category))
                    {
                        path = $"{category}/{path}";
                    }
                }
            }

            return path;
        }
    }
}