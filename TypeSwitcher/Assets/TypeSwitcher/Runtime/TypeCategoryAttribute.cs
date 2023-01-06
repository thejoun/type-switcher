using System;

namespace TypeSwitcher
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class TypeCategoryAttribute : Attribute
    {
        public object Category { get; }

        public string CategoryString => Category.ToString();
        
        public TypeCategoryAttribute(object category)
        {
            Category = category;
        }
    }
}