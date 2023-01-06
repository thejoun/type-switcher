using System;
using System.Text.RegularExpressions;
using Object = UnityEngine.Object;

namespace TypeSwitcher
{
    public class TypeSwitchSettings<TBase> : TypeSwitchSettings
    {
        public override Type BaseType => typeof(TBase);
    }
    
    public class TypeSwitchSettings
    {
        /// <summary>
        /// The base class - only derived classes will be shown
        /// </summary>
        public virtual Type BaseType { get; set; } = typeof(Object);
        
        /// <summary>
        /// Allow the base class to be selected in dropdown
        /// </summary>
        public bool IncludeBaseType { get; set; } = false;

        /// <summary>
        /// Remove base type name from type paths
        /// </summary>
        public bool HideBaseType { get; set; } = true; 
        
        /// <summary>
        /// Specific strings to remove from type paths
        /// </summary>
        public string[] HideStrings { get; set; }

        /// <summary>
        /// Put spaces between words in type paths
        /// </summary>
        public bool TitleCase { get; set; } = true;

        /// <summary>
        /// Specify exactly how to get the path of a type (default is type name)
        /// </summary>
        public Func<Type, string> PathGetter { get; set; }

        public string GetTypeName(Type type)
        {
            var path = PathGetter != null ? PathGetter(type) : type.Name;

            if (HideBaseType)
            {
                path = path.Replace(BaseType.Name, "");
            }
            
            if (HideStrings != null)
            {
                foreach (var toIgnore in HideStrings)
                {
                    path = path.Replace(toIgnore, "");
                }
            }

            if (TitleCase)
            {
                path = Regex.Replace(path, "[A-Z]", " $0").Trim();
            }

            return path;
        }

        public string GetTypePath(Type type)
        {
            var path = GetTypeName(type);

            var attributes = type.GetAttributes<TypeCategoryAttribute>();

            foreach (var attribute in attributes)
            {
                var category = attribute.CategoryString;

                if (!string.IsNullOrEmpty(category))
                {
                    path = $"{category}/{path}";
                }
            }

            return path;
        }
    }
}